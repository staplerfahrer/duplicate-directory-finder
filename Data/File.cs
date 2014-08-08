using System;
using System.Security.Cryptography;

namespace Data
{
	/// <summary>
	/// The object containing all relevant information about a file.
	/// </summary>
    [Serializable()]
    public class File
    {
        public string Name { get; private set; }
        public string Extension { get; private set; }
        public string FullName { get; private set; }
		public string Path { get; private set; }
		public System.IO.FileAttributes Attributes { get; private set; }

		/* stats */
        public long Size { get; private set; }
        public DateTime CreatedUTC { get; private set; }
        public DateTime ModifiedUTC { get; private set; }
        public DateTime AccessedUTC { get; private set; }

		public Exception Exception { get; private set; }

		public string MD5 { get; private set; }

		/// <summary>
		/// Creates the object with new FileInfo from fullName
		/// </summary>
		/// <param name="fullName"></param>
		public File(string fullName)
        {
            System.IO.FileInfo fi;
            try
            {
                fi = new System.IO.FileInfo(fullName);
                SetProperties(fi);
            }
            catch (Exception e)
            {
                Console.WriteLine("exception: " + fullName + "\n" + e.Message);
                Exception = e;
                return;
            }
        }

		/// <summary>
		/// Creates the object with existing FileInfo
		/// </summary>
		/// <param name="fi"></param>
        public File(System.IO.FileInfo fi)
        {
            SetProperties(fi);
        }

		public override string ToString()
		{
			return this.FullName;
		}

		public void Hash(UseFileInfoDictionary useFileDic)
		{
			// skip if there is an exception
			if (this.Exception != null) return;

			if (useFileDic == null
				|| !useFileDic.HasFile(this.FullName))
			{
				this.MD5 = GetFileMD5();
			}
			else
			{
				this.MD5 = useFileDic.GetHash(this.FullName);
			}
		}

        private void SetProperties(System.IO.FileInfo fi)
        {
            if (!fi.Exists) Exception = new Exception("File not found: " + fi.FullName);

            Name = fi.Name;
            Extension = fi.Extension;
            FullName = fi.FullName;
			Path = fi.Directory.FullName;
            Size = fi.Length;
            Attributes = fi.Attributes;
            CreatedUTC = fi.CreationTimeUtc;
            ModifiedUTC = fi.LastWriteTimeUtc;
            AccessedUTC = fi.LastAccessTimeUtc;
        }

        private string GetFileMD5()
        {
            try
            {
                using (var fs = new System.IO.FileStream(this.FullName, 
					System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    var md5 = MD5CryptoServiceProvider.Create();
                    return BitConverter.ToString(md5.ComputeHash(fs)).Replace("-","").ToLower();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("exception: " + this.FullName + "\n" + e.Message);
                Exception = e;
                return null;
            }
        }
	}
}
