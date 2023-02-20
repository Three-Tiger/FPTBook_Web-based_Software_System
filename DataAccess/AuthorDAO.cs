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
					listAuthors = context.Authors.Where(x => x.IsDeleted == false).ToList();
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
					var obj = context.Authors.SingleOrDefault(x => x.AuthorName == author.AuthorName || x.AuthorMail== author.AuthorMail || x.AuthorPhone == author.AuthorPhone);
					if (obj != null)
					{
						obj.IsDeleted = false;
						context.Entry<Author>(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					}
					else
					{
						context.Authors.Add(author);
					}
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
					var a = context.Authors.SingleOrDefault(c => c.AuthorId == author.AuthorId);
					//context.Genres.Remove(c);
					a.IsDeleted = true;
					context.Entry<Author>(a).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
