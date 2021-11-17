using System.ComponentModel;

namespace CommonLayer.ViewModels
{
    public class BaseCategoryViewModel
    {
        public int Id { get; set; }
        [DisplayName("Category Name")]
        public string Name { get; set; }
    }
}
