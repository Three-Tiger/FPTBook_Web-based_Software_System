using BusinessObjects;

namespace Repositories.Interfaces
{
    public interface IHomeRepository
    {
        List<Book> Gallery();
        List<Book> BestSelling();
        List<Book> DisplayBooksInShop();
        List<Book> Search(string value);
        Book DisplayBooksDetail(int bookID);
        List<Genre> DisplayGenresInShop();
        List<Author> DisplayAuthorsInShop();
        List<Publisher> DisplayPublishersInShop();
        List<Book> DisplayBooksInShopByGenre(int genreId);
        List<Book> DisplayBooksInShopByAuthor(int authorId);
    }
}
