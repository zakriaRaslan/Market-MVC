using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToCategoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Name" },
                values: new object[] { "Electronics" }
                );

            migrationBuilder.InsertData(
                 table: "Categories",
                 columns: new[] { "Name" },
                 values: new object[] { "Clothes" }
            );

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Name" },
                values: new object[] { "Computers" }
            );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
