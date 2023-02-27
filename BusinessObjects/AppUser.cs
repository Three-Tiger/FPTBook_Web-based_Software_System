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
		[Required(ErrorMessage = "The First Name can not empty!")]
		[MinLength(2, ErrorMessage = "The  First Name must be more than 2 character!")]
		[MaxLength(100, ErrorMessage = "The  First Name must be lesser than 10 character!")]
		[RegularExpression(@"^[a-zA-Z''-'\s]*$", ErrorMessage = "The  First Name must be alphabets!")]
		public string? FirstName { get; set; }
		[Required(ErrorMessage = "The Last Name can not empty!")]
		[MinLength(2, ErrorMessage = "The  Last Name must be more than 2 character!")]
		[MaxLength(100, ErrorMessage = "The  Last Name must be lesser than 10 character!")]
		[RegularExpression(@"^[a-zA-Z''-'\s]*$", ErrorMessage = "The  Last Name must be alphabets!")]
		public string? LastName { get; set; }
		[Required(ErrorMessage = "Please choose your gender!")]
		public bool? Gender { get; set; }
		[Required(ErrorMessage = "Please choose your birthday!")]
		public DateTime? Birthday { get; set; }
		[Required(ErrorMessage = "The address can not empty!")]
		[MinLength(5, ErrorMessage = "The address must be more than 5 character!")]
		[MaxLength(100, ErrorMessage = "The address must be lesser than 100 character!")]
		public string? Address { get; set; }
		public string? ProfilePicture { get; set; }
		public bool? IsDeleted { get; set; }
		public virtual ICollection<Order>? Orders { get; set; }
		public virtual ICollection<Feedback>? Feedbacks { get; set; }
	}
}
