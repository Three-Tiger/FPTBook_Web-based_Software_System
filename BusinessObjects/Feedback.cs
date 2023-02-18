using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
	public class Feedback
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int FeedId { get; set; }
		public string Content { get; set; }
		public DateTime FeedDate { get; set; }
		public bool IsDeleted { get; set; }
		public string UserId { get; set; }
		public int BookId { get; set; }

		[ForeignKey("Id")]
		public virtual AppUser User { get; set; }
		[ForeignKey("BookId")]
		public virtual Book Book { get; set; }
	}
}
