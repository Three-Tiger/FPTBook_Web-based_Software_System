using BusinessObjects;
using DataAccess;

namespace Repositories
{
	public class ContactRepository : IContactRepository
	{
		public List<Contact> GetContacts() => ContactDAO.GetContacts();
		public Contact GetContactById(int id) => ContactDAO.FindContactById(id);
		public void SaveContact(Contact contact) => ContactDAO.SaveContact(contact);
		public void UpdateContact(Contact contact) => ContactDAO.UpdateContact(contact);
		public void DeleteContact(Contact contact) => ContactDAO.DeleteContact(contact);
	}
}
