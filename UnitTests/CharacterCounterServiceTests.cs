using Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class CharacterCounterServiceTests
    {
        private ICharacterCounterService _service => new CharacterCounterService();

        [Fact]
        public void CountCharacterOccurrences_ValidString_ReturnsCorrectCounts()
        {
            var input = "aabbcc";
            var expected = new Dictionary<char, int>
            {
                { 'a', 2 },
                { 'b', 2 },
                { 'c', 2 }
            };

            var result = _service.CountCharacterOccurrences(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountCharacterOccurrences_EmptyString_ThrowsArgumentException()
        {
            var input = "";

            var exception = Assert.Throws<ArgumentException>(() => _service.CountCharacterOccurrences(input));
            Assert.Equal("Input string cannot be null or empty.", exception.Message);
        }

        [Fact]
        public void CountCharacterOccurrences_SingleCharacter_ReturnsCorrectCount()
        {
            var input = "aaaa";
            var expected = new Dictionary<char, int>
            {
                { 'a', 4 }
            };

            var result = _service.CountCharacterOccurrences(input);

            Assert.Equal(expected, result);
        }
    }
}
