using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryFood",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "INTEGER", nullable: false),
                    FoodsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryFood", x => new { x.CategoriesId, x.FoodsId });
                    table.ForeignKey(
                        name: "FK_CategoryFood_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryFood_Foods_FoodsId",
                        column: x => x.FoodsId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "American" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Mexican" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Japanese" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Chinese" });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Nachos" });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Pizza" });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Tacos" });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Noodles" });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Sushi" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFood_FoodsId",
                table: "CategoryFood",
                column: "FoodsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryFood");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
