using API_Blog.Models;

namespace API_Blog.DTOs
{
	public class ArticleDto
	{
		public string Title { get; set; }
		public string Content { get; set; }
		public int CategorieId { get; set; }
		public int AuthorId { get; set; }
		//public List<int> TagIds { get; set; } = new List<int> { 0 };
		public List<int> Tags { get; set; } = new List<int> { 0 };
	}
}
