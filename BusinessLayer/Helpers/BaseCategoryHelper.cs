using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Mapper;
using CommonLayer.ApiModels;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Newtonsoft.Json;

namespace BusinessLayer.Helpers
{
    public sealed class BaseCategoryHelper
    {
        private readonly IGenericRepository<BaseCategory> _baseCategoryRepository;

        public BaseCategoryHelper(IGenericRepository<BaseCategory> baseCategoryRepository)
        {
            _baseCategoryRepository = baseCategoryRepository;
        }

        public async Task<int> ProcessFetchedData(string data)
        {
            var counter = 0;
            if (string.IsNullOrWhiteSpace(data))
                return counter;
            
            var baseCategories = JsonConvert.DeserializeObject<List<BaseCategoryApi>>(data);

            if (baseCategories != null)
            {
                foreach (var category in baseCategories)
                {
                    if (!string.IsNullOrWhiteSpace(category.Name)
                        && !await _baseCategoryRepository.Any(x=>x.Name == category.Name))
                    {
                        await _baseCategoryRepository.Add(category.ToEntity());
                        counter++;
                    }
                }
            }

            return counter;
        }
    }
}
