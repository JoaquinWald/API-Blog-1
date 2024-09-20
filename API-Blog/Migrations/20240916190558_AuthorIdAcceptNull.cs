using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Blog.Migrations
{
    /// <inheritdoc />
    public partial class AuthorIdAcceptNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Author_AuthorId",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_Article_Categorie_CategorieId",
                table: "Article");

            migrationBuilder.AlterColumn<int>(
                name: "CategorieId",
                table: "Article",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Article",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Author_AuthorId",
                table: "Article",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Categorie_CategorieId",
                table: "Article",
                column: "CategorieId",
                principalTable: "Categorie",
                principalColumn: "CategorieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Author_AuthorId",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_Article_Categorie_CategorieId",
                table: "Article");

            migrationBuilder.AlterColumn<int>(
                name: "CategorieId",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Author_AuthorId",
                table: "Article",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Categorie_CategorieId",
                table: "Article",
                column: "CategorieId",
                principalTable: "Categorie",
                principalColumn: "CategorieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
