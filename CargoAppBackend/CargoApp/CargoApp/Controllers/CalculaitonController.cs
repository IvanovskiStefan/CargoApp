using CargoApp.Models;
using CargoApp.Repositories;
using CargoApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System;
using System.CodeDom;

namespace CargoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CalculaitonController : ControllerBase
    {
        private readonly IParcelService _parcelService;
        private readonly ParcelRepository _parcelRepository;

       

        public CalculaitonController(IParcelService parcelService)
        {
            _parcelService = parcelService;
        }
        
        [HttpPost("calculation-cargo4u")]
        public double getParcelPriceCargo4U(Parcel parcel)
        {
            var weightPrice = parcel.parcelWeightPrice;
            var volumePrice = parcel.parcelDimensionPrice;
            var parcelsDimensions = _parcelService.getParcelDimensions(parcel);

                 int kgPrice ()  {
                 var kgPrice = 99999999;

                    if (parcel.parcelWeight <= 20 && parcelsDimensions <= 2000)
                    {
                        if (parcel.parcelWeight > 0 && parcel.parcelWeight <= 2)
                        {
                        return kgPrice = 15;
                        }
                        else if (parcel.parcelWeight > 2 && parcel.parcelWeight <= 15)
                        {
                        return kgPrice = 18;
                        }
                        else
                        {
                        return kgPrice = 35;
                        };
                    }
                    else
                    {
                    kgPrice = 999999999;
                    }
                return kgPrice;
                };

                int volumenPrice () {
                    var volumenPrice = 99999999;
                    if (parcel.parcelWeight <= 20 && parcelsDimensions <= 2000)
                    {
                        if (parcelsDimensions <= 1000)
                        {
                        return volumenPrice = 10;
                        }
                        else
                        {
                        return volumenPrice = 20;
            };
                    }
                    else
                    {
                    volumenPrice = 99999999;
                    }
                return volumenPrice;
                }
            return Math.Max(kgPrice(), volumenPrice());

           

        }
        
        [HttpPost("calculation-shipfaster")]

        public double getParcelPriceShipFaster(Parcel parcel)
        {
            double incrementPlusWeight = 0.417;
            double weightprice = parcel.parcelWeightPrice;
            double volumeprice = parcel.parcelDimensionPrice;
            var parcelsdimensions = _parcelService.getParcelDimensions(parcel);

            double kgPrice() 
            {
                double weightprice = 99999999;
                if (parcel.parcelWeight <= 30 && parcelsdimensions <= 1700)
                {
                    if (parcel.parcelWeight > 10 && parcel.parcelWeight <= 15)
                    {
                        return weightprice = 16.50;
                    }
                    else if (parcel.parcelWeight > 15 && parcel.parcelWeight <= 25)
                    {
                        return weightprice = 36.50;
                    }
                    else if (parcel.parcelWeight > 25)
                    {
                     weightprice = 40 + incrementPlusWeight++;// doesent add , rethink !

                    }


                }
                return weightprice;
            }
            
            double volumenPrice()
            {
                double volumeprice = 99999999;
                if (parcel.parcelWeight <= 30 && parcelsdimensions <= 1700)
                {
                    if (parcelsdimensions <= 1000)
                    {
                        return volumeprice = 19.99;
                    }
                    else
                    {
                        return volumeprice = 21.99;
                    };
                };
                return volumeprice;
            }
            

            return Math.Max(kgPrice(), volumenPrice());

        }
        
        
        [HttpPost("calculation-maltaship")]

        public double getParcelPriceMaltaShip(Parcel parcel)
        {
            double incrementPlusWeight = 0.41;
            double weightprice = parcel.parcelWeightPrice;
            double volumeprice = parcel.parcelDimensionPrice;
            var parcelsdimensions = _parcelService.getParcelDimensions(parcel);

            double kgPrice() 
            {
                double weightprice = 99999999;
                if (parcel.parcelWeight >= 10 && parcelsdimensions >= 500)
                {
                    if (parcel.parcelWeight > 10 && parcel.parcelWeight <= 20)
                    {
                        return weightprice = 16.99;
                    }
                    else if (parcel.parcelWeight > 20 && parcel.parcelWeight <= 30)
                    {
                        return weightprice = 33.99;
                    }
                    else
                    {
                     return weightprice = 43.99 + incrementPlusWeight++;// doesent add , rethink !

                    };
                    
                }
                return weightprice;
            }
           
            double volumenPrice()
            {
                double volumeprice = 999999;
                if (parcel.parcelWeight >= 10 && parcelsdimensions >= 500)
                {
                    if (parcel.parcelWeight >= 10 && parcelsdimensions >= 500)
                    {
                        if (parcelsdimensions <= 1000)
                        {
                            return volumeprice = 9.50;
                        }
                        else if (parcelsdimensions > 1000 && parcelsdimensions <= 2000)
                        {
                            return volumeprice = 19.50;
                        }
                        else if (parcelsdimensions > 2000 && parcelsdimensions <= 5000)
                        {
                            return volumeprice = 48.50;
                        }
                        else
                        {
                            return volumeprice = 147.50;
                        }
                    };
                }
                return volumeprice;

            }

            return Math.Max(kgPrice(), volumenPrice());
        }

    }
}
