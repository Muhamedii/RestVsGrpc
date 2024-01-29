using AutoMapper;
using Gateway.API.Responses;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Service.Grpc;

namespace Gateway.API.Services
{
    public class PersonsService : IPersonsService
    {
        private readonly IMapper _mapper;
        public PersonsService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<PersonsResponse> GetAllPersons(bool isFromGrpcService = false)
        {
            if (isFromGrpcService)
            {
                // fetch data from grpc service

                using var channel = GrpcChannel.ForAddress("https://localhost:7269");
                var grpcClient = new DataService.DataServiceClient(channel);
                var result = await grpcClient.GetAllDataAsync(new Empty());
                return new PersonsResponse { Items = _mapper.Map<List<Models.Person>>(result.Items) };
            }
            // fetch data from rest service (e.g http call)
            else
            {
                using var httpClient = new HttpClient();
                var streamResult = await httpClient.GetStreamAsync("https://localhost:7229/data");
                var result = System.Text.Json.JsonSerializer.Deserialize<List<Models.Person>>(streamResult, new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return new PersonsResponse { Items = result };
            }
        }
    }
}
