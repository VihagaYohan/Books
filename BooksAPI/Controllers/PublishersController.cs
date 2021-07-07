using BooksAPI.Data.Services;
using BooksAPI.Data.ViewModels;
using BooksAPI.Exceptions;
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

		[HttpGet("get-publisher-by-id/{id}")]
		public IActionResult GetPublisherById(int id)
		{
			var result = _service.GetPublisherById(id);
			if (result != null) 
			{
				return Ok(result);
			}
			return NotFound();
		}

		[HttpPost("add-publisher")]
		public IActionResult AddPublisher([FromBody]PublisherVM publisher) 
		{
			throw new Exception("This is an exception that will be handeled by middleware");
			try
			{
				var newPublisher = _service.AddPublisher(publisher);
				return Created(nameof(AddPublisher), newPublisher);
			}
			catch (PublishernameException ex) 
			{
				return BadRequest($"{ex.Message}, Publisher name: ${ex.PublisherName}");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			
		}

		[HttpDelete("delete-publisher-by-id/{id}")]
		public IActionResult DeletePublisherById(int id) 
		{
			try
			{
				_service.DeletePublisherById(id);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			
		}
	}
}
