using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace Service.Grpc.Services
{
    public class DataService : Grpc.DataService.DataServiceBase
    {
        public override Task<Result> GetAllData(Empty request, ServerCallContext context)
        {
            var dummyDataPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "dummyData.json"));
            var data = File.ReadAllText(dummyDataPath);

            var persons = System.Text.Json.JsonSerializer.Deserialize<RepeatedField<Person>>(data, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            var result = new Result();
            result.Items.AddRange(persons);
            return Task.FromResult(result);
        }
    }
}
