using System;
using System.Collections.Generic;

namespace Data
{
	[Serializable()]
	public class DirectoryList : List<Directory>
	{
		/* stats */
		private Statistics.ScanInfo scanInfo = new Statistics.ScanInfo();
		public Statistics.ScanInfo ScanInfo { get { return scanInfo; } }

		public DirectoryList()
			: base()
		{
		}

		public void Scan(long skipSmallerThan)
		{
			//foreach (var d in this)
			//{
			//	d.Scan(skipSmallerThan, ref scanInfo);
			//}

			System.Threading.Tasks.Parallel.ForEach(this, d =>
				d.Scan(skipSmallerThan, ref scanInfo));
		}

		public void Hash(UseFileInfoDictionary useFileInfoDictionary)
		{
			//foreach (var d in this)
			//{
			//	d.Hash(ref scanInfo, useFileInfoDictionary);
			//}

			System.Threading.Tasks.Parallel.ForEach(this, d =>
				d.Hash(ref scanInfo, useFileInfoDictionary));
		}
	}
}
