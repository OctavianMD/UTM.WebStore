using System.Collections.Generic;
using CommonLayer.ApiModels;
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
    }
}
