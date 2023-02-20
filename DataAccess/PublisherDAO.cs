using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class PublisherDAO
	{
		public static List<Publisher> GetPublishers()
		{
			var listPublishers = new List<Publisher>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					listPublishers = context.Publishers.Where(x => x.IsDeleted == false).ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return listPublishers;
		}

		public static Publisher FindPublisherById(int publisherID)
		{
			Publisher publisher = new Publisher();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					publisher = context.Publishers.SingleOrDefault(x => x.PublisherId == publisherID);
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return publisher;
		}

		public static void SavePublisher(Publisher publisher)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					var obj = context.Publishers.SingleOrDefault(x => x.PublisherName == publisher.PublisherName || x.PublisherPhone == publisher.PublisherPhone || x.PublisherMail == publisher.PublisherMail);
					if (obj != null)
					{
						obj.IsDeleted = false;
						context.Entry<Publisher>(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					}
					else
					{
						context.Publishers.Add(publisher);
					}
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public static void UpdatePublisher(Publisher publisher)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					context.Entry<Publisher>(publisher).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public static void DeletePublisher(Publisher publisher)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					var p = context.Publishers.SingleOrDefault(c => c.PublisherId == publisher.PublisherId);
					//context.Genres.Remove(c);
					p.IsDeleted = true;
					context.Entry<Publisher>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
