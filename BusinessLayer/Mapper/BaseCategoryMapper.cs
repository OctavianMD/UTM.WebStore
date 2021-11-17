using System.Collections.Generic;
using System.Linq;
using CommonLayer.ApiModels;
using CommonLayer.ViewModels;
using DataLayer.Entities;

namespace BusinessLayer.Mapper
{
    public static class BaseCategoryMapper
    {
        public static BaseCategory ToEntity(this BaseCategoryApi category)
        {
            return new BaseCategory
            {
                Name = category.Name,
                Categories = new List<Category>()
            };
        }

        public static List<BaseCategoryViewModel> ToViewModel(this IList<BaseCategory> categories)
        {
            return categories.Select(x => new BaseCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public static BaseCategory ToEntity(this BaseCategoryViewModel category)
        {
            var entity = new BaseCategory
            {
                Name = category.Name,
                Categories = new List<Category>()
            };

            if (category.Id > 0)
            {
                entity.Id = category.Id;
            }

            return entity;
        }

        public static BaseCategoryViewModel ToViewModel(this BaseCategory category)
        {
            return new BaseCategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
