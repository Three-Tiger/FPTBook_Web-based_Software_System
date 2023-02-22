using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public interface IUserRepository
	{
		List<AppUser> GetMembers();
		AppUser FindMemberById(string memberId);
		List<AppUser> GetOwners();
	}
}
