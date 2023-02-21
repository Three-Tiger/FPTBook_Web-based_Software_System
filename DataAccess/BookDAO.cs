using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class BookDAO
	{
		public static List<Book> GetBooks()
		{
			var listBooks = new List<Book>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					//listBooks = context.Books.Where(x => x.IsDeleted == false).ToList();
					listBooks = context.Books.Include(b => b.Genre).Include(b => b.Author).Include(b => b.Publisher).Where(b => b.IsDeleted == false).ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return listBooks;
		}

		public static Book FindBookById(int bookID)
		{
			Book book = new Book();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					book = context.Books.SingleOrDefault(x => x.BookId == bookID);
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return book;
		}

		public static void SaveBook(Book book)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					var obj = context.Books.SingleOrDefault(x => x.BookTitle == book.BookTitle);
					if (obj != null)
					{
						obj.IsDeleted = false;
						context.Entry<Book>(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					}
					else
					{
						context.Books.Add(book);
					}
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public static void UpdateBook(Book book)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					context.Entry<Book>(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public static void DeleteBook(Book book)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					var b = context.Books.SingleOrDefault(c => c.BookId == book.BookId);
					//context.Genres.Remove(c);
					b.IsDeleted = true;
					context.Entry<Book>(b).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
	}
}
