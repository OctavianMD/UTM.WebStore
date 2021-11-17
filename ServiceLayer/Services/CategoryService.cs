using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Helpers;
using CommonLayer.ViewModels;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ILogger<CategoryService> _logger;
        private readonly CategoryHelper _categoryHelper;
        private readonly BaseCategoryHelper _baseCategoryHelper;

        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            MaxDepth = 4,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        public CategoryService(ILogger<CategoryService> logger, CategoryHelper categoryHelper, BaseCategoryHelper baseCategoryHelper)
        {
            _logger = logger;
            _categoryHelper = categoryHelper;
            _baseCategoryHelper = baseCategoryHelper;
        }

        public async Task<List<BaseCategoryViewModel>> GetAllBaseCategories()
        {
            _logger.LogInformation("Getting all base categories");
            try
            {
                return await _baseCategoryHelper.GetAll();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
            return new List<BaseCategoryViewModel>();
        }

        public async Task<BaseCategoryViewModel> GetBaseCategory(int id)
        {
            _logger.LogInformation($"Getting base category: {id}");
            try
            {
                return await _baseCategoryHelper.Get(id);
            }
            catch (NullReferenceException)
            {
                _logger.LogWarning($"Error while getting base category, wrong id: {id}");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
            
            return null;
        }

        public async Task AddBaseCategory(BaseCategoryViewModel model)
        {
            _logger.LogInformation($"Adding base category:{JsonConvert.SerializeObject(model, SerializerSettings)}");
            try
            {
                await _baseCategoryHelper.Create(model);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
        }

        public async Task EditBaseCategory(BaseCategoryViewModel model)
        {
            _logger.LogInformation($"Updating base category:{JsonConvert.SerializeObject(model, SerializerSettings)}");
            try
            {
                await _baseCategoryHelper.Update(model);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
        }

        public async Task DeleteBaseCategory(int id)
        {
            _logger.LogInformation($"Deleting base category:{id}");
            try
            {
                await _baseCategoryHelper.Remove(id);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
        }

        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            _logger.LogInformation("Getting all categories");
            try
            {
                return await _categoryHelper.GetAll();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
            return new List<CategoryViewModel>();
        }

        public async Task<CategoryViewModel> GetCategory(int id)
        {
            _logger.LogInformation($"Getting category: {id}");
            try
            {
                return await _categoryHelper.Get(id);
            }
            catch (NullReferenceException)
            {
                _logger.LogWarning($"Error while getting base category, wrong id: {id}");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }

            return null;
        }

        public async Task AddCategory(CategoryViewModel model)
        {
            _logger.LogInformation($"Adding base category:{JsonConvert.SerializeObject(model, SerializerSettings)}");
            try
            {
                await _categoryHelper.Create(model);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
        }

        public async Task EditCategory(CategoryViewModel model)
        {
            _logger.LogInformation($"Updating category:{JsonConvert.SerializeObject(model, SerializerSettings)}");
            try
            {
                await _categoryHelper.Update(model);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
        }

        public async Task DeleteCategory(int id)
        {
            _logger.LogInformation($"Deleting category:{id}");
            try
            {
                await _categoryHelper.Remove(id);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
        }
    }
}
