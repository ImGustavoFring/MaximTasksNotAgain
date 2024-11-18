using Microsoft.AspNetCore.Mvc;
using Logic.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly QuickSortStringSorter _quickSorter;
        private readonly TreeSortStringSorter _treeSorter;

        public StringProcessorController(
            IStringProcessorService stringProcessorService,
            ICharacterCounterService characterCounterService,
            ILongestVowelSubstringService vowelSubstringService)
        {
            _stringProcessorService = stringProcessorService;
            _characterCounterService = characterCounterService;
            _vowelSubstringService = vowelSubstringService;
            _quickSorter = new QuickSortStringSorter();
            _treeSorter = new TreeSortStringSorter();
        }

        [HttpPost]
        public IActionResult ProcessString(string? input, SortMethod sortMethod = SortMethod.Quick)
        {
            try
            {
                var processedString = _stringProcessorService.ProcessString(input);
                var characterStatistics = _characterCounterService.CountCharacterOccurrences(processedString);
                var longestVowelSubstring = _vowelSubstringService.FindLongestVowelSubstring(processedString);

                IStringSorter sorter = sortMethod switch
                {
                    SortMethod.Tree => _treeSorter,
                    SortMethod.Quick => _quickSorter,
                    _ => throw new ArgumentOutOfRangeException(nameof(sortMethod), "Invalid sorting method.")
                };

                var sortedString = sorter.SortString(processedString);

                return Ok(new
                {
                    ProcessedString = processedString,
                    CharacterCounts = characterStatistics,
                    LongestVowelSubstring = longestVowelSubstring,
                    SortType = sorter.ToString(),
                    SortedString = sortedString
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }

    public enum SortMethod
    {
        Quick,
        Tree
    }
}
