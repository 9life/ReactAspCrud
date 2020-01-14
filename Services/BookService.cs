using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReactAspBooks.Models;

namespace ReactAspBooks.Services
{
	public class BookService
	{
		readonly CrudBookContext _db;

		public BookService(CrudBookContext db)
		{
			_db = db;
		}

		public IEnumerable<Books> GetAllBooks()
		{
			try
			{
				return _db.Books.ToList();
			}
			catch
			{ throw; }
		}

		//To Add new book record
		public int AddBook(Books book)
		{
			try
			{
				_db.Books.Add(book);
				_db.SaveChanges();
				return 1;
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
		public int DeleteBook(int id)
		{
			try 
			{
				Books book = _db.Books.Find(id);
				_db.Books.Remove(book);
				_db.SaveChanges();
				return 1;
			}
			catch
			{
				throw;
			}
		}
	}
}
