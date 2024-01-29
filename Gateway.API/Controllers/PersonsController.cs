using Gateway.API.Responses;
using Gateway.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {

        private readonly IPersonsService _personsService;
        public PersonsController(IPersonsService personsService)
        {
            _personsService = personsService;
        }

        public async Task<IActionResult> Get([FromQuery(Name = "requested-from-grpc")] bool requestedFromGrpc)
        {
            var personsResponse = await _personsService.GetAllPersons(requestedFromGrpc);
            return Ok(new BaseResponse<PersonsResponse>
            {
                HasSucceeded = true,
                Result = personsResponse
            });
        }
    }
}