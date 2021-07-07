using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Exceptions
{
	public class PublishernameException:Exception
	{
		public string PublisherName { get; set; }

		public PublishernameException()
		{

		}

		public PublishernameException(string message):base(message)
		{

		}

		public PublishernameException(string message,Exception inner):base(message,inner)
		{

		}

		public PublishernameException(string message, string publisherName):base(message)
		{
			PublisherName = publisherName;
		}
	}
}
