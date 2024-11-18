using Microsoft.AspNetCore.Mvc;
using Logic.Services;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StringProcessorController : ControllerBase
    {
        private readonly IStringProcessorService _stringProcessorService;
        private readonly ICharacterCounterService _characterCounterService;
        private readonly ILongestVowelSubstringService _vowelSubstringService;

        public StringProcessorController(
            IStringProcessorService stringProcessorService,
            ICharacterCounterService characterCounterService,
            ILongestVowelSubstringService vowelSubstringService)
        {
            _stringProcessorService = stringProcessorService;
            _characterCounterService = characterCounterService;
            _vowelSubstringService = vowelSubstringService;
        }

        [HttpPost]
        public IActionResult ProcessString(string? input)
        {
            try
            {
                var processedString = _stringProcessorService.ProcessString(input);
                var characterStatistics = _characterCounterService.CountCharacterOccurrences(processedString);
                var longestVowelSubstring = _vowelSubstringService.FindLongestVowelSubstring(processedString);

                return Ok(new
                {
                    ProcessedString = processedString,
                    CharacterCounts = characterStatistics,
                    LongestVowelSubstring = longestVowelSubstring
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
