using System;
using System.Collections.Generic;

namespace Data.Statistics
{
	[Serializable()]
	public class ScanInfo
	{
		public bool DoneScanning { get; set; }
		public bool DoneHashing { get; set; }
		public long FileScanCount { get; set; }
		public long FileHashCount { get; set; }
		public long DirectoryCount { get; set; }
		public long DirectorySize { get; set; }
		public int StackSize { get; set; }

		public DuplicateFiles DuplicateFiles { get; set; }
	
		private List<string> last10Directories;
		private List<string> last10Files;

		public ScanInfo()
		{
			last10Directories = new List<string>(10);
			last10Files = new List<string>(10);
		}

		public void Reset()
		{
			DoneScanning = false;
			DoneHashing = false;
			FileScanCount = 0;
			FileHashCount = 0;
			DirectoryCount = 0;
			DirectorySize = 0;
			StackSize = 0;
			last10Directories = new List<string>(10);
			last10Files = new List<string>(10);
		}

		public void ListDirectory(string path)
		{
			if (last10Directories.Count > 10)
			{
				last10Directories.RemoveAt(0);
			}
			last10Directories.Add(path);
		}

		public void ListFile(string name)
		{
			if (last10Files.Count > 10)
			{
				last10Files.RemoveAt(0);
			}
			last10Files.Add(name);
		}

		public string[] Last10Directories { get { try { return last10Directories.ToArray(); } catch(Exception) { return new string[0]{}; } } }
		public string[] Last10Files { get { try { return last10Files.ToArray(); } catch (Exception) { return new string[0] { }; } } }
	}
}
