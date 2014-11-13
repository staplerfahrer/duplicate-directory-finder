namespace DDFinder.Business.Definitions
{
	public static class FileSizeRanges
	{
		public static long[][] Ranges = new[] 
		{
			// 1 GiB +
			new[] {1024L * 1024L * 1024L, long.MaxValue},
			// 1 MiB - 1 GiB
			new[] {1024L * 1024L, 1024L * 1024L * 1024L - 1L},
			// 1 kiB - 1 MiB
			new[] {1024L, 1024L * 1024L - 1L},
			// 0 B - 1 kiB
			new[] {0L, 1024L - 1L},
		};

		public static string[] Labels = new[]
		{
			"GiB",
			"MiB",
			"kiB",
			"B",
		};
	}
}
