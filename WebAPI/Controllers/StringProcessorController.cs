using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;
using Logic.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StringProcessorController : ControllerBase
    {
        private readonly IStringProcessorService _stringProcessorService;
        private readonly ICharacterCounterService _characterCounterService;

        public StringProcessorController(IStringProcessorService stringProcessorService,
            ICharacterCounterService characterCounterService)
        {
            _stringProcessorService = stringProcessorService;
            _characterCounterService = characterCounterService;
        }

        [HttpPost]
        public IActionResult ProcessString(string? input)
        {
            try
            {
                var processedString = _stringProcessorService.ProcessString(input);
                var characterStatistics = _characterCounterService.CountCharacterOccurrences(processedString);

                return Ok(new
                {
                    ProcessedString = processedString,
                    CharacterCounts = characterStatistics
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
