using Microsoft.AspNetCore.Mvc;
using Paws_API.DomainLayer.Handlers.EmailHandler;
using Paws_API.DomainLayer.Models.Requests;

namespace Paws_API.ApiLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly ILogger<EmailController> _logger;
        private readonly IEmailHandler _emailHandler;

        public EmailController(ILogger<EmailController> logger, IEmailHandler emailPetsHandler)
        {
            _logger = logger;
            _emailHandler = emailPetsHandler;
        }

        [HttpPost]
        [Route("/FosterApplication")]
        public async Task<IActionResult> PostFosterApplication([FromBody] FosterEmailRequest request)
        {
            try
            {
                var response = await _emailHandler.SendFosterApplicationEmail(request);

                if (response.Success)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, response.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
