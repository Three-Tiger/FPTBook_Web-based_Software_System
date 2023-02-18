using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
	public class Publisher
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PublisherId { get; set; }
		public string PublisherName { get; set; }
		public string PublisherPhone { get; set; }
		public string PublisherMail { get; set; }
		public string PublisherAddress { get; set; }
		public bool IsDeleted { get; set; }
		public virtual ICollection<Book> Books { get; set; }
	}
}
