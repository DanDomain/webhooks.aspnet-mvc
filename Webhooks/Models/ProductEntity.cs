using System;

namespace Webhooks.Models
{
    class ProductEntity: IEntity
    {
        public string ShortDescription { get; set; }

        public string Nr { get; set; }

        public string VendorNr { get; set; }

        public decimal Price { get; set; }

        public decimal Weight { get; set; }

        public string PictureLink { get; set; }

        public string PictureBigLink { get; set; }

        public DateTime? EditedDate { get; set; }

        public int StockCount { get; set; }

        public int StockLimit { get; set; }

        public string LocationNumber { get; set; }

        public string BarcodeNumber { get; set; }

        public int SortOrder { get; set; }

        public int MinBuyAmount { get; set; }

        public int MaxBuyAmount { get; set; }

        public string FileSaleLink { get; set; }

        public bool IsVariantMaster { get; set; }

        public string EDBPriserProdNr { get; set; }

        public string EditedBy { get; set; }

        public string Notes { get; set; }

        public string GoogleFeedCategory { get; set; }

        public int MinBuyAmountB2B { get; set; }

        public string LongDescription { get; set; }

        public string LongDescription2 { get; set; }

        public object ObjectIdentifier { get; set; }
    }
}