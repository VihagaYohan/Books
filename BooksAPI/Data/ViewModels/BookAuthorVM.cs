using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Data.ViewModels
{
	public class BookAuthorVM
	{
		public string BookName { get; set; }
		public List<string> BookAuthors { get; set; }
	}
}
