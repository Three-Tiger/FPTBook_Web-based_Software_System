using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class HomeRepository : IHomeRepository
	{
		public List<Book> DisplayBooksInShop() => HomeDAO.DisplayBooksInShop();
		public Book DisplayBooksDetail(int bookID) => HomeDAO.DisplayBooksDetail(bookID);
		public List<Genre> DisplayGenresInShop() => HomeDAO.DisplayGenresInShop();
		public List<Author> DisplayAuthorsInShop() => HomeDAO.DisplayAuthorsInShop();
		public List<Publisher> DisplayPublishersInShop() => HomeDAO.DisplayPublishersInShop();
	}
}
