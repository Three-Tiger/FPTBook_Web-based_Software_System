using BusinessObjects;

namespace Repositories.Interfaces
{
    public interface IContactRepository
    {
        List<Contact> GetContacts();
        Contact GetContactById(int id);
        void SaveContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(Contact contact);
    }
}
