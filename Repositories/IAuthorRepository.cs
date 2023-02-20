using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public interface IAuthorRepository
	{
		List<Author> GetAuthors();
		Author GetAuthorById(int id);
		void SaveAuthor(Author author);
		void UpdateAuthor(Author author);
		void DeleteAuthor(Author author);
	}
}
