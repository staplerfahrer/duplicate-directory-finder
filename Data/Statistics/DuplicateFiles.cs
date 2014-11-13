namespace DDFinder.Services.DuplicateScanner.Statistics
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;

	/// <summary>
	/// Produces statistics about the duplicates found in the scan results
	/// </summary>
	[Serializable()]
	public class DuplicateFiles
	{
		FilesBySize allFilesBySize;
		FilesByHash allFilesByHash;
		public FilesBySize AllFilesBySize { get { return allFilesBySize; } }
		public FilesByHash AllFilesByHash { get { return allFilesByHash; } }

		/// <summary>
		/// This is the statistics object that produces dictionaries with duplicate files.
		/// </summary>
		/// <param name="dList">The object containing root directory/directories that were scanned.</param>
		public DuplicateFiles(DirectoryList dList)
		{
			this.allFilesBySize = new FilesBySize();
			this.allFilesByHash = new FilesByHash();
			Process(dList);
		}

		/// <summary>
		/// Create and update duplicate file entries
		/// </summary>
		/// <param name="dList"></param>
		public void Process(DirectoryList dList)
		{
			foreach (var directory in dList)
			{
				GetStats(allFilesByHash, allFilesBySize, directory);
			}
		}

		/// <summary>
		/// Build the dictionaries for file hashes and sizes recursively.
		/// </summary>
		/// <param name="allFilesByHash"></param>
		/// <param name="allFilesBySize"></param>
		/// <param name="d"></param>
		private static void GetStats(
			FilesByHash allFilesByHash,
			FilesBySize allFilesBySize,
			Directory d)
		{
			// depth first
			foreach (var subDirectory in d.Directories)
			{
				GetStats(allFilesByHash, allFilesBySize, subDirectory);
			}

			foreach (var f in d.Files)
			{
				// pigeonhole file by size
				allFilesBySize.Add(f.Size, f);

				// skip if no hash exists for this file
				// e. g. if it couldn't be scanned
				if (f.MD5 == null) continue;

				// pigeonhole file by hash
				allFilesByHash.Add(f.MD5, f);
			}
		}

		/// <summary>
		/// Get a dictionary with files only if there are multiple files with that hash.
		/// </summary>
		public Dictionary<string, List<File>> GetDuplicatesByHash
		{
			get
			{
				var duplicates = allFilesByHash.Where(f =>
						f.Value.Count > 1)
					.ToDictionary(f => f.Key, f => f.Value);

				return duplicates;
			}
		}

		[Serializable()]
		public class FilesBySize : Dovecot<long, File>
		{
			public FilesBySize()
				: base()
			{
			}

			public FilesBySize(SerializationInfo info, StreamingContext context)
				: base(info, context)
			{
			}
		}

		[Serializable()]
		public class FilesByHash : Dovecot<string, File>
		{
			public FilesByHash()
				: base()
			{
			}

			public FilesByHash(SerializationInfo info, StreamingContext context)
				: base(info, context)
			{
			}
		}

		[Serializable()]
		public class Dovecot<THole, TPigeon> : Dictionary<THole, List<TPigeon>>
		{
			public Dovecot()
				: base()
			{
			}

			public Dovecot(SerializationInfo info, StreamingContext context)
				: base(info, context)
			{
			}

			/// <summary>
			/// See if there's a hole where the pigeon fits, if not, create one.
			/// Then, check if the pigeon is already there. If not, add.
			/// </summary>
			/// <param name="hole"></param>
			/// <param name="pigeon"></param>
			public void Add(THole hole, TPigeon pigeon)
			{
				if (!this.ContainsKey(hole))
				{
					var pigeons = new List<TPigeon>();
					pigeons.Add(pigeon);
					this.Add(hole, pigeons);
				}
				else
				{
					// skip files scanned more than once
					if (!this[hole].Contains(pigeon))
					{
						this[hole].Add(pigeon);
					}
				}
			}
		}
	}
}
