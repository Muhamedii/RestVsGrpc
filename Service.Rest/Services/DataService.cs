using Service.Rest.Models;

namespace Service.Rest.Services
{
    public class DataService : IDataService
    {
        public Task<List<Person>> GetAllData()
        {
            var data = File.ReadAllText("C:/Users/medi_/source/repos/RestVsGrpc/dummyData.json");
            var result = System.Text.Json.JsonSerializer.Deserialize<List<Person>>(data, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return Task.FromResult(result);
        }
    }
}
