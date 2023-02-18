using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class AuthorRepository : IAuthorRepository
	{
		public List<Author> GetAuthors() => AuthorDAO.GetAuthors();
		public Author GetAuthorById(int id) => AuthorDAO.FindAuthorById(id);
		public void SaveAuthor(Author author) => AuthorDAO.SaveAuthor(author);
		public void UpdateAuthor(Author author) => AuthorDAO.UpdateAuthor(author);
		public void DeleteAuthor(Author author) => AuthorDAO.DeleteAuthor(author);
	}
}
