using System;
using System.Collections.Generic;

namespace DDFinder.Services.DuplicateScanner
{
    [Serializable()]
    public class Directory
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
        public System.IO.FileAttributes Attributes { get; private set; } 
        public List<Directory> Directories { get; private set; }
        public List<File> Files { get; private set; }

		public DateTime CreatedUTC { get; private set; }
        public DateTime ModifiedUTC { get; private set; }
        public DateTime AccessedUTC { get; private set; }

        public Exception Exception { get; private set; }

		private System.IO.DirectoryInfo directoryInfo;

        public Directory(string fullPath)
        {
            try
            {
	            System.IO.DirectoryInfo di;
                di = new System.IO.DirectoryInfo(fullPath);
				SetProperties(di);
            }
            catch (Exception e)
            {
                Console.WriteLine("exception: " + fullPath + "\n" + e.Message);
                Exception = e;
                return;
            }
        }

        public Directory(System.IO.DirectoryInfo di)
        {
            SetProperties(di);
        }

        private void SetProperties(System.IO.DirectoryInfo di)
        {
			if (!di.Exists) Exception = new Exception("Path not found: " + di.FullName);
			directoryInfo = di;
			Name = directoryInfo.Name;
			Path = directoryInfo.FullName;
			CreatedUTC = directoryInfo.CreationTimeUtc;
			ModifiedUTC = directoryInfo.LastWriteTimeUtc;
			AccessedUTC = directoryInfo.LastAccessTimeUtc;
			Attributes = directoryInfo.Attributes;
            this.Directories = new List<Directory>();
            this.Files = new List<File>();
        }

		public void Scan(long skipSmallerThan, ref Statistics.ScanInfo scanInfo)
		{
			scanInfo.StackSize++;
			// directories
			try
			{
				// directories first to get some useful stats
				foreach (var d in this.directoryInfo.EnumerateDirectories())
				{
					// skip reparse points to avoid infinite loops
					if ((d.Attributes & System.IO.FileAttributes.ReparsePoint) 
						== System.IO.FileAttributes.ReparsePoint)
					{
						continue;
					}

					scanInfo.DirectoryCount++;
					scanInfo.ListDirectory(d.FullName);

					var newD = new Directory(d);
					newD.Scan(skipSmallerThan, ref scanInfo);
					this.Directories.Add(newD);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("directory add exception: " + this.directoryInfo.FullName + "\n" + e.Message);
				Exception = e;
			}

			// files
			try
			{
				foreach (var f in this.directoryInfo.EnumerateFiles())
				{
					// skip reparse points to avoid infinite loops
					if ((f.Attributes & System.IO.FileAttributes.ReparsePoint) == System.IO.FileAttributes.ReparsePoint
						|| f.Length < skipSmallerThan * 1024)
					{
						continue;
					}

					scanInfo.FileScanCount++;
					scanInfo.ListFile(f.Name);

					this.Files.Add(new File(f));
					scanInfo.DirectorySize += f.Length;
				}
			}
			catch (Exception e)
			{
				// todo: fix; this could overwrite existing exception
				Console.WriteLine("file add exception: " + this.directoryInfo.FullName + "\n" + e.Message);
				Exception = e;
			}

			scanInfo.StackSize--;
		}

		public void Hash(ref Statistics.ScanInfo scanInfo, UseFileInfoDictionary useFileInfoDictionary)
		{
			scanInfo.StackSize++;
			// directories
			try
			{
				// directories first to get some useful stats
				foreach (var d in this.Directories)
				{
					// skip reparse points to avoid infinite loops
					if ((d.Attributes & System.IO.FileAttributes.ReparsePoint)
						!= System.IO.FileAttributes.ReparsePoint)
					{
						scanInfo.ListDirectory(d.Path);

						d.Hash(ref scanInfo, useFileInfoDictionary);
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("directory add exception: " + this.directoryInfo.FullName + "\n" + e.Message);
				Exception = e;
			}

			// files
			try
			{
				foreach (var f in this.Files)
				{
					// for progress bar
					scanInfo.FileHashCount++;

					// if file size occurs more than once,
					if (scanInfo.DuplicateFiles.AllFilesBySize[f.Size].Count > 1)
					{
						scanInfo.ListFile(f.Name);

						// calculate or read the hash
						f.Hash(useFileInfoDictionary);
					}
				}
			}
			catch (Exception e)
			{
				// todo: fix; this could overwrite existing exception
				Console.WriteLine("file add exception: " + this.directoryInfo.FullName + "\n" + e.Message);
				Exception = e;
			}

			scanInfo.StackSize--;
		}

		public override string ToString()
        {
            return this.Path;
        }
    }
}
