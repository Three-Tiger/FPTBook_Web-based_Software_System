using BusinessObjects;
using DataAccess;

namespace Repositories
{
	public class UserRepository : IUserRepository
	{
		public List<AppUser> GetMembers() => UserDAO.GetMembers();
		public AppUser FindAccountById(string memberId) => UserDAO.FindAccountById(memberId);
		public List<AppUser> GetOwners() => UserDAO.GetOwners();
	}
}
