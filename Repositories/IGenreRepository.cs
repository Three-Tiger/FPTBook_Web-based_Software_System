using BusinessObjects;

namespace Repositories
{
	public interface IGenreRepository
	{
		List<Genre> GetGenres();
		List<Genre> GetApprovelGenres();
		Genre GetGenreById(int id);
		void SaveGenre(Genre genre);
		void ApprovelGenre(Genre genre);
		void RejectGenre(Genre genre);
		void UpdateGenre(Genre genre);
		void DeleteGenre(Genre genre);
	}
}
