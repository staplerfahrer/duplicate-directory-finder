using System;

namespace Data
{
    public static class IO
    {
		public readonly static string Path = 
			Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
				+ @"\DuplicateDirectoryFinder\";

		public static string MakeSafe(string fileName)
		{
			foreach (var c in new char[] { '<', '>', ':', '"', '/', '\\', '|', '?', '*' })
			{
				fileName = fileName.Replace(c, '_');
			}
			return fileName;
		}

		public static bool SaveDirectoryList(DirectoryList d, string fileName)
		{
			var path = IO.Path + fileName;
			try
			{
				using (var str = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write))
				{
					var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
					bf.Serialize(str, d);
					return true;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("exception while saving to: " + path + "\n" + e.Message);
				return false;
			}
		}

		public static DirectoryList LoadDirectoryList(string fileName)
		{
			var path = IO.Path + fileName;
			try
			{
				using (var str = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read))
				{
					var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
					return (DirectoryList)bf.Deserialize(str);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("exception while loading from: " + path + "\n" + e.Message);
				return null;
			}
		}

		public static bool SaveFileInfoDictionary(FileInfoDictionary dic)
		{
			var path = IO.Path + "FileInfoDictionary";
			try
			{
				using (var str = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write))
				{
					var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
					bf.Serialize(str, dic);
					return true;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("exception while saving to: " + path + "\n" + e.Message);
				return false;
			}
		}

		public static FileInfoDictionary LoadFileInfoDictionary()
		{
			var path = IO.Path + "FileInfoDictionary";
			try
			{
				using (var str = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read))
				{
					var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
					return (FileInfoDictionary)bf.Deserialize(str);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("exception while loading from: " + path + "\n" + e.Message);
				return null;
			}
		}
    }
}
