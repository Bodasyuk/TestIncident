using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Incidents.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Incidents_IncidentsName",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Incidents_NameIncident",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Accounts_AccountsId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Accounts_AccountsId1",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_NameIncident",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "NameIncident",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "AccountsId1",
                table: "Contacts",
                newName: "AccountsAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_AccountsId1",
                table: "Contacts",
                newName: "IX_Contacts_AccountsAccountId");

            migrationBuilder.RenameColumn(
                name: "IncidentsName",
                table: "Accounts",
                newName: "IncidentsIncidentName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Accounts",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_IncidentsName",
                table: "Accounts",
                newName: "IX_Accounts_IncidentsIncidentName");

            migrationBuilder.AlterColumn<int>(
                name: "AccountsId",
                table: "Contacts",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<Guid>(
                name: "IncidentName",
                table: "Accounts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IncidentName",
                table: "Accounts",
                column: "IncidentName");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Incidents_IncidentName",
                table: "Accounts",
                column: "IncidentName",
                principalTable: "Incidents",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Incidents_IncidentsIncidentName",
                table: "Accounts",
                column: "IncidentsIncidentName",
                principalTable: "Incidents",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Accounts_AccountsAccountId",
                table: "Contacts",
                column: "AccountsAccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Accounts_AccountsId",
                table: "Contacts",
                column: "AccountsId",
                principalTable: "Accounts",
                principalColumn: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Incidents_IncidentName",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Incidents_IncidentsIncidentName",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Accounts_AccountsAccountId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Accounts_AccountsId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_IncidentName",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IncidentName",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "AccountsAccountId",
                table: "Contacts",
                newName: "AccountsId1");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_AccountsAccountId",
                table: "Contacts",
                newName: "IX_Contacts_AccountsId1");

            migrationBuilder.RenameColumn(
                name: "IncidentsIncidentName",
                table: "Accounts",
                newName: "IncidentsName");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Accounts",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_IncidentsIncidentName",
                table: "Accounts",
                newName: "IX_Accounts_IncidentsName");

            migrationBuilder.AlterColumn<int>(
                name: "AccountsId",
                table: "Contacts",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NameIncident",
                table: "Accounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_NameIncident",
                table: "Accounts",
                column: "NameIncident");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Incidents_IncidentsName",
                table: "Accounts",
                column: "IncidentsName",
                principalTable: "Incidents",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Incidents_NameIncident",
                table: "Accounts",
                column: "NameIncident",
                principalTable: "Incidents",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Accounts_AccountsId",
                table: "Contacts",
                column: "AccountsId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Accounts_AccountsId1",
                table: "Contacts",
                column: "AccountsId1",
                principalTable: "Accounts",
                principalColumn: "Id");
        }
    }
}
