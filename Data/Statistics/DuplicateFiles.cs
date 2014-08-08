using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Statistics
{
	/// <summary>
	/// Produces statistics about the duplicates found in the scan results
	/// </summary>
	[Serializable()]
	public class DuplicateFiles
    {
        Dictionary<string, List<File>> allFilesByHash;
		Dictionary<long, List<File>> allFilesBySize;
		public Dictionary<string, List<File>> AllFilesByHash { get { return allFilesByHash; } }
		public Dictionary<long, List<File>> AllFilesBySize { get { return allFilesBySize; } }

		/// <summary>
		/// This is the statistics object that produces dictionaries with duplicate files.
		/// </summary>
		/// <param name="dList">The object containing root directory/directories that were scanned.</param>
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
			foreach (var directory in dList)
			{
				GetStats(ref allFilesByHash, ref allFilesBySize, directory);
			}
		}

		/// <summary>
		/// Build the dictionaries for file hashes and sizes recursively.
		/// </summary>
		/// <param name="allFilesByHash"></param>
		/// <param name="allFilesBySize"></param>
		/// <param name="d"></param>
        private static void GetStats(
			ref Dictionary<string, List<File>> allFilesByHash, 
			ref Dictionary<long, List<File>> allFilesBySize, 
			Directory d)
        {
			// depth first
            foreach (var subDirectory in d.Directories)
            {
                GetStats(ref allFilesByHash, ref allFilesBySize, subDirectory);
            }

            foreach (var f in d.Files)
            {
				// pigeonhole file by size
				Pigeonhole(allFilesBySize, f.Size, f);
				
				// skip if no hash exists for this file
				// i. e. if it couldn't be scanned
				if (f.MD5 == null) continue;

				// pigeonhole file by hash
				Pigeonhole(allFilesByHash, f.MD5, f);
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

		/// <summary>
		/// Stuff pigeons into the right hole of specified dovecot.
		/// </summary>
		/// <typeparam name="TDovecote"></typeparam>
		/// <typeparam name="THole"></typeparam>
		/// <param name="stats"></param>
		/// <param name="hole"></param>
		/// <param name="pigeon"></param>
		private static void Pigeonhole<TDovecote, THole>(TDovecote stats, THole hole, File pigeon) where TDovecote : IDictionary<THole, List<File>>
		{
			if (!stats.ContainsKey(hole))
			{
				var pigeons = new List<File>();
				pigeons.Add(pigeon);
				stats.Add(hole, pigeons);
			}
			else
			{
				// skip files scanned more than once
				if (!stats[hole].Contains(pigeon))
				{
					stats[hole].Add(pigeon);
				}
			}
		}
    }
}
