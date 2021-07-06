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
		//public IEnumerable<Publisher> GetAllPublishers() 
		//{
		//	return;
		//}

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
