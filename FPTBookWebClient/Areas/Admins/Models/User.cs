using BusinessObjects;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FPTBookWebClient.Areas.Admins.Models
{
	public class User
	{
		[Required(ErrorMessage = "First name can not empty!")]
		[MinLength(2, ErrorMessage = "First name must be more than 2 character!")]
		[MaxLength(100, ErrorMessage = "First name must be lesser than 10 character!")]
		[Display(Name = "Last Name")]
		public string? FirstName { get; set; }
		[Required(ErrorMessage = "Last name can not empty!")]
		[MinLength(2, ErrorMessage = "Last name must be more than 2 character!")]
		[MaxLength(100, ErrorMessage = "Last name must be lesser than 10 character!")]
		[Display(Name = "Last Name")]
		public string? LastName { get; set; }
		[Required(ErrorMessage = "Please choose your gender!")]
		public bool? Gender { get; set; }
		[Required(ErrorMessage = "Please choose your birthday!")]
		[ValidBirthday(ErrorMessage = "Birthday can not be greater than current date")]
		public DateTime? Birthday { get; set; }
		[Required(ErrorMessage = "Address can not empty!")]
		[MinLength(10, ErrorMessage = "Address must be more than 10 character!")]
		[MaxLength(100, ErrorMessage = "Address must be lesser than 100 character!")]
		public string? Address { get; set; }
		public string? ProfilePicture { get; set; }
		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		[Phone]
		[Display(Name = "Phone number")]
		[Required(ErrorMessage = "Phone number can not empty!")]
		public string PhoneNumber { get; set; }
	}
}
