using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Statistics.Poco
{
	/// <summary>
	/// I can only have a message or a result object.
	/// </summary>
	/// <typeparam name="TObject"></typeparam>
	public class IOResult<TObject>
	{
		public IOResult()
		{
		}

		private string message;
		public string Message 
		{
			get
			{
				return message;
			} 

			set 
			{
				if (_object != null)
				{
					throw new Exception("Object should be null.");
				}
				else
				{
					message = value;
				}
			}
		}

		private TObject _object;
		public TObject Object 
		{ 
			get
			{
				return _object;
			}

			set
			{
				if (message != null)
				{
					throw new Exception("Message should be null.");
				}
				else
				{
					_object = value;
				}
			}
		}
	}
}
