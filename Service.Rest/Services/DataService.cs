using Service.Rest.Models;

namespace Service.Rest.Services
{
    public class DataService : IDataService
    {
        public async Task<List<Person>> GetAllData()
        {
            var dummyDataPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "dummyData.json"));
            var data = File.ReadAllText(dummyDataPath);
            var result = System.Text.Json.JsonSerializer.Deserialize<List<Person>>(data, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return await Task.FromResult(result);
        }
    }
}
