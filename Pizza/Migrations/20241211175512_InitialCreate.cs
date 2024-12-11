using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pizza.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerAddress = table.Column<string>(type: "TEXT", nullable: false),
                    OrderDetail = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Ingredients = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Description", "Ingredients", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Pizza with many Ingredients", "[\"Pepperoni\",\"Sausage\",\"Bacon\",\"Ham\",\"Beef\",\"Mushroom\",\"Bell Peppers\",\"Onions\",\"Mushrooms\",\"Olives\",\"Tomato Sauce\"]", "Supreme", 15.99m },
                    { 2, "Classic pizza with pepperoni", "[\"Pepperoni\",\"Mozzarella\",\"Tomato Sauce\"]", "Pepperoni", 9.99m },
                    { 3, "Simple and delicious cheese pizza", "[\"Mozzarella\",\"Cheddar\",\"Parmesan\",\"Tomato Sauce\"]", "Cheese", 9.99m },
                    { 4, "A healthy pizza loaded with vegetables", "[\"Bell Peppers\",\"Onions\",\"Mushrooms\",\"Olives\",\"Tomato Sauce\"]", "Veggie", 12.99m },
                    { 5, "Pizza for meat enthusiasts", "[\"Pepperoni\",\"Sausage\",\"Bacon\",\"Ham\",\"Beef\",\"Mozzarella\",\"Tomato Sauce\"]", "Meat Lover", 14.99m },
                    { 6, "Pizza with your choice of Toppings", "[\"Mozzarella\",\"Tomato Sauce\"]", "Build Your Own", 14.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Pizzas");
        }
    }
}
