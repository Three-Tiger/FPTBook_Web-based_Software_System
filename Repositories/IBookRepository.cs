using BusinessObjects;

namespace Repositories
{
	public interface IBookRepository
	{
		List<Book> GetBooks();
		Book GetBookById(int id);
		void SaveBook(Book book);
		void UpdateBook(Book book);
		void DeleteBook(Book book);
	}
}
