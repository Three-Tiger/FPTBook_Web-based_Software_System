using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class GenreRepository : IGenreRepository
	{
		public List<Genre> GetGenres() => GenreDAO.GetGenres();
		public Genre GetGenreById(int id) => GenreDAO.FindGenreById(id);
		public void SaveGenre(Genre genre) => GenreDAO.SaveGenre(genre);
		public void UpdateGenre(Genre genre) => GenreDAO.UpdateGenre(genre);
		public void DeleteGenre(Genre genre) => GenreDAO.DeleteGenre(genre);
	}
}
