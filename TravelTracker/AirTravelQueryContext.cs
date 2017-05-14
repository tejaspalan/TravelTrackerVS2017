using Microsoft.EntityFrameworkCore;
using TravelTracker.Domain;

namespace TravelTracker
{
    public class AirTravelQueryContext : DbContext
    {
        public DbSet<AirTravelQuery> AirTravelQuery { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Server = (localdb)\\mssqllocaldb; Database = TravelTrackerData; Trusted_Connection = True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Defining Primary Key (Note that this is on the base type, not on any derived type)
            modelBuilder.Entity<TravelTrackerQueryBase>()
                .HasKey(query => query.RequestId);

            modelBuilder.Entity<TravelAgent>()
                .HasKey(query => query.TravelAgentId);

            modelBuilder.Entity<Customer>()
                .HasKey(customer => customer.CustomerId);

            //connecting query to travel agent
            //making sure that it is required
            //And if the query data is deleted, corresponding reference is also removed from the travel agent
            modelBuilder.Entity<TravelTrackerQueryBase>()
                .HasOne(query => query.TravelAgent)
                .WithMany(agent => agent.Queries)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            modelBuilder.Entity<TravelTrackerQueryBase>()
                .HasOne(query => query.Customer)
                .WithMany(customer => customer.Queries)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);


            //Setting up TPH (Table per Hierarchy)
            //We may change this at a later point of time
            modelBuilder.Entity<TravelTrackerQueryBase>()
                .HasDiscriminator<string>("query_type")
                .HasValue<TravelTrackerQueryBase>("query_base")
                .HasValue<AirTravelQuery>("airTravelQuery");
        }
    }
}
