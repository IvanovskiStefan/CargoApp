using CargoApp.Models;
using CargoApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace CargoApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ParcelController : ControllerBase
    {
        private readonly IParcelService _parcelService;

        public ParcelController(IParcelService parcelService)
        {
            _parcelService = parcelService;
        }

        [HttpGet("get-all")]
        public ActionResult<IEnumerable<Parcel>> getAllParcels()
        {
            
            var parcels = _parcelService.GetAllParcels();
            return Ok(parcels);

        }

        [HttpPost("add-parcel")]
        public ActionResult AddParcel([FromBody] Parcel parcel)
        {

            var parcelInDb = _parcelService.addParcel(parcel);


            return Ok(parcelInDb);


        }
        [HttpPost("get-dimensions")]
        public ActionResult<IEnumerable<Parcel>> getParcelDimensionsFromDb([FromBody]Parcel parcel)
        {
            var parcelsdimensions = _parcelService.getParcelDimensions(parcel);
            return Ok(parcelsdimensions);

        }

        




    }
}
