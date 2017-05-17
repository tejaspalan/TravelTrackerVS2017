using Microsoft.EntityFrameworkCore;
using TravelTracker.Domain;
using static TravelTracker.Domain.TravelTrackerEnums;

namespace TravelTracker
{
    public class AirTravelQueryContext : DbContext
    {
        public DbSet<TravelTrackerQueryBase> Queries { get; set; }
        public DbSet<TravelAgent> TravelAgents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TravelTrackerDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirTravelQuery>()
                .ToTable("AirTravelQueries");

            modelBuilder.Entity<AirTravelQuery>()
                .Property(x => x.TravelClass)
                .IsRequired()
                .HasDefaultValue(AirTravelClass.Economy);

            modelBuilder.Entity<AirTravelQuery>()
                .Property(x => x.TravelType)
                .IsRequired()
                .HasDefaultValue(TravelType.Domestic);

            modelBuilder.Entity<TravelTrackerQueryBase>()
                .Property(x => x.QueryDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<TravelTrackerQueryBase>()
                .Property(x => x.CustomerContactNumber)
                .IsRequired();

            modelBuilder.Entity<TravelTrackerQueryBase>()
                .Property(x => x.CustomerName)
                .IsRequired();

            modelBuilder.Entity<TravelTrackerQueryBase>()
                .ToTable("TravelTrackerQueryBase");

            modelBuilder.Entity<TravelTrackerQueryBase>()
                .HasKey(queryBase => queryBase.RequestId);

            modelBuilder.Entity<TravelAgent>()
                .HasKey(agent => agent.TravelAgentId);

            modelBuilder.Entity<TravelAgent>()
                .Property(x => x.AgentName)
                .IsRequired();

            modelBuilder.Entity<TravelQueryLog>()
                .ToTable("QueryStatusChangeLogs")
                .HasKey(log => log.LogIdentifier);

            modelBuilder.Entity<TravelQueryLog>()
                .HasOne(log => log.QueryBase)
                .WithMany(queryBase => queryBase.HistoryLog)
                .HasForeignKey(log => log.QueryRequestId)
                .IsRequired();

            modelBuilder.Entity<TravelAgent>()
                .HasMany(agent => agent.Queries)
                .WithOne(queryBase => queryBase.TravelAgent)
                .HasForeignKey(queryBase => queryBase.TravelAgentId)
                .IsRequired();
        }

        public DbSet<TravelTracker.Domain.AirTravelQuery> AirTravelQuery { get; set; }
    }
}
