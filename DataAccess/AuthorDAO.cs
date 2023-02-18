using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class AuthorDAO
	{
		public static List<Author> GetAuthors()
		{
			var listAuthors = new List<Author>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					listAuthors = context.Authors.ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return listAuthors;
		}

		public static Author FindAuthorById(int authorID)
		{
			Author author = new Author();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					author = context.Authors.SingleOrDefault(x => x.AuthorId == authorID);
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return author;
		}

		public static void SaveAuthor(Author author)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					context.Authors.Add(author);
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public static void UpdateAuthor(Author author)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					context.Entry<Author>(author).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public static void DeleteAuthor(Author author)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					//var g = context.Genres.SingleOrDefault(c => c.GenreId == genre.GenreId);
					//context.Genres.Remove(c);
					author.IsDeleted = true;
					context.Entry<Author>(author).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
