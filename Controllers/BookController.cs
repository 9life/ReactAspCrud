﻿using Microsoft.AspNetCore.Mvc;
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
	[Route("api")]
	[Produces("application/json")]
	public class BookController : Controller
	{
		private readonly IBookService _bookService;
		public BookController(IBookService bookService)
		{
			_bookService = bookService;
		}

		//Return Collection of Values
		// GET api/books  
		[HttpGet]
		[Route("books")]
		public IEnumerable<Books> GetAllBooks()
		{
			return _bookService.GetAllBooks();
		}

		[HttpPost]
		[Route("book/create")]
		public string CreateBook(Books book)
		{
			_bookService.CreateBook(book);
			return "Book was added";

		}

		[HttpGet]
		[Route("book/details/{id}")]
		public Books BookDetails(int id)
		{
			return _bookService.GetBookInfo(id);
		}

		[HttpDelete]
		[Route("book/delete/{id}")]
		public IActionResult Delete(int id)
		{
			var result = _bookService.DeleteBook(id);
			return Ok(result);
		}
	}
}
