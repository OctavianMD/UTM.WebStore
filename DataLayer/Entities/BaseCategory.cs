using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class BaseCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Category> Categories { get; set; }
    }
}
