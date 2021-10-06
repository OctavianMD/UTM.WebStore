using System;

namespace DataLayer.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public byte[] ImageBytes { get; set; }
        public bool IsAddedToCart { get; set; }
        public int? SalePercentage { get; set; }

        public Category Category { get; set; }

    }
}
