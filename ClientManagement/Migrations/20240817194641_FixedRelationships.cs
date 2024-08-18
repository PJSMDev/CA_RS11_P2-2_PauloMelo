using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientManagement.Migrations
{
    public partial class FixedRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_MembershipTypes_MembershipTypeId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Clients_ClientId",
                table: "Payments");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_MembershipTypes_MembershipTypeId",
                table: "Clients",
                column: "MembershipTypeId",
                principalTable: "MembershipTypes",
                principalColumn: "MembershipTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Clients_ClientId",
                table: "Payments",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_MembershipTypes_MembershipTypeId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Clients_ClientId",
                table: "Payments");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_MembershipTypes_MembershipTypeId",
                table: "Clients",
                column: "MembershipTypeId",
                principalTable: "MembershipTypes",
                principalColumn: "MembershipTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Clients_ClientId",
                table: "Payments",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
