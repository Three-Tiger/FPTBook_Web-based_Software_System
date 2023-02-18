using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public interface IGenreRepository
	{
		List<Genre> GetGenres();
		Genre GetGenreById(int id);
		void SaveGenre(Genre genre);
		void UpdateGenre(Genre genre);
		void DeleteGenre(Genre genre);
	}
}
