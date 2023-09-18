using BusinessObjects;

namespace Repositories.Interfaces
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
