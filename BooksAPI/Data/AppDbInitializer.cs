using BooksAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Data
{
	public class AppDbInitializer
	{
		public static void Seed(IApplicationBuilder applicationBuilder) 
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) 
			{
				var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
				if (!context.Books.Any()) 
				{
					var books = new List<Book>();
					books.Add(new Book()
					{
						Title = "First book title",
						Description = "First book description",
						IsRead = true,
						DateRead = DateTime.Now.AddDays(-10),
						Rate = 4,
						Genre = "Biography",
						//Author ="First author",
						CoverUrl ="first book link",
						DateAdded=DateTime.Now,
						PublisherId=1
					}) ;
					books.Add(new Book()
					{
						Title = "2nd book title",
						Description = "2nd book description",
						IsRead = false,
						Genre = "Biography",
						//Author = "first author",
						CoverUrl = "second book link",
						DateAdded = DateTime.Now,
						PublisherId=1
					});

					context.Books.AddRange(books);
					context.SaveChanges();
				}
			}
		}
	}
}
