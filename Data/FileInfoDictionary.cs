namespace DDFinder.Services.DuplicateScanner
{
	using DDFinder.Services.IO;

	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	public class UseFileInfoDictionary
	{
		public FileInfoDictionary Dic { get; set; }

		public UseFileInfoDictionary(FileInfoDictionary d)
		{
			Dic = d;
		}

		public UseFileInfoDictionary(bool loadFromDisk)
		{
			if (loadFromDisk)
			{
				Dic = Storage.LoadFileInfoDictionary<FileInfoDictionary>();
				if (Dic == null) throw new Exception("File info dictionary did not load.");
			}
		}

		public UseFileInfoDictionary(DirectoryList directoryList)
		{
			Dic = new DDFinder.Services.DuplicateScanner.FileInfoDictionary();
			Dic.Created = DateTime.Now;
			foreach (var hash in directoryList.ScanInfo.DuplicateFiles.AllFilesByHash)
			{
				foreach (var f in hash.Value)
				{
					Dic.Add(f.FullName, f);
				}
			}
		}

		public string GetHash(string fullName)
		{
			var f = new System.IO.FileInfo(fullName);
			return GetHash(f);
		}

		public string GetHash(System.IO.FileInfo f)
		{
			if (HasFile(f))
			{
				return Dic[f.FullName].MD5;
			}
			else
			{
				return null;
			}
		}

		public bool Save()
		{
			return Storage.SaveFileInfoDictionary<FileInfoDictionary>(Dic);
		}

		public bool HasFile(string fullName)
		{
			return HasFile(new System.IO.FileInfo(fullName));
		}

		public bool HasFile(System.IO.FileInfo f)
		{
			if (!Dic.ContainsKey(f.FullName)) return false;

			var libFile = Dic[f.FullName];
			return libFile.Size == f.Length
				&& libFile.CreatedUTC == f.CreationTimeUtc
				&& libFile.ModifiedUTC == f.LastWriteTimeUtc;
		}
	}

	/// <summary>
	/// File info stored by full name
	/// </summary>
	[Serializable()]
	public class FileInfoDictionary : Dictionary<string, DDFinder.Services.DuplicateScanner.File>
	{
		public FileInfoDictionary()
			: base()
		{
		}
		public FileInfoDictionary(SerializationInfo info, StreamingContext context) 
			: base(info, context) 
		{
		}

		public DateTime Created { get; set; }
	}
}
