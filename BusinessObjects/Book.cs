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
		public string BookTitle { get; set; }
		public string BookDescription { get; set; }
		public string BookDetail { get; set; }
		public decimal BookPrice { get; set; }
		public decimal BookOriginalPrice { get; set; }
		public int SalePercent { get; set; }
		public int BookStock { get; set; }
		public DateTime BookCreated { get; set; } = DateTime.Now;
		public DateTime BookLastUpdated { get; set; } = DateTime.Now;
		public string? BookImage { get; set; }
		[NotMapped]
		public IFormFile? ImageFile { get; set; }
		public bool IsDeleted { get; set; } = false;
		public int GenreId { get; set; }
		public int AuthorId { get; set; }
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
