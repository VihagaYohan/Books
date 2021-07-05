using BooksAPI.Data.Services;
using BooksAPI.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Controllers
{
	[Route("api/[controller]")] // API routes defines here
	[ApiController]
	public class BooksController : ControllerBase
	{
		public BooksService _service;
		public BooksController(BooksService service)
		{
			_service = service;
		}

		[HttpGet("get-all-books")]
		public IActionResult GetAllBooks() 
		{
			var books = _service.GetAllBooks();
			return Ok(books);
		}

		[HttpGet("get-book-by-id/{id}")]
		public IActionResult GetBookById(int id) 
		{
			var book = _service.GetBookById(id);
			return Ok(book);
		}

		[HttpPost("add-book")]
		public IActionResult AddBook([FromBody]BookVM book) 
		{
			_service.AddBook(book);
			return Ok();
		}

		[HttpPut("update-book-by-id/{bookId}")]
		public IActionResult UpdateBook(int bookId,[FromBody] BookVM book) 
		{
			var result = _service.UpdateBook(bookId, book);
			return Ok(result);
		}

		[HttpDelete("delete-book-by-id/{id}")]
		public IActionResult DeleteBook(int id) 
		{
			 _service.DeleteBook(id);
			return Ok();
		}
	}
}
