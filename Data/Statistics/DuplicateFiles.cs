using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Statistics
{
	[Serializable()]
	public class DuplicateFiles
    {
        Dictionary<string, List<File>> allFilesByHash;
		Dictionary<long, List<File>> allFilesBySize;
		public Dictionary<string, List<File>> AllFilesByHash { get { return allFilesByHash;} }
		public Dictionary<long, List<File>> AllFilesBySize { get { return allFilesBySize;} }

		public DuplicateFiles(DirectoryList dList)
		{
			this.allFilesByHash = new Dictionary<string, List<File>>();
			this.allFilesBySize = new Dictionary<long, List<File>>();
			Process(dList);
		}

		/// <summary>
		/// Create and update duplicate file entries
		/// </summary>
		/// <param name="dList"></param>
		public void Process(DirectoryList dList)
		{
			foreach (var d in dList)
			{
				GetStats(ref allFilesByHash, ref allFilesBySize, d);
			}
		}

        private void GetStats(ref Dictionary<string, List<File>> allFilesByHash, 
			ref Dictionary<long, List<File>> allFilesBySize, Directory d)
        {
            foreach (var subD in d.Directories)
            {
                GetStats(ref allFilesByHash, ref allFilesBySize, subD);
            }

            foreach (var f in d.Files)
            {
				// add file by size
				if (!allFilesBySize.ContainsKey(f.Size))
				{
					var l = new List<File>();
					l.Add(f);
					allFilesBySize.Add(f.Size, l);
				}
				else
				{
					if (!allFilesBySize[f.Size].Contains(f))
					{
						// don't add it twice
						allFilesBySize[f.Size].Add(f);
					}
				}
				
				// skip if no hash for this file
				if (f.MD5 == null) continue;

                if (!allFilesByHash.ContainsKey(f.MD5))
                {
                    var l = new List<File>();
                    l.Add(f);
                    allFilesByHash.Add(f.MD5, l);
                }
                else
                {
					if (!allFilesByHash[f.MD5].Contains(f))
					{
	                    allFilesByHash[f.MD5].Add(f);
					}
                }
            }
        }

		/// <summary>
		/// Returns a dictionary with file hash only if there are multiple files with that hash.
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, List<File>> GetDuplicatesByHash()
		{
			var duplicates = allFilesByHash.Where(f => f.Value.Count > 1).ToDictionary(f => f.Key, f => f.Value);
			return duplicates;
		}
    }
}
