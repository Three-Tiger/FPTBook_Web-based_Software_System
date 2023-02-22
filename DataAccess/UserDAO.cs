using BusinessObjects;
using BusinessObjects.Constraints;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class UserDAO
	{
		public static List<AppUser> GetMembers()
		{
			var lstMembers = new List<AppUser>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					lstMembers = (from user in context.Users
								 join userRole in context.UserRoles on user.Id equals userRole.UserId
								 join role in context.Roles on userRole.RoleId equals role.Id
								 where role.Name == Roles.User.ToString() select user).ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return lstMembers;
		}

		public static AppUser FindAccountById(string memberId)
		{
			AppUser appUser = new AppUser();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					appUser = context.Users.Where(u => u.Id == memberId).FirstOrDefault();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return appUser;
		}

		public static List<AppUser> GetOwners()
		{
			var lstMembers = new List<AppUser>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					lstMembers = (from user in context.Users
								  join userRole in context.UserRoles on user.Id equals userRole.UserId
								  join role in context.Roles on userRole.RoleId equals role.Id
								  where role.Name == Roles.Owner.ToString()
								  select user).ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return lstMembers;
		}
	}
}
