using BusinessObjects;
using BusinessObjects.Constraints;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class UserDAO
	{
		public static List<Book> DisplayBooksInShop()
		{
			var listBooks = new List<Book>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					//listBooks = context.Books.Where(x => x.IsDeleted == false).Include(t => t.GenreId).ToList();
					listBooks = context.Books.Include(g => g.Genre).Where(x => x.IsDeleted == false).ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return listBooks;
		}

		public static Book DisplayBooksDetail(int bookID)
		{
			Book book = new Book();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					book = context.Books.Where(x => x.IsDeleted == false).SingleOrDefault(c => c.BookId == bookID);
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return book;
		}

		public static List<Genre> DisplayGenresInShop()
		{
			var listGenres = new List<Genre>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					listGenres = context.Genres.Where(x => x.IsDeleted == false && x.Status == GenreApproval.Approved).OrderBy(b => b.GenreName).ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return listGenres;
		}
	}
}
