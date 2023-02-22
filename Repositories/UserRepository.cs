using BusinessObjects;
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
		public List<AppUser> GetMembers() => UserDAO.GetMembers();
		public AppUser FindAccountById(string memberId) => UserDAO.FindAccountById(memberId);
		public List<AppUser> GetOwners() => UserDAO.GetOwners();
	}
}
