using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TravelTracker.Data.Migrations
{
    public partial class Initial_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "TravelAgent",
                columns: table => new
                {
                    TravelAgentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAgent", x => x.TravelAgentId);
                });

            migrationBuilder.CreateTable(
                name: "TravelTrackerQueryBase",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: true),
                    QueryDate = table.Column<DateTime>(nullable: false),
                    QueryStatus = table.Column<int>(nullable: false),
                    TentativeTripEndDate = table.Column<DateTime>(nullable: false),
                    TentativeTripStartDate = table.Column<DateTime>(nullable: false),
                    TravelAgentId = table.Column<int>(nullable: false),
                    TravelType = table.Column<int>(nullable: false),
                    query_type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelTrackerQueryBase", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_TravelTrackerQueryBase_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelTrackerQueryBase_TravelAgent_TravelAgentId",
                        column: x => x.TravelAgentId,
                        principalTable: "TravelAgent",
                        principalColumn: "TravelAgentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelTrackerQueryBase_CustomerId",
                table: "TravelTrackerQueryBase",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelTrackerQueryBase_TravelAgentId",
                table: "TravelTrackerQueryBase",
                column: "TravelAgentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelTrackerQueryBase");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "TravelAgent");
        }
    }
}
