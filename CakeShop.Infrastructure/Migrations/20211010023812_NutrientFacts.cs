using Microsoft.EntityFrameworkCore.Migrations;

namespace CakeShop.Infrastructure.Migrations
{
    public partial class NutrientFacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NutrientFacts",
                columns: table => new
                {
                    Nutrient_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Id = table.Column<int>(type: "int", nullable: false),
                    Nutrient_Calories = table.Column<int>(type: "int", nullable: false),
                    Nutrient_Calories_from_Fat = table.Column<int>(type: "int", nullable: false),
                    Nutrient_Fat = table.Column<int>(type: "int", nullable: false),
                    Nutrient_Carbohydrate = table.Column<int>(type: "int", nullable: false),
                    Nutrient_Sodium = table.Column<int>(type: "int", nullable: false),
                    Nutrient_Cholesterol = table.Column<int>(type: "int", nullable: false),
                    Nutrient_Protein = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutrientFacts", x => x.Nutrient_Id);
                    table.ForeignKey(
                        name: "FK_NutrientFacts_Products_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Products",
                        principalColumn: "Pro_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NutrientFacts_Product_Id",
                table: "NutrientFacts",
                column: "Product_Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NutrientFacts");
        }
    }
}
