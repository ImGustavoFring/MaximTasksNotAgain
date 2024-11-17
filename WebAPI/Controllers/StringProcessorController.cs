using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StringProcessorController : ControllerBase
    {
        private readonly IStringProcessorService _stringProcessorService;

        public StringProcessorController(IStringProcessorService stringProcessorService)
        {
            _stringProcessorService = stringProcessorService;
        }

        [HttpPost]
        public IActionResult ProcessString(string? input)
        {
            try
            {
                var result = _stringProcessorService.ProcessString(input);
                return Ok(new { ProcessedString = result });
            }
            catch (Exception ex)
            {
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
