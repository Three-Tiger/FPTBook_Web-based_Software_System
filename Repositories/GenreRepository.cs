using BusinessObjects;
using DataAccess;
using Repositories.Interfaces;

namespace Repositories
{
    public class GenreRepository : IGenreRepository
	{
		public List<Genre> GetGenres() => GenreDAO.GetGenres();
		public List<Genre> GetApprovelGenres() => GenreDAO.GetApprovelGenres();
		public Genre GetGenreById(int id) => GenreDAO.FindGenreById(id);
		public void SaveGenre(Genre genre) => GenreDAO.SaveGenre(genre);
		public void ApprovelGenre(Genre genre) => GenreDAO.ApprovelGenre(genre);
		public void RejectGenre(Genre genre) => GenreDAO.RejectGenre(genre);
		public void UpdateGenre(Genre genre) => GenreDAO.UpdateGenre(genre);
		public void DeleteGenre(Genre genre) => GenreDAO.DeleteGenre(genre);
	}
}
