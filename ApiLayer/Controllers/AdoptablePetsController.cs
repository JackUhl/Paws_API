using Microsoft.AspNetCore.Mvc;
using Paws_API.DomainLayer.Handlers.PetfinderHandler;

namespace Paws_API.ApiLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdoptablePetsController : ControllerBase
    {
        private readonly ILogger<AdoptablePetsController> _logger;
        private readonly IAdoptablePetsHandler _adoptablePetsHandler;

        public AdoptablePetsController(ILogger<AdoptablePetsController> logger, IAdoptablePetsHandler adoptablePetsHandler)
        {
            _logger = logger;
            _adoptablePetsHandler = adoptablePetsHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AdoptablePets()
        {
            try
            {
                var response = await _adoptablePetsHandler.GetPetfinderAnimals();

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
