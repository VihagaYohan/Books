using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Data.ViewModels
{
	public class AuthorWithBooksVM
	{
		public string FullName { get; set; }
		public List<string> BookTitles { get; set; }
	}
}
