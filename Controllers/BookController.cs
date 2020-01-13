using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReactAspBooks.Models;
using Microsoft.Extensions.Logging;

namespace ReactAspBooks.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BookController : Controller
	{
		private readonly ILogger<BookController> _logger;
		private readonly CrudBookContext _context;

		public BookController (ILogger<BookController> logger, CrudBookContext context)
		{
			_logger = logger;
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllBooks()
		{
			List<Books> books = _context.getBooks();
			return Ok(books);
		}

	}
}
