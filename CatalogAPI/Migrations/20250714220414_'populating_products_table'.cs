using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogAPI.Migrations
{
    /// <inheritdoc />
    public partial class populating_products_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Products (Name, Description, Price, ImageUrl, Stock, RegistrationDate, CategoryId) " +
                                 "VALUES ('Coca-Cola', 'Refreshing soft drink', 1.99, 'coca-cola.jpg', 100, now(), 1)");

            migrationBuilder.Sql("Insert into Products (Name, Description, Price, ImageUrl, Stock, RegistrationDate, CategoryId) " +
                                 "VALUES ('Lays Chips', 'Crispy salted potato chips', 2.49, 'lays-chips.jpg', 150, now(), 2)");

            migrationBuilder.Sql("Insert into Products (Name, Description, Price, ImageUrl, Stock, RegistrationDate, CategoryId) " +
                                 "VALUES ('Chocolate Cake', 'Delicious and moist chocolate dessert', 3.99, 'chocolate-cake.jpg', 80, now(), 3)");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Products");
        }
    }
}
