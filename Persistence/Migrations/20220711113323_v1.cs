using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,3)", precision: 6, scale: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalItems = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleProduct",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleProduct", x => new { x.SaleId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_SaleProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Martin Fowler" },
                    { 2, "Uncle Bob" },
                    { 3, "Kent Beck" },
                    { 4, "Brenda Delacruz" },
                    { 5, "Harvir Estes" },
                    { 6, "Maurice Boyd" },
                    { 7, "Claire Lacey" },
                    { 8, "Mahamed Vincent" },
                    { 9, "Clayton Whitfield" },
                    { 10, "Cali Spencer" },
                    { 11, "Evie-Mai Fountain" },
                    { 12, "Nia Hook" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Eric Evans" },
                    { 2, "Greg Young" },
                    { 3, "Udi Dahan" },
                    { 4, "Rhia Hatfield" },
                    { 5, "Tasnim Stewart" },
                    { 6, "Neve Kidd" },
                    { 7, "Ezekiel Zamora" },
                    { 8, "Donnie Everett" },
                    { 9, "Renae Mcclure" },
                    { 10, "Lucian Donald" },
                    { 11, "Mea Craft" },
                    { 12, "Neo Black" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Spaghetti", 5m },
                    { 2, "Lasagna", 10m },
                    { 3, "Ravioli", 15m },
                    { 4, "Salad", 5m },
                    { 5, "Sandwich", 3m },
                    { 6, "Tuna Steak", 9m },
                    { 7, "Shrimp", 12m },
                    { 8, "Rice", 7m },
                    { 9, "Pizza", 12m },
                    { 10, "Hamburger", 8m },
                    { 11, "Bean sauce", 3m },
                    { 12, "Brown sugar", 6m },
                    { 13, "Adobo", 1m },
                    { 14, "Hoisin sauce", 9m },
                    { 15, "Sesame seeds", 12m },
                    { 16, "Cottage cheese", 14m },
                    { 17, "Chai", 19m },
                    { 18, "Plantains", 5m },
                    { 19, "Pasta", 3m },
                    { 20, "Coconut milk", 12m },
                    { 21, "Cilantro", 5m },
                    { 22, "Rabbits", 1m },
                    { 23, "Plums", 9m },
                    { 24, "Rice vinegar", 12m },
                    { 25, "Peanuts", 6m },
                    { 26, "Jack cheese", 6m },
                    { 27, "Turkeys", 21m },
                    { 28, "Broth", 22m },
                    { 29, "Couscous", 15m },
                    { 30, "Coconut oil", 18m }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "CreatedDate", "CustomerId", "EmployeeId", "TotalItems", "TotalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), 1, 1, 0, 0m },
                    { 2, new DateTime(2022, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), 2, 2, 0, 0m },
                    { 3, new DateTime(2022, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), 3, 3, 0, 0m },
                    { 4, new DateTime(2022, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), 3, 3, 0, 0m },
                    { 5, new DateTime(2022, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), 1, 2, 0, 0m },
                    { 6, new DateTime(2022, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), 2, 3, 0, 0m }
                });

            migrationBuilder.InsertData(
                table: "SaleProduct",
                columns: new[] { "ProductId", "SaleId", "Id", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 1, 2, 1 },
                    { 3, 1, 3, 1 },
                    { 4, 1, 4, 2 },
                    { 5, 1, 5, 1 },
                    { 6, 2, 6, 1 },
                    { 7, 2, 7, 2 },
                    { 8, 3, 8, 2 },
                    { 9, 3, 9, 3 },
                    { 10, 4, 10, 5 },
                    { 1, 5, 11, 7 },
                    { 1, 6, 12, 3 },
                    { 2, 6, 13, 7 },
                    { 3, 6, 14, 5 },
                    { 4, 6, 15, 4 },
                    { 5, 6, 16, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_ProductId",
                table: "SaleProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_EmployeeId",
                table: "Sales",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleProduct");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
