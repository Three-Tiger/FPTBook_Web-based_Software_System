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
		[Required]
		[Display(Name ="Title")]
		public string BookTitle { get; set; }
		[Required]
		[Display(Name = "Description")]
		public string BookDescription { get; set; }
		[Required]
		[Display(Name = "Book Detail")]
		public string BookDetail { get; set; }
		[Required]
		[Display(Name = "Price")]
		public decimal BookPrice { get; set; }
		[Required]
		[Display(Name = "Original Price")]
		public decimal BookOriginalPrice { get; set; }
		[Required]
		[Display(Name = "Sale Percent")]
		public int SalePercent { get; set; }
		[Required]
		[Display(Name = "Stock")]
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
