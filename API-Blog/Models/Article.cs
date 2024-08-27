using System.Text.Json.Serialization;

namespace API_Blog.Models
{
	public class Article
	{
		public int ArticleId { get; set; }
		public int CategorieId { get; set; }
		public int AuthorId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime CreatedDate { get; set; }

		//Navegation properties
		public virtual Categorie Categorie { get; set; }
		public virtual Author Author { get; set; }

		public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
	}
}
