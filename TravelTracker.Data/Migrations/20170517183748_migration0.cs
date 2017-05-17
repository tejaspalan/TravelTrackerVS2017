using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TravelTracker.Data.Migrations
{
    public partial class migration0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelAgents",
                columns: table => new
                {
                    TravelAgentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgentName = table.Column<string>(nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAgents", x => x.TravelAgentId);
                });

            migrationBuilder.CreateTable(
                name: "TravelTrackerQueryBase",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerContactNumber = table.Column<string>(nullable: false),
                    CustomerName = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    NumberOfAdults = table.Column<int>(nullable: false),
                    NumberOfChildren = table.Column<int>(nullable: false),
                    QueryDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    QueryStatus = table.Column<int>(nullable: false),
                    TentativeTripEndDate = table.Column<DateTime>(nullable: false),
                    TentativeTripStartDate = table.Column<DateTime>(nullable: false),
                    TravelAgentId = table.Column<int>(nullable: false),
                    TravelClass = table.Column<int>(nullable: true, defaultValue: 0),
                    TravelType = table.Column<int>(nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelTrackerQueryBase", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_TravelTrackerQueryBase_TravelAgents_TravelAgentId",
                        column: x => x.TravelAgentId,
                        principalTable: "TravelAgents",
                        principalColumn: "TravelAgentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QueryStatusChangeLogs",
                columns: table => new
                {
                    LogIdentifier = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NewStatus = table.Column<int>(nullable: false),
                    OldStatus = table.Column<int>(nullable: false),
                    QueryRequestId = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    TransactingTravelAgentCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueryStatusChangeLogs", x => x.LogIdentifier);
                    table.ForeignKey(
                        name: "FK_QueryStatusChangeLogs_TravelTrackerQueryBase_QueryRequestId",
                        column: x => x.QueryRequestId,
                        principalTable: "TravelTrackerQueryBase",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QueryStatusChangeLogs_QueryRequestId",
                table: "QueryStatusChangeLogs",
                column: "QueryRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelTrackerQueryBase_TravelAgentId",
                table: "TravelTrackerQueryBase",
                column: "TravelAgentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QueryStatusChangeLogs");

            migrationBuilder.DropTable(
                name: "TravelTrackerQueryBase");

            migrationBuilder.DropTable(
                name: "TravelAgents");
        }
    }
}
