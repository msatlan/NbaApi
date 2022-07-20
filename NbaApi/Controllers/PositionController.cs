using Microsoft.AspNetCore.Mvc;

namespace NbaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAsync()
        {
            //var players = await service.GetAllAsync();

            return Ok("bla");
        }
    }
}
