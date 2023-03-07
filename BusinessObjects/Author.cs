using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects
{
	public class Author
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AuthorId { get; set; }
		[Required(ErrorMessage = "The name can not empty!")]
		[MinLength(2, ErrorMessage = "The name must be more than 2 character!")]
		[MaxLength(50, ErrorMessage = "The name must be lesser than 10 character!")]
		public string AuthorName { get; set; }
		[Required(ErrorMessage = "The phone can not empty!")]
		[RegularExpression(@"^(\d+)?$", ErrorMessage = "The phone must be a number!")]
		[Display(Name = "Phone")]
		[MinLength(9, ErrorMessage = "The phone must be more than 9 number!")]
		[MaxLength(12, ErrorMessage = "The phone must be lesser than 12 numbber!")]
		public string AuthorPhone { get; set; }
		[Required(ErrorMessage = "The email can not empty!")]
		[RegularExpression(@"^[a-zA-Z]\w*(\.\w+)*\@\w+(\.\w{2,3})+$",
		ErrorMessage = "Please enter a valid email address")]
		[Display(Name = "Email")]
		public string AuthorMail { get; set; }
		public bool IsDeleted { get; set; }
		public virtual ICollection<Book>? Books { get; set; }
	}
}
