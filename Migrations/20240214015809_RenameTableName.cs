using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learn_CRUD_CoreWebApp_MVC.Migrations
{
    /// <inheritdoc />
    public partial class RenameTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicesServices_Providers_ProviderId",
                table: "ServicesServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicesServices_Services_ServiceId",
                table: "ServicesServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServicesServices",
                table: "ServicesServices");

            migrationBuilder.RenameTable(
                name: "ServicesServices",
                newName: "ProviderServices");

            migrationBuilder.RenameIndex(
                name: "IX_ServicesServices_ServiceId",
                table: "ProviderServices",
                newName: "IX_ProviderServices_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServicesServices_ProviderId",
                table: "ProviderServices",
                newName: "IX_ProviderServices_ProviderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProviderServices",
                table: "ProviderServices",
                column: "ProviderServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderServices_Providers_ProviderId",
                table: "ProviderServices",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "ProviderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderServices_Services_ServiceId",
                table: "ProviderServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderServices_Providers_ProviderId",
                table: "ProviderServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderServices_Services_ServiceId",
                table: "ProviderServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProviderServices",
                table: "ProviderServices");

            migrationBuilder.RenameTable(
                name: "ProviderServices",
                newName: "ServicesServices");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderServices_ServiceId",
                table: "ServicesServices",
                newName: "IX_ServicesServices_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderServices_ProviderId",
                table: "ServicesServices",
                newName: "IX_ServicesServices_ProviderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServicesServices",
                table: "ServicesServices",
                column: "ProviderServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesServices_Providers_ProviderId",
                table: "ServicesServices",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "ProviderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesServices_Services_ServiceId",
                table: "ServicesServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
