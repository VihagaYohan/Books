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

		// get publisher by ID
		public Publisher GetPublisherById(int id) 
		{
			var publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
			return publisher;
		}

		// add new publisher
		public Publisher AddPublisher(PublisherVM publisher) 
		{
			var _publisher = new Publisher()
			{
				Name = publisher.Name
			};
			_context.Publishers.Add(_publisher);
			_context.SaveChanges();

			return _publisher;
		}

		// delete publisher with related data
		public void DeletePublisherById(int id)
		{
			var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
			if (_publisher != null)
			{
				_context.Publishers.Remove(_publisher);
				_context.SaveChanges();
			}
			else 
			{
				throw new Exception($"The publisher with the ID : {id} does not exists");
			}
		}
	}
}
