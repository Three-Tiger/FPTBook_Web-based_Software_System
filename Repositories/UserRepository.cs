﻿using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class UserRepository : IUserRepository
	{
		public List<Book> DisplayBooksInShop() => UserDAO.DisplayBooksInShop();
		public List<Genre> DisplayGenresInShop() => UserDAO.DisplayGenresInShop();
	}
}
