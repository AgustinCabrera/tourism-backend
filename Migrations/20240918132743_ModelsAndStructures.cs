using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace tourismApp.Migrations
{
    /// <inheritdoc />
    public partial class ModelsAndStructures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atraction",
                columns: table => new
                {
                    AtractionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AtractionName = table.Column<string>(type: "text", nullable: false),
                    AtractionDescription = table.Column<string>(type: "text", nullable: false),
                    AtractionCost = table.Column<decimal>(type: "numeric", nullable: false),
                    AtractionTypeId = table.Column<int>(type: "integer", nullable: false),
                    IsAtractionDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atraction", x => x.AtractionId);
                });

            migrationBuilder.CreateTable(
                name: "Itinerary",
                columns: table => new
                {
                    ItineraryID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    AtractionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itinerary", x => x.ItineraryID);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    PromotionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AtractionId = table.Column<int>(type: "integer", nullable: false),
                    PromotionDescription = table.Column<string>(type: "text", nullable: false),
                    PromotionType = table.Column<string>(type: "text", nullable: false),
                    PromotionPricingStrategy = table.Column<string>(type: "text", nullable: false),
                    PromotionCostOrDiscount = table.Column<float>(type: "real", nullable: false),
                    IsPromotionDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.PromotionID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atraction");

            migrationBuilder.DropTable(
                name: "Itinerary");

            migrationBuilder.DropTable(
                name: "Promotion");
        }
    }
}
