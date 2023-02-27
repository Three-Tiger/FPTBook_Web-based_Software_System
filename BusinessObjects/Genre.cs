using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Constraints;
using System.Text.RegularExpressions;

namespace BusinessObjects
{
	public class Genre
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int GenreId { get; set; }

		[Required(ErrorMessage = "The name can not empty!")]
		[MinLength(2, ErrorMessage = "The name must be more than 2 character!")]
		[MaxLength(100, ErrorMessage = "The name must be lesser than 10 character!")]
		[Display(Name = "Genre Name")]
		[RegularExpression(@"^[a-zA-Z''-'\s]*$", ErrorMessage = "The name must be alphabets!")]
		public string GenreName { get; set; }

		[Required(ErrorMessage = "The discription can not empty!")]
		[MinLength(5, ErrorMessage = "The discription must be more than 5 character!")]
		[MaxLength(100, ErrorMessage = "The discription must be lesser than 100 character!")]
		[Display(Name = "Discription")]
		public string GenreDescription { get; set; }

		public bool IsDeleted { get; set; } = false;
		public GenreApproval? Status { get; set; }
		public virtual ICollection<Book>? Books { get; set; }
	}
}
