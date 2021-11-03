using CommonLayer.ApiModels;
using DataLayer.Entities;

namespace BusinessLayer.Mapper
{
    public static class ProductMapper
    {
        public static Product ToEntity(this ProductApi product)
        {
            return new Product
            {
                Name = product.Name,
                Brand = product.Brand,
                Description = product.Description ?? "",
                ImageBytes = product.ImageAsBase64.ToBytes()
            };
        }
    }
}
