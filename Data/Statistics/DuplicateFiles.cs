using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Data.Statistics
{
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
			this.allFilesBySize = new FilesBySize(); //new Dictionary<long, List<File>>();
			this.allFilesByHash = new FilesByHash(); //new Dictionary<string, List<File>>();
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
		public class FilesBySize : Dictionary<long, List<File>>
		{
			public FilesBySize() : base()
			{
			}

			public FilesBySize(SerializationInfo info, StreamingContext context) : base(info, context) 
			{
			}

			public void Add(long key, File file)
			{
				Pigeonhole(this, key, file);
			}
		}

		[Serializable()]
		public class FilesByHash : Dictionary<string, List<File>>
		{
			public FilesByHash() : base()
			{
			}

			public FilesByHash(SerializationInfo info, StreamingContext context) : base(info, context) 
			{
			}

			public void Add(string key, File file)
			{
				Pigeonhole(this, key, file);
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
