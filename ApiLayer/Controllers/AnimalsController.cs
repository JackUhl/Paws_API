using Microsoft.AspNetCore.Mvc;
using Paws_API.DomainLayer.Handlers.PetfinderHandler;

namespace Paws_API.ApiLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly ILogger<AnimalsController> _logger;
        private readonly IAnimalsHandler _animalsHandler;

        public AnimalsController(ILogger<AnimalsController> logger, IAnimalsHandler animalsHandler)
        {
            _logger = logger;
            _animalsHandler = animalsHandler;
        }

        [HttpGet("AnimalsInfo")]
        public async Task<IActionResult> AnimalsInfo()
        {
            try
            {
                var response = await _animalsHandler.GetPetfinderAnimals();

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
