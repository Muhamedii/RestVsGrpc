using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Reflection;

namespace Service.Grpc.Services
{
    public class DataService : Grpc.DataService.DataServiceBase
    {
        public override Task<Result> GetAllData(Empty request, ServerCallContext context)
        {
            var data = File.ReadAllText("C:/Users/medi_/source/repos/RestVsGrpc/dummyData.json");


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
