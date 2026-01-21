using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyProject_L00194748.Migrations
{
    /// <inheritdoc />
    public partial class ver1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_BookTypes_BookTypeID",
                        column: x => x.BookTypeID,
                        principalTable: "BookTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookThemes",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    ThemesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookThemes", x => new { x.BooksId, x.ThemesId });
                    table.ForeignKey(
                        name: "FK_BookThemes_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookThemes_Themes_ThemesId",
                        column: x => x.ThemesId,
                        principalTable: "Themes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Light Novel" },
                    { 2, "Manga" },
                    { 3, "Manwha" },
                    { 4, "Web Novel" }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Fantasy" },
                    { 2, null, "Science Fiction" },
                    { 3, null, "Action" },
                    { 4, null, "Horror" },
                    { 5, null, "Shonen" },
                    { 6, null, "Adventure" },
                    { 7, null, "Comedy" },
                    { 8, null, "Drama" },
                    { 9, null, "Mystery" },
                    { 10, null, "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "BookTypeID", "CoverImage", "Description", "Price", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "Tatsuki Fujimoto", 2, "\\images\\book\\Chainsaw Man Vol. 1 (Manga).jpg", "Denji was a small-time devil hunter just trying to survive in a harsh world. After being killed on a job, he is revived by his pet devil Pochita and becomes something new and dangerous—Chainsaw Man!\r\n\r\nDenji’s a poor young man who’ll do anything for money, even hunting down devils with his pet devil Pochita. He’s a simple man with simple dreams, drowning under a mountain of debt. But his sad life gets turned upside down one day when he’s betrayed by someone he trusts. Now with the power of a devil inside him, Denji’s become a whole new man—Chainsaw Man!", 15m, new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chainsaw Man Vol. 1" },
                    { 2, "Isuna Hasekura", 1, "\\images\\book\\Spice and Wolf Vol. 1 (Light Novel).jpg", "The life of a traveling merchant is a lonely one, a fact with which Kraft Lawrence is well acquainted. Wandering from town to town with just his horse, cart, and whatever wares have come his way, the peddler has pretty well settled into his routine-that is, until the night Lawrence finds a wolf goddess asleep in his cart. Taking the form of a fetching girl with wolf ears and a tail, Holo has wearied of tending to harvests in the countryside and strikes up a bargain with the merchant to lend him the cunning of Holo the Wisewolf to increase his profits in exchange for taking her along on his travels. What kind of businessman could turn down such an offer? Lawrence soon learns, though, that having an ancient goddess as a traveling companion can be a bit of a mixed blessing. Will this wolf girl turn out to be too wild to tame?", 12m, new DateTime(2006, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spice and Wolf Vol. 1" },
                    { 3, "Gege Akutami", 2, "\\images\\book\\Jujutsu Kaisen Vol. 1 (Manga).jpg", "To gain the power he needs to save his friend from a cursed spirit, Yuji Itadori swallows a piece of a demon, only to find himself caught in the midst of a horrific war of the supernatural!\r\n\r\nIn a world where cursed spirits feed on unsuspecting humans, fragments of the legendary and feared demon Ryomen Sukuna have been lost and scattered about. Should any demon consume Sukuna’s body parts, the power they gain could destroy the world as we know it. Fortunately, there exists a mysterious school of jujutsu sorcerers who exist to protect the precarious existence of the living from the supernatural!\r\n\r\nAlthough Yuji Itadori looks like your average teenager, his immense physical strength is something to behold! Every sports club wants him to join, but Itadori would rather hang out with the school outcasts in the Occult Research Club. One day, the club manages to get their hands on a sealed cursed object. Little do they know the terror they’ll unleash when they break the seal…", 15m, new DateTime(2018, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jujutsu Kaisen Vol. 1" },
                    { 4, "Yuan Ye", 4, "\\images\\book\\Lord of Mysteries, Vol. 1, The Clown, Part I (Web Novel).jpg", "In the storm of steam and machinery, who can achieve the extraordinary? In the fog of history and darkness, who whispers? When Zhou Mingrui wakes up bloody and dazed, he finds himself in a world of guns, factories, airships, and difference engines. But underneath the surface of all this industry, there exists a secret society revolving around potions, divination, sealed artifacts, and much more. As Zhou Mingrui tries to find out what brought him to this place, he quickly learns that mystery is lurking around every corner—and danger is never far behind! This is the legend of the Fool…", 20m, new DateTime(2025, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lord of Mysteries Vol. 1: The Clown, Part I" },
                    { 5, "Kisoryong Chugong", 3, "\\images\\book\\Solo Leveling Vol. 1 (Manwha).jpg", "E-class hunter Jinwoo Sung is the weakest of them all. Looked down on by everyone, he has no money, no abilities to speak of, and no other job prospects. So when his party finds a hidden dungeon, he's determined to use this chance to change his life for the better...but the opportunity he finds is a bit different from what he had in mind!", 18m, new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solo Leveling Vol. 1" }
                });

            migrationBuilder.InsertData(
                table: "BookThemes",
                columns: new[] { "BooksId", "ThemesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 6 },
                    { 2, 8 },
                    { 2, 10 },
                    { 3, 3 },
                    { 4, 1 },
                    { 4, 3 },
                    { 4, 9 },
                    { 5, 1 },
                    { 5, 3 },
                    { 5, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookTypeID",
                table: "Books",
                column: "BookTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_BookThemes_ThemesId",
                table: "BookThemes",
                column: "ThemesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookThemes");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropTable(
                name: "BookTypes");
        }
    }
}
