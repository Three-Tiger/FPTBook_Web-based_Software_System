using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
	public class AppUser : IdentityUser
	{
		[Required(ErrorMessage = "First name can not empty!")]
		public string? FirstName { get; set; }
		[Required(ErrorMessage = "Last name can not empty!")]
		public string? LastName { get; set; }
		[Required(ErrorMessage = "Please choose your gender!")]
		public bool? Gender { get; set; }
		[Required(ErrorMessage = "Please choose your birthday!")]
		public DateTime? Birthday { get; set; }
		[Required(ErrorMessage = "Address can not empty!")]
		public string? Address { get; set; }
		public string? ProfilePicture { get; set; }
		public bool? IsDeleted { get; set; }
		public virtual ICollection<Order>? Orders { get; set; }
		public virtual ICollection<Feedback>? Feedbacks { get; set; }
	}
}
