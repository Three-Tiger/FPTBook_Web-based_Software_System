using BusinessObjects;

namespace Repositories
{
	public interface IUserRepository
	{
		List<AppUser> GetMembers();
		AppUser FindAccountById(string memberId);
		List<AppUser> GetOwners();
	}
}
