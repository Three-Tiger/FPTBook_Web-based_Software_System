using BusinessObjects;
using BusinessObjects.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class GenreDAO
	{
		public static List<Genre> GetGenres()
		{
			var listGenres = new List<Genre>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					listGenres = context.Genres.Where(x => x.IsDeleted == false && x.Status == GenreApproval.Pending).ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return listGenres;
		}

		public static List<Genre> GetApprovelGenres()
		{
			var listGenres = new List<Genre>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					listGenres = context.Genres.Where(x => x.IsDeleted == false && x.Status == GenreApproval.Approved).ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return listGenres;
		}

		public static Genre FindGenreById(int genreID)
		{
			Genre genre = new Genre();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					genre = context.Genres.SingleOrDefault(x => x.GenreId == genreID);
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return genre;
		}

		public static void SaveGenre(Genre genre)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					var obj = context.Genres.SingleOrDefault(x => x.GenreName == genre.GenreName || x.GenreDescription == genre.GenreDescription);
					if (obj != null)
					{
						obj.IsDeleted = false;
						obj.Status= GenreApproval.Pending;
						context.Entry<Genre>(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					}
					else
					{
						genre.Status = GenreApproval.Pending;
						context.Genres.Add(genre);
					}
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public static void UpdateGenre(Genre genre)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					context.Entry<Genre>(genre).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public static void ApprovelGenre(Genre genre)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					var g = context.Genres.SingleOrDefault(c => c.GenreId == genre.GenreId);
					g.Status = GenreApproval.Approved;
					context.Entry<Genre>(g).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public static void RejectGenre(Genre genre)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					var g = context.Genres.SingleOrDefault(c => c.GenreId == genre.GenreId);
					g.Status = GenreApproval.Rejected;
					context.Entry<Genre>(g).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public static void DeleteGenre(Genre genre)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					var g = context.Genres.SingleOrDefault(c => c.GenreId == genre.GenreId);
					//context.Genres.Remove(c);
					g.IsDeleted = true;
					context.Entry<Genre>(g).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
