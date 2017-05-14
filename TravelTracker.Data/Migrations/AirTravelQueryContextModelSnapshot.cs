using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TravelTracker.Data;

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

            modelBuilder.Entity("TravelTracker.Domain.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("ContactNumber");

                    b.Property<string>("CustomerName");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("TravelTracker.Domain.TravelAgent", b =>
                {
                    b.Property<int>("TravelAgentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AgentName");

                    b.HasKey("TravelAgentId");

                    b.ToTable("TravelAgent");
                });

            modelBuilder.Entity("TravelTracker.Domain.TravelTrackerQueryBase", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("QueryDate");

                    b.Property<int>("QueryStatus");

                    b.Property<DateTime>("TentativeTripEndDate");

                    b.Property<DateTime>("TentativeTripStartDate");

                    b.Property<int>("TravelAgentId");

                    b.Property<int>("TravelType");

                    b.Property<string>("query_type")
                        .IsRequired();

                    b.HasKey("RequestId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TravelAgentId");

                    b.ToTable("TravelTrackerQueryBase");

                    b.HasDiscriminator<string>("query_type").HasValue("query_base");
                });

            modelBuilder.Entity("TravelTracker.Domain.AirTravelQuery", b =>
                {
                    b.HasBaseType("TravelTracker.Domain.TravelTrackerQueryBase");


                    b.ToTable("AirTravelQuery");

                    b.HasDiscriminator().HasValue("airTravelQuery");
                });

            modelBuilder.Entity("TravelTracker.Domain.TravelTrackerQueryBase", b =>
                {
                    b.HasOne("TravelTracker.Domain.Customer", "Customer")
                        .WithMany("Queries")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelTracker.Domain.TravelAgent", "TravelAgent")
                        .WithMany("Queries")
                        .HasForeignKey("TravelAgentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
