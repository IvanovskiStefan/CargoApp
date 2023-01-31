using CargoApp.Models;
using CargoApp.Repositories;

namespace CargoApp.Services
{
    public class IParcelService :IService
    {
        private readonly IRepository<Parcel> _parcelRepository;

        public IParcelService(IRepository<Parcel> parcelRepository)
        {
            _parcelRepository = parcelRepository;
        }

        public int addParcel(Parcel parcel)
        {
            _parcelRepository.Insert(parcel);
            return parcel.Id;
        }

        public IEnumerable<Parcel> GetAllParcels()
        {
            return _parcelRepository.GetAll();
        }

        public int getParcelDimensions(Parcel parcel)
        {
            var parcelDimensions = (parcel.parcelWidth) * (parcel.parcelHeight) * (parcel.parcelDepth);
            return parcelDimensions;
        }

        public int getParcelPrice(Parcel parcel)
        {
            return parcel.Id;
        }

        public int removeParcel(Parcel parcel)
        {
            throw new NotImplementedException();
        }

        void IService.removeParcel(Parcel parcel)
        {
            throw new NotImplementedException();
        }
    }
}
