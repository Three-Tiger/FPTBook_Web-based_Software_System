using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		public int BookCount { get; set; }
		public DateTime BookCreated { get; set; }
		public DateTime BookLastUpdated { get; set; }
		public string BookImage { get; set; }
		public bool IsDeleted { get; set; }
		public int GenreId { get; set; }
		public int AuthorId { get; set; }
		public int PublisherId { get; set; }
		public virtual ICollection<Feedback> Feedbacks { get; set; }

		[ForeignKey("GenreId")]
		public virtual Genre Genre { get; set; }
		[ForeignKey("AuthorId")]
		public virtual Author Author { get; set; }
		[ForeignKey("PublisherId")]
		public virtual Publisher Publisher { get; set; }
	}
}
