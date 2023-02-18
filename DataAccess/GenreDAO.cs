using BusinessObjects;
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
					listGenres = context.Genres.ToList();
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
					context.Genres.Add(genre);
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
