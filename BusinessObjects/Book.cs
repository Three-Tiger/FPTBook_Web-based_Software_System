using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BusinessObjects
{
	public class Book
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int BookId { get; set; }
		[Required(ErrorMessage = "The name can not empty!")]
		[MinLength(2, ErrorMessage = "The Title must be more than 2 character!")]
		[MaxLength(100, ErrorMessage = "The Title must be lesser than 10 character!")]
		[Display(Name = "Title")]
		public string BookTitle { get; set; }
		[Required(ErrorMessage = "The Book Title can not empty!")]
		[MinLength(5, ErrorMessage = "The Book Description must be more than 5 character!")]
		[MaxLength(100, ErrorMessage = "The Book Description must be lesser than 20 character!")]
		[Display(Name = "Description")]
		public string BookDescription { get; set; }
		[Required(ErrorMessage = "The Book Description can not empty!")]
		[MinLength(5, ErrorMessage = "The Book Detail must be more than 5 character!")]
		[Display(Name = "Book Detail")]
		public string BookDetail { get; set; }
		[RegularExpression(@"^(^(\$)?\d+(\.\d+)?$|^(-)?\d+(\.\d+)?$)$|^(^(\$)?((\d\d\d\,){1,4}|(\d\d\,){1,4}|(\d\,){1,4}){1,4}\d\d\d(\.\d+)?$|^(-)?\d+(\.\d+)?$)$",
		ErrorMessage = "The price must be a number!")]
		[Required(ErrorMessage = "The Book Price can not empty!")]
		[Display(Name = "Price")]
		public decimal BookPrice { get; set; }
		[RegularExpression(@"^(^(\$)?\d+(\.\d+)?$|^(-)?\d+(\.\d+)?$)$|^(^(\$)?((\d\d\d\,){1,4}|(\d\d\,){1,4}|(\d\,){1,4}){1,4}\d\d\d(\.\d+)?$|^(-)?\d+(\.\d+)?$)$",
		ErrorMessage = "The Book Original Price must be a number!")]
		[Required(ErrorMessage = "The Book Original Price can not empty!")]
		[Display(Name = "Original Price")]
		public decimal BookOriginalPrice { get; set; }
		[RegularExpression(@"^(^(\$)?\d+(\.\d+)?$|^(-)?\d+(\.\d+)?$)$|^(^(\$)?((\d\d\d\,){1,4}|(\d\d\,){1,4}|(\d\,){1,4}){1,4}\d\d\d(\.\d+)?$|^(-)?\d+(\.\d+)?$)$",
		ErrorMessage = "The Sale Percent must be a number!")]
		[Required(ErrorMessage = "The Sale Percent can not empty!")]
		[Range(1, 99, ErrorMessage = "The Sale Percent is invalid!")]
		[Display(Name = "Sale Percent")]
		public int SalePercent { get; set; }
		[Display(Name = "Stock")]
		[RegularExpression(@"^(^(\$)?\d+(\.\d+)?$|^(-)?\d+(\.\d+)?$)$|^(^(\$)?((\d\d\d\,){1,4}|(\d\d\,){1,4}|(\d\,){1,4}){1,4}\d\d\d(\.\d+)?$|^(-)?\d+(\.\d+)?$)$",
		ErrorMessage = "The Sale Percent must be a number!")]
		[Required(ErrorMessage = "The Book Stock can not empty!")]
		public int BookStock { get; set; }
		public DateTime BookCreated { get; set; } = DateTime.Now;
		public DateTime BookLastUpdated { get; set; } = DateTime.Now;
		[Required]
		[Display(Name = "Image")]
		public string? BookImage { get; set; }
		[NotMapped]
		[Display(Name = "Upload Image")]
		public IFormFile? ImageFile { get; set; }
		public bool IsDeleted { get; set; } = false;
		[Required]
		[Display(Name = "Genre")]
		public int GenreId { get; set; }
		[Required]
		[Display(Name = "Author")]
		public int AuthorId { get; set; }
		[Required]
		[Display(Name = "Publisher")]
		public int PublisherId { get; set; }
		public virtual ICollection<Feedback>? Feedbacks { get; set; }

		[ForeignKey("GenreId")]
		public virtual Genre? Genre { get; set; }
		[ForeignKey("AuthorId")]
		public virtual Author? Author { get; set; }
		[ForeignKey("PublisherId")]
		public virtual Publisher? Publisher { get; set; }
	}
}
