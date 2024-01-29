using Gateway.API.Responses;

namespace Gateway.API.Services
{
    public interface IPersonsService
    {
        Task<PersonsResponse> GetAllPersons(bool isFromGrpcService = false);
    }
}
