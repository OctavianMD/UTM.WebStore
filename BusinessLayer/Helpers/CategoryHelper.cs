using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Mapper;
using CommonLayer.ApiModels;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Newtonsoft.Json;

namespace BusinessLayer.Helpers
{
    public sealed class CategoryHelper
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public CategoryHelper(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> ProcessFetchedData(string data)
        {
            var counter = 0;
            if (string.IsNullOrWhiteSpace(data))
                return counter;
            
            var categories = JsonConvert.DeserializeObject<List<CategoryApi>>(data);

            if (categories != null)
            {
                foreach (var category in categories)
                {
                    if (!string.IsNullOrWhiteSpace(category.Name)
                        && !await _categoryRepository.Any(x=>x.Name == category.Name))
                    {
                        await _categoryRepository.Add(category.ToEntity());
                        counter++;
                    }
                }
            }

            return counter;
        }
    }
}
