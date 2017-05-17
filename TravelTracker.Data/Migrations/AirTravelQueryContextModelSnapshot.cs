using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TravelTracker.Data;
using TravelTracker.Domain;

namespace TravelTracker.Data.Migrations
{
    [DbContext(typeof(AirTravelQueryContext))]
    partial class AirTravelQueryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TravelTracker.Domain.TravelAgent", b =>
                {
                    b.Property<int>("TravelAgentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AgentName")
                        .IsRequired();

                    b.Property<int>("Role");

                    b.HasKey("TravelAgentId");

                    b.ToTable("TravelAgents");
                });

            modelBuilder.Entity("TravelTracker.Domain.TravelQueryLog", b =>
                {
                    b.Property<int>("LogIdentifier")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("NewStatus");

                    b.Property<int>("OldStatus");

                    b.Property<int>("QueryRequestId");

                    b.Property<string>("Remarks");

                    b.Property<int>("TransactingTravelAgentCode");

                    b.HasKey("LogIdentifier");

                    b.HasIndex("QueryRequestId");

                    b.ToTable("QueryStatusChangeLogs");
                });

            modelBuilder.Entity("TravelTracker.Domain.TravelTrackerQueryBase", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerContactNumber")
                        .IsRequired();

                    b.Property<string>("CustomerName")
                        .IsRequired();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("NumberOfAdults");

                    b.Property<int>("NumberOfChildren");

                    b.Property<DateTime>("QueryDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("QueryStatus");

                    b.Property<DateTime>("TentativeTripEndDate");

                    b.Property<DateTime>("TentativeTripStartDate");

                    b.Property<int>("TravelAgentId");

                    b.HasKey("RequestId");

                    b.HasIndex("TravelAgentId");

                    b.ToTable("TravelTrackerQueryBase");

                    b.HasDiscriminator<string>("Discriminator").HasValue("TravelTrackerQueryBase");
                });

            modelBuilder.Entity("TravelTracker.Domain.AirTravelQuery", b =>
                {
                    b.HasBaseType("TravelTracker.Domain.TravelTrackerQueryBase");

                    b.Property<int>("TravelClass")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("TravelType")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.ToTable("AirTravelQueries");

                    b.HasDiscriminator().HasValue("AirTravelQuery");
                });

            modelBuilder.Entity("TravelTracker.Domain.TravelQueryLog", b =>
                {
                    b.HasOne("TravelTracker.Domain.TravelTrackerQueryBase", "QueryBase")
                        .WithMany("HistoryLog")
                        .HasForeignKey("QueryRequestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelTracker.Domain.TravelTrackerQueryBase", b =>
                {
                    b.HasOne("TravelTracker.Domain.TravelAgent", "TravelAgent")
                        .WithMany("Queries")
                        .HasForeignKey("TravelAgentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
