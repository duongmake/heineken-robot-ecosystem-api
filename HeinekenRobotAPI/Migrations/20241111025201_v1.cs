using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeinekenRobotAPI.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PointsBalance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Gift",
                columns: table => new
                {
                    GiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiftName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCount = table.Column<int>(type: "int", nullable: false),
                    RedeemedCount = table.Column<int>(type: "int", nullable: false),
                    ExpiredCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gift", x => x.GiftId);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "RobotType",
                columns: table => new
                {
                    RobotTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RobotTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RobotType", x => x.RobotTypeId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.CampaignId);
                    table.ForeignKey(
                        name: "FK_Campaign_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Location_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "RegionId");
                });

            migrationBuilder.CreateTable(
                name: "GiftRedemption",
                columns: table => new
                {
                    GiftRedemptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedemptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QrCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RedeemedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftRedemption", x => x.GiftRedemptionId);
                    table.ForeignKey(
                        name: "FK_GiftRedemption_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiftRedemption_Gift_GiftId",
                        column: x => x.GiftId,
                        principalTable: "Gift",
                        principalColumn: "GiftId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiftRedemption_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RewardRule",
                columns: table => new
                {
                    RewardRuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PointRangeMin = table.Column<int>(type: "int", nullable: false),
                    PointRangeMax = table.Column<int>(type: "int", nullable: false),
                    GiftChance = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardRule", x => x.RewardRuleId);
                    table.ForeignKey(
                        name: "FK_RewardRule_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RewardRule_Gift_GiftId",
                        column: x => x.GiftId,
                        principalTable: "Gift",
                        principalColumn: "GiftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecycleMachine",
                columns: table => new
                {
                    RecycleMachineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MachineCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContainerStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecycleMachine", x => x.RecycleMachineId);
                    table.ForeignKey(
                        name: "FK_RecycleMachine_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Robot",
                columns: table => new
                {
                    RobotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RobotName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatteryLevel = table.Column<int>(type: "int", nullable: false),
                    LastAccessTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RobotTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Robot", x => x.RobotId);
                    table.ForeignKey(
                        name: "FK_Robot_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Robot_RobotType_RobotTypeId",
                        column: x => x.RobotTypeId,
                        principalTable: "RobotType",
                        principalColumn: "RobotTypeId");
                });

            migrationBuilder.CreateTable(
                name: "CampaignRobotMachine",
                columns: table => new
                {
                    CampaignRobotMachineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RobotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecycleMachineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignRobotMachine", x => x.CampaignRobotMachineId);
                    table.ForeignKey(
                        name: "FK_CampaignRobotMachine_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "CampaignId");
                    table.ForeignKey(
                        name: "FK_CampaignRobotMachine_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_CampaignRobotMachine_RecycleMachine_RecycleMachineId",
                        column: x => x.RecycleMachineId,
                        principalTable: "RecycleMachine",
                        principalColumn: "RecycleMachineId");
                    table.ForeignKey(
                        name: "FK_CampaignRobotMachine_Robot_RobotId",
                        column: x => x.RobotId,
                        principalTable: "Robot",
                        principalColumn: "RobotId");
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RobotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecycleMachineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PointsEarned = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transaction_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Transaction_Gift_GiftId",
                        column: x => x.GiftId,
                        principalTable: "Gift",
                        principalColumn: "GiftId");
                    table.ForeignKey(
                        name: "FK_Transaction_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_RecycleMachine_RecycleMachineId",
                        column: x => x.RecycleMachineId,
                        principalTable: "RecycleMachine",
                        principalColumn: "RecycleMachineId");
                    table.ForeignKey(
                        name: "FK_Transaction_Robot_RobotId",
                        column: x => x.RobotId,
                        principalTable: "Robot",
                        principalColumn: "RobotId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_RegionId",
                table: "Campaign",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRobotMachine_CampaignId",
                table: "CampaignRobotMachine",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRobotMachine_LocationId",
                table: "CampaignRobotMachine",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRobotMachine_RecycleMachineId",
                table: "CampaignRobotMachine",
                column: "RecycleMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRobotMachine_RobotId",
                table: "CampaignRobotMachine",
                column: "RobotId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftRedemption_CampaignId",
                table: "GiftRedemption",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftRedemption_GiftId",
                table: "GiftRedemption",
                column: "GiftId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftRedemption_UserId",
                table: "GiftRedemption",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_RegionId",
                table: "Location",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_RecycleMachine_LocationId",
                table: "RecycleMachine",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardRule_CampaignId",
                table: "RewardRule",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardRule_GiftId",
                table: "RewardRule",
                column: "GiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Robot_LocationId",
                table: "Robot",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Robot_RobotTypeId",
                table: "Robot",
                column: "RobotTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CampaignId",
                table: "Transaction",
                column: "CampaignId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CustomerId",
                table: "Transaction",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_GiftId",
                table: "Transaction",
                column: "GiftId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_LocationId",
                table: "Transaction",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_RecycleMachineId",
                table: "Transaction",
                column: "RecycleMachineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_RobotId",
                table: "Transaction",
                column: "RobotId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignRobotMachine");

            migrationBuilder.DropTable(
                name: "GiftRedemption");

            migrationBuilder.DropTable(
                name: "RewardRule");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Gift");

            migrationBuilder.DropTable(
                name: "RecycleMachine");

            migrationBuilder.DropTable(
                name: "Robot");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "RobotType");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
