using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Blog.Migrations
{
    /// <inheritdoc />
    public partial class AddTagIdToArticleModelAndCommentedArticle_TagTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article_Tag");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Article_TagId",
                table: "Article",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Tag_TagId",
                table: "Article",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Tag_TagId",
                table: "Article");

            migrationBuilder.DropIndex(
                name: "IX_Article_TagId",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Article");

            migrationBuilder.CreateTable(
                name: "Article_Tag",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article_Tag", x => new { x.ArticleId, x.TagId });
                    table.ForeignKey(
                        name: "FK_Article_Tag_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Article_Tag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_Tag_TagId",
                table: "Article_Tag",
                column: "TagId");
        }
    }
}
