using BusinessObjects.Constraints;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataAccess
{
	public class HomeDAO
	{
		public static List<Book> DisplayBooksInShop()
		{
			var listBooks = new List<Book>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					//listBooks = context.Books.Where(x => x.IsDeleted == false).Include(t => t.GenreId).ToList();
					listBooks = context.Books.Include(g => g.Genre).Include(a => a.Author).Include(p => p.Publisher).Where(x => x.IsDeleted == false).ToList();
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
			var book = new Book();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					book = context.Books
						.Include(g => g.Genre)
						.Include(a => a.Author)
						.Include(p => p.Publisher)
						.Include(f => f.Feedbacks).ThenInclude(u => u.User)
						.Where(x => x.IsDeleted == false)
						.SingleOrDefault(c => c.BookId == bookID);
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

		public static List<Author> DisplayAuthorsInShop()
		{
			var listAuthors = new List<Author>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					listAuthors = context.Authors.Where(x => x.IsDeleted == false).OrderBy(b => b.AuthorName).ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return listAuthors;
		}

		public static List<Publisher> DisplayPublishersInShop()
		{
			var listPublishers = new List<Publisher>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					listPublishers = context.Publishers.Where(x => x.IsDeleted == false).OrderBy(b => b.PublisherName).ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return listPublishers;
		}

		public static List<Book> DisplayBooksInShopByGenre(int genreId)
		{
			var listBooksByGenre = new List<Book>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					//listBooks = context.Books.Where(x => x.IsDeleted == false).Include(t => t.GenreId).ToList();
					listBooksByGenre = context.Books.Include(g => g.Genre).Include(a => a.Author).Include(p => p.Publisher).Where(x => x.IsDeleted == false && x.GenreId == genreId).ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return listBooksByGenre;
		}

		public static List<Book> DisplayBooksInShopByAuthor(int authorId)
		{
			var listBooksByAuthor = new List<Book>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					//listBooks = context.Books.Where(x => x.IsDeleted == false).Include(t => t.GenreId).ToList();
					listBooksByAuthor = context.Books.Include(g => g.Genre).Include(a => a.Author).Include(p => p.Publisher).Where(x => x.IsDeleted == false && x.AuthorId == authorId).ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return listBooksByAuthor;
		}
	}
}
