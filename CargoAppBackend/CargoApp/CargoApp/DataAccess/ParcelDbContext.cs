using CargoApp.Models;
using Microsoft.EntityFrameworkCore;
using CargoApp.DataAccess;

namespace CargoApp.DataAccess
{
    public class ParcelDbContext : DbContext
    {
        public ParcelDbContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<Parcel> Parcels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parcel>();
            DataSeed.InsertDataInDb(modelBuilder);

        }

    }
}
