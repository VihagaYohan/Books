using BooksAPI.Data.Models;
using BooksAPI.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Data.Services
{
	public class AuthorsService
	{
		private readonly AppDbContext _context;
		public AuthorsService(AppDbContext context)
		{
			_context = context;
		}

		public void AddAuthor(AuthorVM author) 
		{
			var _author = new Author()
			{
				FullName = author.FullName
			};
			_context.Authors.Add(_author);
			_context.SaveChanges();
		}
	}
}
