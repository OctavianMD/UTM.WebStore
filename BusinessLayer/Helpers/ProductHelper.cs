using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Mapper;
using BusinessLayer.Validators;
using CommonLayer.ApiModels;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Newtonsoft.Json;

namespace BusinessLayer.Helpers
{
    public sealed class ProductHelper
    {
        private readonly IGenericRepository<Product> _productRepository;

        public ProductHelper(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> ProcessFetchedData(string data)
        {
            var counter = 0;
            if (string.IsNullOrWhiteSpace(data))
                return counter;
            
            var products = JsonConvert.DeserializeObject<List<ProductApi>>(data);

            if (products != null)
            {
                foreach (var product in products)
                {
                    if (product.IsValidEntity()
                        && !await _productRepository.Any(x=>x.Name == product.Name))
                    {
                        await _productRepository.Add(product.ToEntity());
                        counter++;
                    }
                }
            }

            return counter;
        }
    }
}
