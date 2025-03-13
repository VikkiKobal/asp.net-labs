using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata; 

#nullable disable

namespace ASPNetExapp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Number", "Year", "Brand", "Color", "Condition", "OwnerLastName", "Address" },
                values: new object[,]
                {
                    { 1, "AA1234BB", 2015, "Toyota", "Red", "Good", "Smith", "123 Main St" },
                    { 2, "BB5678CC", 2020, "Honda", "Blue", "Excellent", "Johnson", "456 Oak Ave" },
                    { 3, "CC9101DD", 2018, "Ford", "Black", "Fair", "Brown", "789 Pine Rd" },
                    { 4, "DD1122EE", 2022, "BMW", "White", "New", "Davis", "101 Elm St" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
