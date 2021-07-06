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
	public class PublishersController : ControllerBase
	{
		private readonly PublishersService _service;
		public PublishersController(PublishersService service)
		{
			_service = service;
		}

		[HttpGet("get-publisher-books-with-authors/{id}")]
		public IActionResult GetPublisherData(int id) 
		{
			var result = _service.GetPublisherData(id);
			return Ok(result);
		}

		[HttpPost("add-publisher")]
		public IActionResult AddPublisher([FromBody]PublisherVM publisher) 
		{
			_service.AddPublisher(publisher);
			return Ok();
		}

		[HttpDelete("delete-publisher-by-id/{id}")]
		public IActionResult DeletePublisherById(int id) 
		{
			_service.DeletePublisherById(id);
			return Ok();
		}
	}
}
