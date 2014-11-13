namespace DDFinder.Extensions
{
	public static class StringExtensions
    {
		public static string JoinWith(this string in1, string separator, string in2)
		{
			if (string.IsNullOrEmpty(in1)) return in2;
			return string.Concat(in1, separator, in2);
		}
    }
}
