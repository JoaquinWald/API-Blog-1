using System.Text.Json.Serialization;

namespace API_Blog.Models
{
	public class Author
	{
		public int AuthorId { get; set; }
		public string FullName { get; set; }

		[JsonIgnore]
		public virtual ICollection<Article> Articles { get; set; }
	}
}
