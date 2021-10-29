using CommonLayer.ApiModels;
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
                BaseCategory = new BaseCategory()
            };
        }
    }
}
