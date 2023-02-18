using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
	public class Genre
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int GenreId { get; set; }
		public string GenreName { get; set; }
		public string GenreDescription { get; set; }
		public bool IsDeleted { get; set; }
		public virtual ICollection<Book>? Books { get; set; }
	}
}
