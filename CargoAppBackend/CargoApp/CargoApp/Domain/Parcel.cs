namespace CargoApp.Models
{
    public class Parcel : BaseEntity
    {
        public int parcelWidth { get; set; }
        public int parcelHeight { get; set; }
        public int parcelDepth { get; set; }
        public int parcelWeight { get; set; }
        public string? parcelName { get; set; }
        public int parcelDimensionPrice { get; set; }
        public int parcelWeightPrice { get; set; }
        public double parcelFinalPrice { get; set; }
        public int parcelDimensions { get;}
    }
}
