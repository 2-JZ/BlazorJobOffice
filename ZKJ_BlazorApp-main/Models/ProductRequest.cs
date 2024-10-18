using System;

namespace BlazorApp.Models
{
    public class ProductRequest
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPriceNetto { get; set; }
        public decimal? UnitPriceBrutto { get; set; }
        public float? Discount { get; set; }
        public DateTime? LastModified { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public byte[]? ImageData { get; set; }  // Store image as binary data
    }
}
