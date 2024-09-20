using System.Text.Json.Serialization;

namespace API_Blog.Models
{
	public class Tag
	{
		public int TagId { get; set; }
		public string Name { get; set; }


        [JsonIgnore]
		public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
	}
}
