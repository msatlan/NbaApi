using Microsoft.AspNetCore.Mvc;
using Service.PlayerService;

namespace NbaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService service;

        public PlayerController(IPlayerService service)
        {
            this.service = service;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAsync()
        {
            var players = await service.GetAllAsync();

            return Ok(players);
        }

        //[HttpPost("[action]")]
        //public async Task<IActionResult> CreateAsync([FromBody] PlayerRestModel playerRestModel)
        //{
        //    try
        //    {
        //        if (playerRestModel is null)
        //        {
        //            //_logger.LogError("Owner object sent from client is null.");
        //            return BadRequest("Owner object is null");
        //        }
        //        if (!ModelState.IsValid)
        //        {
        //            //_logger.LogError("Invalid owner object sent from client.");
        //            return BadRequest("Invalid model object");
        //        }

        //        var result = await service.AddAsync(playerRestModel);

        //        return StatusCode(StatusCodes.Status201Created, result);

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        [HttpGet("[action]/{id}/{embed?}")]
        public async Task<IActionResult> GetbyId([FromRoute] string id, [FromRoute] string? embed = null)
        {
            var player = await service.GetByIdAsync(new Guid(id), embed);

            if (player is null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No entity with provided Id was found");
            }

            return Ok(player);
        }
    }
}
