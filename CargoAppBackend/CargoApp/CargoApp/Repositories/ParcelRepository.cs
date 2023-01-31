using CargoApp.DataAccess;
using CargoApp.Models;
using Microsoft.Extensions.Hosting;

namespace CargoApp.Repositories
{
    public class ParcelRepository : IRepository<Parcel>
    {
        private readonly ParcelDbContext _context;

        public ParcelRepository(ParcelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Parcel> FilterBy(Func<Parcel, bool> filter)
        {
            return _context.Parcels.Where(filter);
        }
        public Parcel GetById(int id)
        {
            return _context.Parcels.FirstOrDefault(x => x.Id == id);
        }

        public int getParcelDimensions(Parcel parcel)
        {
            var parcelDimensions = (parcel.parcelWeight) * (parcel.parcelHeight) * (parcel.parcelDepth);
            return parcelDimensions;
        }

        int IRepository<Parcel>.Delete(Parcel entity)
        {
            _context.Parcels.Remove(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        IEnumerable<Parcel> IRepository<Parcel>.FilterBy(Func<Parcel, bool> filter)
        {
            return _context.Parcels.Where(filter);
        }

        IEnumerable<Parcel> IRepository<Parcel>.GetAll()
        {
           return _context.Parcels;
           
        }

      

        int IRepository<Parcel>.Insert(Parcel entity)
        {
            _context.Parcels.Add(entity);

            _context.SaveChanges();
            return entity.Id;
        }

        int IRepository<Parcel>.Update(Parcel entity)
        {
            _context.Parcels.Update(entity);
            _context.SaveChanges();
            return entity.Id;
        }
    }
}
