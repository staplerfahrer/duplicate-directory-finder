namespace DDFinder.Services.IO
{
	using IO.Poco;
	using System;
	using System.IO;
	using System.Runtime.Serialization.Formatters.Binary;
	using System.Threading.Tasks;

	public static class Storage
	{
		public readonly static string DirectoryListFileName = "DirectoryList";

		public readonly static string MyAppDataPath =
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
				+ @"\DuplicateDirectoryFinder\";

		/// <summary>
		/// Get the filename for saving or loading the directory list object.
		/// </summary>
		public static string DirectoryListFullPath
		{
			get	{ return MyAppDataPath + DirectoryListFileName; }
		}

		/// <summary>
		/// Save the object of type T to the fullPath or DirectoryListFullPath.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="directoryList"></param>
		/// <param name="fullPath">DirectoryListFullPath if null</param>
		/// <returns></returns>
		public static bool SaveDirectoryList<T>(T directoryList, string fullPath = null)
		{
			var path = fullPath ?? DirectoryListFullPath;
			try
			{
				using (var str = new FileStream(path, FileMode.Create, FileAccess.Write))
				{
					new BinaryFormatter().Serialize(str, directoryList);
					return true;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(string.Format("exception while saving to: {0}\n{1}", path, e.Message));
				return false;
			}
		}

		/// <summary>
		/// Load the object of type T from the fullPath or DirectoryListFullPath.
		/// </summary>
		/// <typeparam name="T">type of object loaded and returned with the IOResult</typeparam>
		/// <param name="fullPath">DirectoryListFullPath if null</param>
		/// <returns></returns>
		public static async Task<IOResult<T>> LoadDirectoryListAsync<T>(string fullPath = null)
		{
			try
			{
				var result = await Task.Run<IOResult<T>>(() =>
					{
						using (var str = new FileStream(
								fullPath ?? DirectoryListFullPath,
								FileMode.Open,
								FileAccess.Read))
						{
							var bf = new BinaryFormatter();
							return new IOResult<T>((T)bf.Deserialize(str));
						}
					});
				return result;
			}
			catch (Exception e)
			{
				var message = string.Format("exception while loading from: {0}\n{1}", fullPath, e.Message);
				return new IOResult<T>(message);
			}
		}

		/// <summary>
		/// Save the object of type T to file FileInfoDictionary.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="dictionary"></param>
		/// <returns></returns>
		public static bool SaveFileInfoDictionary<T>(T dictionary)
		{
			var path = MyAppDataPath + "FileInfoDictionary";
			try
			{
				using (var str = new FileStream(path, FileMode.Create, FileAccess.Write))
				{
					var bf = new BinaryFormatter();
					bf.Serialize(str, dictionary);
					return true;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("exception while saving to: " + path + "\n" + e.Message);
				return false;
			}
		}

		/// <summary>
		/// Load the object of type T from file FileInfoDictionary.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="dictionary"></param>
		/// <returns></returns>
		/// <exception cref="System.Exception"></exception>
		public static T LoadFileInfoDictionary<T>()
		{
			var path = MyAppDataPath + "FileInfoDictionary";
			try
			{
				using (var str = new FileStream(path, FileMode.Open, FileAccess.Read))
				{
					var bf = new BinaryFormatter();
					return (T)bf.Deserialize(str);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("exception while loading from: " + path + "\n" + e.Message);
				throw;
			}
		}
	}
}
