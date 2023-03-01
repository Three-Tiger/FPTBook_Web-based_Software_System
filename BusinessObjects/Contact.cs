using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
	public class Contact
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ContactId { get; set; }
		public string ContactName { get; set; }
		public string ContactEmail { get; set; }
		public string ContactSubject { get; set; }
		public string ContactMessage { get; set; }
		public DateTime? ContactDate { get; set; } = DateTime.Now;
		public string? Reply { get; set; }
		public DateTime? ReplyDate { get; set; }
		public bool? IsDeleted { get; set; } = false;
	}
}
