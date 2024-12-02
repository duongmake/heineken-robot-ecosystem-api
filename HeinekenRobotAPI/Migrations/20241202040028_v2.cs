using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeinekenRobotAPI.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GiftRedemption_Gift_GiftId",
                table: "GiftRedemption");

            migrationBuilder.DropForeignKey(
                name: "FK_RecycleMachine_Location_LocationId",
                table: "RecycleMachine");

            migrationBuilder.DropForeignKey(
                name: "FK_RewardRule_Campaign_CampaignId",
                table: "RewardRule");

            migrationBuilder.DropForeignKey(
                name: "FK_RewardRule_Gift_GiftId",
                table: "RewardRule");

            migrationBuilder.DropForeignKey(
                name: "FK_Robot_Location_LocationId",
                table: "Robot");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleID",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "RewardRule",
                type: "datetime2(5)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "RecycleMachine",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Interaction",
                table: "RecycleMachine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "RecycleMachineId",
                table: "GiftRedemption",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleID",
                table: "User",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_GiftRedemption_RecycleMachineId",
                table: "GiftRedemption",
                column: "RecycleMachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_GiftRedemption_Gift_GiftId",
                table: "GiftRedemption",
                column: "GiftId",
                principalTable: "Gift",
                principalColumn: "GiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_GiftRedemption_RecycleMachine_RecycleMachineId",
                table: "GiftRedemption",
                column: "RecycleMachineId",
                principalTable: "RecycleMachine",
                principalColumn: "RecycleMachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecycleMachine_Location_LocationId",
                table: "RecycleMachine",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RewardRule_Campaign_CampaignId",
                table: "RewardRule",
                column: "CampaignId",
                principalTable: "Campaign",
                principalColumn: "CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_RewardRule_Gift_GiftId",
                table: "RewardRule",
                column: "GiftId",
                principalTable: "Gift",
                principalColumn: "GiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Robot_Location_LocationId",
                table: "Robot",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleID",
                table: "User",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GiftRedemption_Gift_GiftId",
                table: "GiftRedemption");

            migrationBuilder.DropForeignKey(
                name: "FK_GiftRedemption_RecycleMachine_RecycleMachineId",
                table: "GiftRedemption");

            migrationBuilder.DropForeignKey(
                name: "FK_RecycleMachine_Location_LocationId",
                table: "RecycleMachine");

            migrationBuilder.DropForeignKey(
                name: "FK_RewardRule_Campaign_CampaignId",
                table: "RewardRule");

            migrationBuilder.DropForeignKey(
                name: "FK_RewardRule_Gift_GiftId",
                table: "RewardRule");

            migrationBuilder.DropForeignKey(
                name: "FK_Robot_Location_LocationId",
                table: "Robot");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleID",
                table: "User");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_User_RoleID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_GiftRedemption_RecycleMachineId",
                table: "GiftRedemption");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "RewardRule");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "RecycleMachine");

            migrationBuilder.DropColumn(
                name: "Interaction",
                table: "RecycleMachine");

            migrationBuilder.DropColumn(
                name: "RecycleMachineId",
                table: "GiftRedemption");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_GiftRedemption_Gift_GiftId",
                table: "GiftRedemption",
                column: "GiftId",
                principalTable: "Gift",
                principalColumn: "GiftId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecycleMachine_Location_LocationId",
                table: "RecycleMachine",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RewardRule_Campaign_CampaignId",
                table: "RewardRule",
                column: "CampaignId",
                principalTable: "Campaign",
                principalColumn: "CampaignId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RewardRule_Gift_GiftId",
                table: "RewardRule",
                column: "GiftId",
                principalTable: "Gift",
                principalColumn: "GiftId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Robot_Location_LocationId",
                table: "Robot",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
