using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReactAspBooks.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ReactAspBooks.Services
{
	public class BookService : IBookService
	{
		private readonly CrudBookContext _db;

		public BookService(CrudBookContext db)
		{
			_db = db;
		}

		public List<Books> GetAllBooks()
		{
			try
			{
				var books = _db.Books.ToList();

				return books;//_db.Books.ToList();
			}
			catch
			{ throw; }
		}

		//To Add new book record
		public Books CreateBook(Books book)
		{
			try
			{
				var id = _db.Books.Count() + 1;

				Books newbook = new Books();
				newbook.Id = id;
				newbook.bookName = book.bookName;
				newbook.authorName = book.authorName;

				_db.Books.Add(newbook);
				_db.SaveChanges();
				return newbook;
			}
			catch
			{ throw; }
		}

		//Get the details of a particular book
		public Books GetBookInfo(int id)
		{
			try
			{
				Books book = _db.Books.Find(id);
				return book;
			}
			catch
			{ throw; }
		}

		//To Delete the record of a particular book
		public string DeleteBook(int id)
		{
			try 
			{
				Books book = _db.Books.Find(id);
				_db.Books.Remove(book);
				_db.SaveChanges();
				return "Book was deleted";
			}
			catch
			{
				throw;
			}
		}
	}
}
