using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Constraints;

namespace BusinessObjects
{
	public class Feedback
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int FeedId { get; set; }
		public string Content { get; set; }
		public DateTime FeedDate { get; set; } = DateTime.Now;
		public bool IsDeleted { get; set; } = false;
		public FeedStatus? FeedStatus { get; set; }
		public string UserId { get; set; }
		public int BookId { get; set; }

		[ForeignKey("UserId")]
		public virtual AppUser? User { get; set; }
		[ForeignKey("BookId")]
		public virtual Book? Book { get; set; }
	}
}
