using Service.Rest.Models;

namespace Service.Rest.Services
{
    public interface IDataService
    {
        Task<List<Person>> GetAllData();
    }
}
