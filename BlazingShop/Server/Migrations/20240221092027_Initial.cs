using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazingShop.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Visits = table.Column<int>(type: "int", nullable: false),
                    LastVisit = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Views = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariant",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    EditionId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariant", x => new { x.ProductId, x.EditionId });
                    table.ForeignKey(
                        name: "FK_ProductVariant_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariant_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Icon", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "book", "Books", "books" },
                    { 2, "camera-slr", "Electronics", "electronics" },
                    { 3, "aperture", "Video Games", "video-games" }
                });

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Default" },
                    { 2, "Paperback" },
                    { 3, "E-Book" },
                    { 4, "Audiobook" },
                    { 5, "PC" },
                    { 6, "PlayStation" },
                    { 7, "Xbox" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "DateUpdated", "Description", "Image", "IsDeleted", "IsPublic", "Title", "Views" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Hitchhiker's Guide to the Galaxy (sometimes referred to as HG2G, HHGTTG, H2G2, or tHGttG) is a comedy science fiction series created by Douglas Adams.", "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg", false, false, "The Hitchhiker's Guide to the Galaxy", 0 },
                    { 2, 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune.", "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg", false, false, "Ready Player One", 0 },
                    { 3, 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nineteen Eighty-Four: A Novel, often published as 1984, is a dystopian social science fiction novel by English novelist George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime.", "https://upload.wikimedia.org/wikipedia/commons/c/c3/1984first.jpg", false, false, "Nineteen Eighty-Four", 0 },
                    { 4, 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Pentax Spotmatic refers to a family of 35mm single-lens reflex cameras manufactured by the Asahi Optical Co. Ltd., later known as Pentax Corporation, between 1964 and 1976.", "https://upload.wikimedia.org/wikipedia/commons/e/e9/Honeywell-Pentax-Spotmatic.jpg", false, false, "Pentax Spotmatic", 0 },
                    { 5, 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.", "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg", false, false, "Xbox", 0 },
                    { 6, 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg", false, false, "Super Nintendo Entertainment System", 0 },
                    { 7, 3, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.", "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg", false, false, "Half-Life 2", 0 },
                    { 8, 3, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.", "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png", false, false, "Diablo II", 0 },
                    { 9, 3, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.", "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg", false, false, "Day of the Tentacle", 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductVariant",
                columns: new[] { "EditionId", "ProductId", "OriginalPrice", "Price" },
                values: new object[,]
                {
                    { 2, 1, 19.99m, 9.99m },
                    { 3, 1, 0m, 7.99m },
                    { 4, 1, 29.99m, 19.99m },
                    { 2, 2, 14.99m, 7.99m },
                    { 2, 3, 0m, 6.99m },
                    { 1, 4, 249.00m, 166.66m },
                    { 1, 5, 299m, 159.99m },
                    { 1, 6, 400m, 73.74m },
                    { 5, 7, 29.99m, 19.99m },
                    { 6, 7, 0m, 69.99m },
                    { 7, 7, 59.99m, 49.99m },
                    { 5, 8, 24.99m, 9.99m },
                    { 5, 9, 0m, 14.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariant_EditionId",
                table: "ProductVariant",
                column: "EditionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductVariant");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "Editions");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
