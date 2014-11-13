namespace DDFinder.Services.IO.Poco
{
	using System;

	/// <summary>
	/// I can only have a message or a result object.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class IOResult<T>
	{
		private T @object;
		private string message;

		public IOResult(T @object)
		{
			this.@object = @object;
		}

		public IOResult(string message)
		{
			this.message = message;
		}

		public T Object 
		{ 
			get
			{
				return @object;
			}

			set
			{
				if (message != null)
				{
					throw new Exception("Message should be null.");
				}
				else
				{
					@object = value;
				}
			}
		}

		public string Message
		{
			get
			{
				return message;
			}

			set
			{
				if (@object != null)
				{
					throw new Exception("Object should be null.");
				}
				else
				{
					message = value;
				}
			}
		}
	}
}
