using BooksAPI.Data.Models;
using BooksAPI.Data.ViewModels;
using BooksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Data.Services
{
	public class BooksService
	{
		private readonly AppDbContext _context;
		public BooksService(AppDbContext context)
		{
			_context = context;
		}

		public List<Book> GetAllBooks() 
		{
			var books = _context.Books.ToList();
			return books;
		}

		public Book GetBookById(int id) 
		{
			var book = _context.Books.FirstOrDefault(b => b.Id == id);
			return book;
		}

		public void AddBookWithAuthor(BookVM book) 
		{
			var _book = new Book()
			{
				Title=book.Title,
				Description = book.Description,
				IsRead = book.IsRead,
				DateRead = book.IsRead ? book.DateRead.Value:null,
				Rate = book.IsRead ? book.Rate.Value:null,
				Genre = book.Genre,
				//Author = book.Author,
				CoverUrl = book.CoverUrl,
				DateAdded = DateTime.Now,
				PublisherId = book.PublisherId,
			};
			_context.Books.Add(_book);
			_context.SaveChanges();

			// add data to Book_Author table
			foreach (var id in book.AuthorIds)
			{
				var _book_author = new Book_Author()
				{
					BookId = _book.Id,
					AuthorId = id
				};
				_context.Books_Authors.Add(_book_author);
				_context.SaveChanges();
			}
		}

		public Book UpdateBook(int id,BookVM book) 
		{
			var _book = _context.Books.FirstOrDefault(b => b.Id == id);
			if (book != null) 
			{
				_book.Title = book.Title;
				_book.Description = book.Description;
				_book.IsRead = book.IsRead;
				_book.DateRead = book.IsRead ? book.DateRead.Value : null;
				_book.Rate = book.IsRead ? book.Rate.Value : null;
				_book.Genre = book.Genre;
				//_book.Author = book.Author;
				_book.CoverUrl = book.CoverUrl;

				_context.SaveChanges();
			}
			return _book;
		}

		public void DeleteBook(int id) 
		{
			var book = _context.Books.FirstOrDefault(b => b.Id == id);
			if (book != null) 
			{
				_context.Books.Remove(book);
				_context.SaveChanges();
			}
		}
	}
}
