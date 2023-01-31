using CargoApp.Models;

namespace CargoApp.Services
{
    public interface IService
    {
        IEnumerable<Parcel>GetAllParcels();
        int addParcel(Parcel parcel);   
        void removeParcel(Parcel parcel);
        int getParcelPrice(Parcel parcel);
        int getParcelDimensions(Parcel parcel);
    }
}
