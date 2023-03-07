using BusinessObjects;
using DataAccess;

namespace Repositories
{
	public class PublisherRepository : IPublisherRepository
	{
		public List<Publisher> GetPublishers() => PublisherDAO.GetPublishers();
		public Publisher GetPublisherById(int id) => PublisherDAO.FindPublisherById(id);
		public void SavePublisher(Publisher publisher) => PublisherDAO.SavePublisher(publisher);
		public void UpdatePublisher(Publisher publisher) => PublisherDAO.UpdatePublisher(publisher);
		public void DeletePublisher(Publisher publisher) => PublisherDAO.DeletePublisher(publisher);
	}
}
