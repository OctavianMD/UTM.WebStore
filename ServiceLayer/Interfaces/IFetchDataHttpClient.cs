using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IFetchDataHttpClient
    {
        Task<string> FetchBaseCategories();
        Task<string> FetchCategories();
        Task<string> FetchProducts();
    }
}
