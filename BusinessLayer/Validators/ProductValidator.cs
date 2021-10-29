using CommonLayer.ApiModels;

namespace BusinessLayer.Validators
{
    public static class ProductValidator
    {
        public static bool IsValidEntity(this ProductApi product)
        {
            return !string.IsNullOrWhiteSpace(product.Name)
                   && !string.IsNullOrWhiteSpace(product.Brand)
                   && !string.IsNullOrWhiteSpace(product.ImageAsBase64);
        }
    }
}
