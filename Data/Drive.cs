using System;
using System.Collections.Generic;

namespace DDFinder.Services.DuplicateScanner
{
	public static class Drive
	{
		public static System.IO.DriveInfo GetDrive(string letter)
		{
			if (letter.Length == 0) throw new Exception("drive letter required");
			if (letter.Length == 1) letter += @":\";
			var drives = System.IO.DriveInfo.GetDrives();
			foreach (var d in drives)
			{
				if (d.Name == letter)
					return d;
			}
			return null;
		}

		public static string[] GetDrives()
		{
			var drives = System.IO.DriveInfo.GetDrives();
			var result = new List<string>();
			foreach (var d in drives)
			{
				if (d.DriveType == System.IO.DriveType.Fixed) result.Add(d.Name);
			}
			return result.ToArray();
		}
	}
}
