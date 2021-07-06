using BooksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Data.Models
{
	public class Publisher
	{
		public int Id { get; set; }
		public string Name { get; set; }
		// navigation properties
		public IEnumerable<Book> Books { get; set; }
	}
}
