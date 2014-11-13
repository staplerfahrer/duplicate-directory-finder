namespace DDFinder.Services.Tests.DuplicateScanner
{
	using DDFinder.Services.DuplicateScanner;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	
	[TestClass]
    public class Tests
    {
        [TestMethod]
        public void FileInfo()
        {
            var f = new DDFinder.Services.DuplicateScanner.File(@"C:\Windows\explorer.exe", true);
            Assert.IsNotNull(f);
            Assert.IsNotNull(f.MD5);

            f = new DDFinder.Services.DuplicateScanner.File(@"C:\Users\Jacob\Unigine Heaven\shader_d3d11.cache", true);
            Assert.IsNotNull(f);
            Assert.IsNotNull(f.MD5);
        }

        [TestMethod]
        public void SaveDirectoryInfo()
        {
            var d = new DDFinder.Services.DuplicateScanner.Directory(@"C:\PerfLogs", true);
            var result = IO.SaveDirectory(d, @"SavedDirectory-Test.dat");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LoadDirectoryInfo()
        {
            SaveDirectoryInfo();

            var d = IO.LoadDirectory(@"SavedDirectory-Test.dat");
            Assert.IsNotNull(d);
            Assert.IsTrue(d.Path == @"C:\PerfLogs");
        }

        [TestMethod]
        public void DirectoryExists()
        {
            var di = new System.IO.DirectoryInfo("uuu");
            Assert.IsFalse(di.Exists);
        }

        [TestMethod]
        public void GetStats()
        {
            var d = new DDFinder.Services.DuplicateScanner.Directory(@".", true); 

            var dupStats = new DDFinder.Services.DuplicateScanner.Statistics.DuplicateFiles(d);
            var differentDuplicates = dupStats.GetDuplicatesByHash;
            Assert.IsTrue(differentDuplicates.Count == 2);

        }

        [TestMethod]
        public void GetStatsPerformance()
        {
            System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Lowest;
            var t = new System.Diagnostics.Stopwatch();
            t.Start();

            //// use to init file
            //var d = new DDFinder.Services.DuplicateScanner.Directory(@"C:\");
            //IO.Save(d, @"SavedDirectory-Test-C-2.dat");

            var d = IO.LoadDirectory(@"SavedDirectory-Test-C-2.dat");

            var dupStats = new DDFinder.Services.DuplicateScanner.Statistics.DuplicateFiles(d);
            var differentDuplicates = dupStats.GetDuplicatesByHash;
            
            t.Stop();
            Console.WriteLine("duplicates: " + differentDuplicates.Count);
            Console.WriteLine("elapsed time: " + (t.ElapsedMilliseconds / 1000f).ToString("#.0"));
        }

		[TestMethod]
		public void DriveInfo()
		{
			var d = Drive.GetDrive("C");
			Assert.IsNotNull(d);
		}
    }
}
