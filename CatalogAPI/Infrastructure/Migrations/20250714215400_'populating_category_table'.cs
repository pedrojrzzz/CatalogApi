using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogAPI.Migrations
{
    /// <inheritdoc />
    public partial class populating_category_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categories(name, imageUrl) Values('Beverage', 'beverage1.jpg')");
            migrationBuilder.Sql("Insert into Categories(name, imageUrl) Values('Snacks', 'snack_image.jpg')");
            migrationBuilder.Sql("Insert into Categories(name, imageUrl) Values('Dessert', 'dessert2.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categories");
        }
    }
}
