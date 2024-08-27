using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Blog.Migrations
{
    /// <inheritdoc />
    public partial class DeletedTadIgFromArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Article");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
