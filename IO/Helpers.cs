namespace DDFinder.Services.IO
{
	public static class Helpers
	{
		public readonly static char[] IllegalFilenameChars =
				new[] { '<', '>', ':', '"', '/', '\\', '|', '?', '*' };

		/// <summary>
		/// Replace illegal characters with _
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public static string MakeSafe(string fileName)
		{
			foreach (var c in IllegalFilenameChars)
			{
				fileName = fileName.Replace(c, '_');
			}
			return fileName;
		}
	}
}
