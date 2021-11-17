using System.Collections.Generic;
using System.Threading.Tasks;
using CommonLayer.ViewModels;

namespace ServiceLayer.Interfaces
{
    public interface ICategoryService
    {
        #region Base Category Actions

        Task<List<BaseCategoryViewModel>> GetAllBaseCategories();
        Task<BaseCategoryViewModel> GetBaseCategory(int id);
        Task AddBaseCategory(BaseCategoryViewModel model);
        Task EditBaseCategory(BaseCategoryViewModel model);
        Task DeleteBaseCategory(int id);

        #endregion

        #region Category Actions

        Task<List<CategoryViewModel>> GetAllCategories();
        Task<CategoryViewModel> GetCategory(int id);
        Task AddCategory(CategoryViewModel model);
        Task EditCategory(CategoryViewModel model);
        Task DeleteCategory(int id);

        #endregion
    }
}
