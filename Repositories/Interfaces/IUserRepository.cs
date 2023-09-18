using BusinessObjects;

namespace Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<AppUser> GetMembers();
        AppUser FindAccountById(string memberId);
        List<AppUser> GetOwners();
    }
}
