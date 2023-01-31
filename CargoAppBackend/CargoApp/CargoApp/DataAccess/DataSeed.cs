using CargoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CargoApp.DataAccess
{
    public class DataSeed
    {
        public static void InsertDataInDb(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parcel>()
                .HasData(
                new Parcel
                {
                    Id = 1,
                    parcelDepth = 100,
                    parcelHeight = 100,
                    parcelWidth = 100,
                    parcelWeight = 100

                },
            new Parcel
            {
                Id = 2,
                parcelDepth = 50,
                parcelHeight = 50,
                parcelWidth = 50,
                parcelWeight = 50

            },
            new Parcel
            {
                Id = 3,
                parcelDepth = 25,
                parcelHeight = 25,
                parcelWidth = 25,
                parcelWeight = 25

            });
        }
    }
}
