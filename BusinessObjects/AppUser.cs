using Microsoft.AspNetCore.Identity;

namespace BusinessObjects
{
	public class AppUser : IdentityUser
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public bool? Gender { get; set; }
		public DateTime? Birthday { get; set; }
		public string? Address { get; set; }
		public string? ProfilePicture { get; set; }
		public bool? IsDeleted { get; set; }
		public virtual ICollection<Order>? Orders { get; set; }
		public virtual ICollection<Feedback>? Feedbacks { get; set; }
	}
}
