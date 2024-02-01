using AutoMapper;
using Gateway.API.Responses;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Service.Grpc;
using System.Text.Json;

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
                var grpcServiceResult = await grpcClient.GetAllDataAsync(new Empty());
                return new PersonsResponse { Items = _mapper.Map<List<Models.Person>>(grpcServiceResult.Items) };
            }
            else
            {
                using var httpClient = new HttpClient();
                var restServiceStreamResult = await httpClient.GetStreamAsync("https://localhost:7229/data");
                var restServiceResult = JsonSerializer.Deserialize<List<Models.Person>>(restServiceStreamResult, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return new PersonsResponse { Items = restServiceResult };
            }
        }
    }
}
