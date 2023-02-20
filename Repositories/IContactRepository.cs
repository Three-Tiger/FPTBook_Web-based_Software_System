using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
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
