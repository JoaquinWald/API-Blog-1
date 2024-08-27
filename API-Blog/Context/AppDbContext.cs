using API_Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Blog.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Article> Articles { get; set; }
		public DbSet<Categorie> Categories { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Tag> Tags { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Article>(article =>
			{
				article.ToTable("Article");
				article.HasKey(p => p.ArticleId);

				article
				.HasOne(p => p.Categorie)
				.WithMany(p => p.Articles)
				.HasForeignKey(p => p.CategorieId);

				article
				.HasOne(p => p.Author)
				.WithMany(p => p.Articles)
				.HasForeignKey(p => p.AuthorId);

				article
				.HasMany(p => p.Tags)
				.WithMany(p => p.Articles)
				.UsingEntity<Dictionary<string, object>>
				(
					"ArticleTag",
					j => j.HasOne<Tag>().WithMany().HasForeignKey("TagId"),
					j => j.HasOne<Article>().WithMany().HasForeignKey("ArticleId")
				);

				article.Property(p => p.Title).IsRequired().HasMaxLength(200);
				article.Property(p => p.Content);
				article.Property(p => p.CreatedDate);
			});

			modelBuilder.Entity<Categorie>(categorie =>
			{
				categorie.ToTable("Categorie");
				categorie.HasKey(p => p.CategorieId);

				categorie.Property(p => p.Name);
			});

			modelBuilder.Entity<Author>(author =>
			{
				author.ToTable("Author");
				author.HasKey(p => p.AuthorId);

				author.Property(p => p.FullName);
			});

			modelBuilder.Entity<Tag>(tag =>
			{
				tag.ToTable("Tag");
				tag.HasKey(p => p.TagId);

				tag.Property(p => p.Name);
			});
		}
	}
}
