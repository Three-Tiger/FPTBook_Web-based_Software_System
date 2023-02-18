using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
	public class Author
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AuthorId { get; set; }
		public string AuthorName { get; set; }
		[Phone(ErrorMessage = "Invalid phone number")]
		public string AuthorPhone { get; set; }
		[EmailAddress(ErrorMessage = "Invalid email address")]
		public string AuthorMail { get; set; }
		public bool IsDeleted { get; set; }
		public virtual ICollection<Book>? Books { get; set; }
	}
}
