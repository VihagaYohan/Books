using BooksAPI.Data.Models;
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
	}
}
