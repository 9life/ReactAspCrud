using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReactAspBooks.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using ReactAspBooks.Services;

namespace ReactAspBooks.Controllers
{
	[ApiController]
	[Route("api")]
	public class BookController : Controller
	{
		//private readonly ILogger<BookController> _logger;
		//private readonly CrudBookContext _context;

		////static readonly List<Books> books;

		////static BookController()
		////{
		////	books = new List<Books>
		////	{
		////		new Books {BookId = Convert.ToInt32(Guid.NewGuid()), BookName="Master and Margarita", AuthorName="M.Bulgakov"},
		////		new Books {BookId = Convert.ToInt32(Guid.NewGuid()), BookName="Idiot", AuthorName="F.Dostoevsky"}
		////	};
		////}
		//public BookController (ILogger<BookController> logger, CrudBookContext context)
		//{
		//	_logger = logger;
		//	_context = context;
		//}

		//[HttpGet]
		//[Route("books")]
		//public List<Books> GetAllBooks() => _context.getBooks();

		//[HttpPost]
		//[Route("book")]
		//[AllowAnonymous]
		//public IActionResult AddBook([FromBody] Books book)
		//{
		//	_logger.LogInformation($"Add Book for BookId: {book.BookId}");
		//	_context.AddBook(book);
		//	return Ok(book);
		//}

		private readonly BookService _bookService;
		public BookController(BookService bookService)
		{
			_bookService = bookService;
		}

		//Return Collection of Values
		// GET api/books  
		[Route("books")]
		[HttpGet]
		public IEnumerable<Books> GetAllBooks()
		{
			return _bookService.GetAllBooks();
		}

		[HttpPost]
		[Route("book/create")]
		public int CreateBook(Books book)
		{
			return _bookService.AddBook(book);
		}

		[HttpGet]
		[Route("book/details/{id}")]
		public Books BookDetails(int id)
		{
			return _bookService.GetBookInfo(id);
		}

		[HttpDelete]
		[Route("book/delete/{id}")]
		public int Delete(int id)
		{
			return _bookService.DeleteBook(id);
		}

		////Return Value  
		//// GET api/values/5  
		//public string Get(int id)
		//{
		//	return "value";
		//}

		////Receive the value and post it  
		//// POST api/values  
		//public void Post([FromBody]string value)
		//{
		//}

		////Receive the value and update it  
		//// PUT api/values/5  
		//public void Put(int id, [FromBody]string value)
		//{
		//}

		////Delete the value  
		//// DELETE api/values/5  
		//public void Delete(int id)
		//{
		//}

	}
}
