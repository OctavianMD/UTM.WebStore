using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Mapper;
using CommonLayer.ApiModels;
using CommonLayer.ViewModels;
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

        public async Task<List<BaseCategoryViewModel>> GetAll()
        {
            var entities = await _baseCategoryRepository.GetAll(x => true);
            return entities.ToViewModel();
        }

        public async Task<BaseCategoryViewModel> Get(int id)
        {
            var entity = await _baseCategoryRepository.Get(x => x.Id == id);
            return entity.ToViewModel();
        }

        public async Task<BaseCategoryViewModel> Create(BaseCategoryViewModel model)
        {
            var entity = await _baseCategoryRepository.Add(model.ToEntity());
            return entity.ToViewModel();
        }

        public async Task<BaseCategoryViewModel> Update(BaseCategoryViewModel model)
        {
            if (await _baseCategoryRepository.Any(x => x.Id == model.Id))
            {
                await _baseCategoryRepository.Update(model.ToEntity());
            }

            return null;
        }

        public async Task Remove(int id)
        {
            var entity = await _baseCategoryRepository.Get(x=>x.Id == id);
            if (entity != null)
            {
                await _baseCategoryRepository.Remove(entity);
            }
        }
    }
}
