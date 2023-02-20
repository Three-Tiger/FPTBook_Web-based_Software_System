using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class BookRepository : IBookRepository
	{
		public List<Book> GetBooks() => BookDAO.GetBooks();
		public Book GetBookById(int id) => BookDAO.FindBookById(id);
		public void SaveBook(Book book) => BookDAO.SaveBook(book);
		public void UpdateBook(Book book) => BookDAO.UpdateBook(book);
		public void DeleteBook(Book book) => BookDAO.DeleteBook(book);
	}
}
