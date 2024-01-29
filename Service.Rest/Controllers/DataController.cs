using Microsoft.AspNetCore.Mvc;
using Service.Rest.Services;

namespace Service.Rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IDataService _dataService;
        public DataController(IDataService dataService)
        {
            _dataService = dataService;
        }
        public async Task<IActionResult> GetAllData()
        {
            return Ok(await _dataService.GetAllData());
        }
    }
}