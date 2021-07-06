using BooksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Data.Models
{
	public class Book_Author
	{
		// adding many to many relationship
		public int Id { get; set; }
		public int BookId { get; set; }
		public Book Book { get; set; }

		public int AuthorId { get; set; }
		public Author Author { get; set; }
	}
}
