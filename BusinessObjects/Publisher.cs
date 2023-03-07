using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects
{
	public class Publisher
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PublisherId { get; set; }
		[Required(ErrorMessage = "The name can not empty!")]
		[MinLength(2, ErrorMessage = "The name must be more than 2 character!")]
		[MaxLength(10, ErrorMessage = "The name must be lesser than 10 character!")]
		[Display(Name = "Publisher Name")]
		[RegularExpression(@"^[a-zA-Z''-'\s]*$", ErrorMessage = "The name must be alphabets!")]

		public string PublisherName { get; set; }
		[Required(ErrorMessage = "The phone can not empty!")]
		[RegularExpression(@"^(\d+)?$", ErrorMessage = "The phone must be a number!")]
		[Display(Name = "Phone")]
		[MinLength(9, ErrorMessage = "The phone must be more than 9 number!")]
		[MaxLength(12, ErrorMessage = "The phone must be lesser than 12 numbber!")]
		public string PublisherPhone { get; set; }
		[Required(ErrorMessage = "The email can not empty!")]
		[RegularExpression(@"^[a-zA-Z]\w*(\.\w+)*\@\w+(\.\w{2,3})+$",
		ErrorMessage = "Please enter a valid email address")]
		[Display(Name = "Email")]
		public string PublisherMail { get; set; }
		[Required(ErrorMessage = "The address can not empty!")]
		[MinLength(5, ErrorMessage = "The address must be more than 5 character!")]
		[MaxLength(100, ErrorMessage = "The address must be lesser than 100 character!")]
		[Display(Name = "Adress")]
		public string PublisherAddress { get; set; }
		public bool IsDeleted { get; set; } = false;
		public virtual ICollection<Book>? Books { get; set; }
	}
}
