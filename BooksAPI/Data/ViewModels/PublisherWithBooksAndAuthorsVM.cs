using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Data.ViewModels
{
	public class PublisherWithBooksAndAuthorsVM
	{
		public string PublisherName { get; set; }
		public List<BookAuthorVM> BookAuthors { get; set; }
	}
}
