using System.Text.Json.Serialization;

namespace API_Blog.Models
{
	public class Categorie
	{
		public int CategorieId { get; set; }
		public string Name { get; set; }

		[JsonIgnore]
		public virtual ICollection<Article> Articles { get; set; }
	}
}
