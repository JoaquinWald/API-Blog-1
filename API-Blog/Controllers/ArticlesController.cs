using API_Blog.Context;
using API_Blog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Blog.DTOs;

namespace API_Blog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticlesController : ControllerBase
	{
		private readonly AppDbContext _context;
		public ArticlesController(AppDbContext context)
		{
			_context = context;
		}

		//GET All with Categorie and Author.
		[HttpGet]
		[Route("All")]
		public async Task<IActionResult> All()
		{
			var ArticlesList = await _context.Articles.Include(p => p.Categorie).Include(p => p.Author).Include(p => p.Tags).ToListAsync();
			return StatusCode(StatusCodes.Status200OK, ArticlesList);
		}

		//GET single article
		[HttpGet]
		[Route("Obtain/{id:int}")]
		public async Task<IActionResult> Get(int id)
		{
			var SingleArticle = await _context.Articles.Include(p => p.Categorie).Include(p => p.Author).Include(p => p.Tags).FirstOrDefaultAsync(e => e.ArticleId == id);
			return StatusCode(StatusCodes.Status200OK, SingleArticle);
		}

		//CREATE new article
		[HttpPost]
		[Route("CreateArticle")]
		public async Task<IActionResult> CreateArticle([FromBody] ArticleDto articleDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			//ArticleDTO
			var article = new Article
			{
				CategorieId = articleDto.CategorieId,
				AuthorId = articleDto.AuthorId,
				Title = articleDto.Title,
				Content = articleDto.Content,
				CreatedDate = DateTime.Now,
				Tags = new List<Tag>() //Initializing Tags collection
			};

			//Add tags to the collection of the Article
			foreach (var tagId in articleDto.TagIds)
			{
				var tag = await _context.Tags.FindAsync(tagId);
				if (tag != null)
					article.Tags.Add(tag);
			}
			
			await _context.Articles.AddAsync(article);
			await _context.SaveChangesAsync();

			return StatusCode(StatusCodes.Status200OK, new { message = "ok" });
		}
		
		//UPDATE article
		[HttpPut]
		[Route("Edit/{id:int}")]
		public async Task<IActionResult> Edit(int id, [FromBody] ArticleDto articleDto)
		{
			//Search if the article is in the DB.
			var article = await _context.Articles.FindAsync(id);

			if (article == null)
			{
				return NotFound(new { message = "Article not found" });
			}

			//Update the props of the article with the values of the DTO from the body
			article.CategorieId = articleDto.CategorieId;
			article.AuthorId = articleDto.AuthorId;
			article.Title = articleDto.Title;
			article.Content = articleDto.Content;
			article.Tags = new List<Tag>();

			foreach(var tagId in articleDto.TagIds)
			{
				var tag = await _context.Tags.FindAsync(tagId);
				if (tag != null)
					article.Tags.Add(tag);
			}

			//Save data in DB
			await _context.SaveChangesAsync();

			return StatusCode(StatusCodes.Status200OK, new { message = "Article updated successfully" });
		}

		//DELETE single Article
		[HttpDelete]
		[Route("Delete/{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			var article = await _context.Articles.FindAsync(id);

			if (article == null)
			{
				return NotFound(new { message = "Article not found" });
			}

			_context.Articles.Remove(article);

			await _context.SaveChangesAsync();

			return StatusCode(StatusCodes.Status200OK, new { message = "Article deleted successfully" });
		}
	}
}
