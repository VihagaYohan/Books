using BooksAPI.Data.Models;
using BooksAPI.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Data.Services
{
	public class PublishersService
	{
		private readonly AppDbContext _context;

		public PublishersService(AppDbContext context)
		{
			_context = context;
		}

		// get all publishers
		public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
		{
			var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
				.Select(n => new PublisherWithBooksAndAuthorsVM()
				{
					PublisherName = n.Name,
					BookAuthors = n.Books.Select(n => new BookAuthorVM()
					{
						BookName = n.Title,
						BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
					}).ToList()
				}).FirstOrDefault();

			return _publisherData;
		}

		// add new publisher
		public void AddPublisher(PublisherVM publisher) 
		{
			var _publisher = new Publisher()
			{
				Name = publisher.Name
			};
			_context.Publishers.Add(_publisher);
			_context.SaveChanges();
		}
	}
}
