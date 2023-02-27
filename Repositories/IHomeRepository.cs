using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public interface IHomeRepository
	{
		List<Book> Gallery();
		List<Book> BestSelling();
		List<Book> DisplayBooksInShop();
		Book DisplayBooksDetail(int bookID);
		List<Genre> DisplayGenresInShop();
		List<Author> DisplayAuthorsInShop();
		List<Publisher> DisplayPublishersInShop();
		List<Book> DisplayBooksInShopByGenre(int genreId);
		List<Book> DisplayBooksInShopByAuthor(int authorId);
	}
}
