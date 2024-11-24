using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Midterm.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    IsAvailability = table.Column<bool>(type: "bit", nullable: false),
                    GenreId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasIssuedBook = table.Column<bool>(type: "bit", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { "F", "Fiction" },
                    { "K", "Fantasy" },
                    { "M", "Mystery" },
                    { "NF", "Non-Fiction" },
                    { "SF", "Science Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "BookId", "Email", "HasIssuedBook", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 2, null, "Inska@gmail.com", false, "Inskia", "6739554393" },
                    { 4, null, "Yagtinka@gmail.com", false, "Yagnika", "6435987393" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "GenreId", "IsAvailability", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "F. Scott Fitzgerald", "F", false, "The Great Gatsby", 1925 },
                    { 2, " Yuval Noah Harari ", "NF", false, "Sapiens", 2011 },
                    { 3, "Frank Herbert", "M", true, "Dune Signs", 1965 },
                    { 4, "United Brewn ", "SF", true, "The New York", 1865 },
                    { 5, "Smith", "K", false, "The Best Island", 1955 }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "BookId", "Email", "HasIssuedBook", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 2, "rhama@gmail.com", true, "Rhama", "5366372763" },
                    { 3, 5, "ruhan@gmail.com", true, "Rujan", "3655533363" },
                    { 5, 1, "Thisnb@gmail.com", true, "Thinsina", "5366378883" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_BookId",
                table: "Members",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
