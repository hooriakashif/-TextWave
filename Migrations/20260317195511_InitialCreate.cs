using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TextWave.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PricingPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthlyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AnnualPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SMSCount = table.Column<int>(type: "int", nullable: false),
                    SenderIDs = table.Column<int>(type: "int", nullable: false),
                    SupportType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasApiAccess = table.Column<bool>(type: "bit", nullable: false),
                    HasTwoWaySms = table.Column<bool>(type: "bit", nullable: false),
                    HasAnalytics = table.Column<bool>(type: "bit", nullable: false),
                    HasCustomIntegration = table.Column<bool>(type: "bit", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricingPlans", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PricingPlans");
        }
    }
}
