﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Pixel.Attendance.Migrations
{
    public partial class add_org_id_and_manager_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ManagerId1",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationUnitId",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OrganizationUnitId1",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_ManagerId1",
                table: "AbpUsers",
                column: "ManagerId1");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_OrganizationUnitId1",
                table: "AbpUsers",
                column: "OrganizationUnitId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AbpUsers_ManagerId1",
                table: "AbpUsers",
                column: "ManagerId1",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AbpOrganizationUnits_OrganizationUnitId1",
                table: "AbpUsers",
                column: "OrganizationUnitId1",
                principalTable: "AbpOrganizationUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AbpUsers_ManagerId1",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AbpOrganizationUnits_OrganizationUnitId1",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_ManagerId1",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_OrganizationUnitId1",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "ManagerId1",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "OrganizationUnitId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "OrganizationUnitId1",
                table: "AbpUsers");
        }
    }
}
