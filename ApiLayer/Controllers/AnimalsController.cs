using Microsoft.AspNetCore.Mvc;
using Paws_API.DomainLayer.Handlers.PetfinderHandler;

namespace Paws_API.ApiLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly ILogger<AnimalsController> _logger;
        private readonly IPetfinderHandler _petfinderHandler;

        public AnimalsController(ILogger<AnimalsController> logger, IPetfinderHandler petfinderHandler)
        {
            _logger = logger;
            _petfinderHandler = petfinderHandler;
        }

        [HttpGet("PetfinderAnimals")]
        public async Task<IActionResult> GetPetfinderAnimals()
        {
            try
            {
                var response = await _petfinderHandler.GetPetfinderAnimals();

                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
