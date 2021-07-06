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
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorsController : ControllerBase
	{
		private AuthorsService _service;
		public AuthorsController(AuthorsService service)
		{
			_service = service;
		}

		[HttpGet("get-author-books-by-id/{id}")]
		public IActionResult GetAuthorWithBooks(int id) 
		{
			var author = _service.GetAuthorWithBooks(id);
			return Ok(author);
		}

		[HttpPost("add-author")]
		public IActionResult AddAuthor([FromBody]AuthorVM author) 
		{
			_service.AddAuthor(author);
			return Ok();
		}
	}
}
