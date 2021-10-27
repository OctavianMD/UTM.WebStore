using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IFetchDataService
    {
        Task<int> FetchBaseCategories();
        Task<int> FetchCategories();
        Task<int> FetchProducts();
    }
}
