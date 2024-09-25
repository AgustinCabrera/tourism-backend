using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace tourismApp.Migrations
{
    /// <inheritdoc />
    public partial class AddItineraryRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Promotion",
                table: "Promotion");

            migrationBuilder.DropColumn(
                name: "PromotionID",
                table: "Promotion");

            migrationBuilder.DropColumn(
                name: "IsPromotionDeleted",
                table: "Promotion");

            migrationBuilder.DropColumn(
                name: "AtractionId",
                table: "Itinerary");

            migrationBuilder.RenameColumn(
                name: "PromotionType",
                table: "Promotion",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "PromotionPricingStrategy",
                table: "Promotion",
                newName: "PricingStrategy");

            migrationBuilder.RenameColumn(
                name: "PromotionDescription",
                table: "Promotion",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "PromotionCostOrDiscount",
                table: "Promotion",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "AtractionId",
                table: "Promotion",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "IsAtractionDeleted",
                table: "Atraction",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "AtractionTypeId",
                table: "Atraction",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "AtractionName",
                table: "Atraction",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "AtractionDescription",
                table: "Atraction",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "AtractionCost",
                table: "Atraction",
                newName: "Cost");

            migrationBuilder.AddColumn<decimal>(
                name: "UserBudget",
                table: "User",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Promotion",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Promotion",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Promotion",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Itinerary",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Itinerary",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "RemainingBudget",
                table: "Itinerary",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Itinerary",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Itinerary",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                table: "Itinerary",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "Itinerary",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Atraction",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promotion",
                table: "Promotion",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "ItineraryAtraction",
                columns: table => new
                {
                    ItineraryId = table.Column<int>(type: "integer", nullable: false),
                    AtractionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItineraryAtraction", x => new { x.ItineraryId, x.AtractionId });
                    table.ForeignKey(
                        name: "FK_ItineraryAtraction_Atraction_AtractionId",
                        column: x => x.AtractionId,
                        principalTable: "Atraction",
                        principalColumn: "AtractionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItineraryAtraction_Itinerary_ItineraryId",
                        column: x => x.ItineraryId,
                        principalTable: "Itinerary",
                        principalColumn: "ItineraryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItineraryPromotion",
                columns: table => new
                {
                    ItineraryId = table.Column<int>(type: "integer", nullable: false),
                    PromotionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItineraryPromotion", x => new { x.ItineraryId, x.PromotionId });
                    table.ForeignKey(
                        name: "FK_ItineraryPromotion_Itinerary_ItineraryId",
                        column: x => x.ItineraryId,
                        principalTable: "Itinerary",
                        principalColumn: "ItineraryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItineraryPromotion_Promotion_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Itinerary_UserId1",
                table: "Itinerary",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryAtraction_AtractionId",
                table: "ItineraryAtraction",
                column: "AtractionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryPromotion_PromotionId",
                table: "ItineraryPromotion",
                column: "PromotionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Itinerary_User_UserId1",
                table: "Itinerary",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itinerary_User_UserId1",
                table: "Itinerary");

            migrationBuilder.DropTable(
                name: "ItineraryAtraction");

            migrationBuilder.DropTable(
                name: "ItineraryPromotion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promotion",
                table: "Promotion");

            migrationBuilder.DropIndex(
                name: "IX_Itinerary_UserId1",
                table: "Itinerary");

            migrationBuilder.DropColumn(
                name: "UserBudget",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Promotion");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Promotion");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Itinerary");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Itinerary");

            migrationBuilder.DropColumn(
                name: "RemainingBudget",
                table: "Itinerary");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Itinerary");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Itinerary");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "Itinerary");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Itinerary");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Atraction");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Promotion",
                newName: "PromotionType");

            migrationBuilder.RenameColumn(
                name: "PricingStrategy",
                table: "Promotion",
                newName: "PromotionPricingStrategy");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "Promotion",
                newName: "PromotionCostOrDiscount");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Promotion",
                newName: "PromotionDescription");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Promotion",
                newName: "AtractionId");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Atraction",
                newName: "AtractionTypeId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Atraction",
                newName: "AtractionName");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Atraction",
                newName: "IsAtractionDeleted");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Atraction",
                newName: "AtractionDescription");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Atraction",
                newName: "AtractionCost");

            migrationBuilder.AlterColumn<int>(
                name: "AtractionId",
                table: "Promotion",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "PromotionID",
                table: "Promotion",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<bool>(
                name: "IsPromotionDeleted",
                table: "Promotion",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AtractionId",
                table: "Itinerary",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promotion",
                table: "Promotion",
                column: "PromotionID");
        }
    }
}
