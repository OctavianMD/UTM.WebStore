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

        public async Task<List<CategoryViewModel>> GetAll()
        {
            var entities = await _categoryRepository.GetAll(x => true);
            return entities.ToViewModel();
        }

        public async Task<CategoryViewModel> Get(int id)
        {
            var entity = await _categoryRepository.Get(x => x.Id == id);
            return entity.ToViewModel();
        }

        public async Task<CategoryViewModel> Create(CategoryViewModel model)
        {
            var entity = await _categoryRepository.Add(model.ToEntity());
            return entity.ToViewModel();
        }

        public async Task<CategoryViewModel> Update(CategoryViewModel model)
        {
            if (await _categoryRepository.Any(x => x.Id == model.Id))
            {
                await _categoryRepository.Update(model.ToEntity());
            }

            return null;
        }

        public async Task Remove(int id)
        {
            var entity = await _categoryRepository.Get(x => x.Id == id);
            if (entity != null)
            {
                await _categoryRepository.Remove(entity);
            }
        }
    }
}
