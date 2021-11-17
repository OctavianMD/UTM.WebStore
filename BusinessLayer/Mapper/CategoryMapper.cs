using System.Collections.Generic;
using System.Linq;
using CommonLayer.ApiModels;
using CommonLayer.ViewModels;
using DataLayer.Entities;

namespace BusinessLayer.Mapper
{
    public static class CategoryMapper
    {
        public static Category ToEntity(this CategoryApi category)
        {
            return new Category
            {
                Name = category.Name,
            };
        }

        public static List<CategoryViewModel> ToViewModel(this IList<Category> categories)
        {
            return categories.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public static Category ToEntity(this CategoryViewModel category)
        {
            var entity = new Category
            {
                Name = category.Name,
            };

            if (category.Id > 0)
            {
                entity.Id = category.Id;
            }

            return entity;
        }

        public static CategoryViewModel ToViewModel(this Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
