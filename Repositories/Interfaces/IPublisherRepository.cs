﻿using BusinessObjects;

namespace Repositories.Interfaces
{
    public interface IPublisherRepository
    {
        List<Publisher> GetPublishers();
        Publisher GetPublisherById(int id);
        void SavePublisher(Publisher publisher);
        void UpdatePublisher(Publisher publisher);
        void DeletePublisher(Publisher publisher);
    }
}
