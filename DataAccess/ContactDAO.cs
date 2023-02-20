using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class ContactDAO
	{
		public static List<Contact> GetContacts()
		{
			var listContacts = new List<Contact>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					listContacts = context.Contacts.Where(x => x.IsDeleted == false).ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return listContacts;
		}

		public static Contact FindContactById(int contactID)
		{
			Contact contact = new Contact();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					contact = context.Contacts.SingleOrDefault(x => x.ContactId == contactID);
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return contact;
		}

		public static void SaveContact(Contact contact)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					context.Contacts.Add(contact);
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public static void UpdateContact(Contact contact)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					context.Entry<Contact>(contact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public static void DeleteContact(Contact contact)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					var c = context.Contacts.SingleOrDefault(c => c.ContactId == contact.ContactId);
					//context.Genres.Remove(c);
					c.IsDeleted = true;
					context.Entry<Contact>(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
	}
}
