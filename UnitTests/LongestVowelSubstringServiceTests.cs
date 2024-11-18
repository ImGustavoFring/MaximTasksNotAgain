using Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class LongestVowelSubstringServiceTests
    {
        private readonly ILongestVowelSubstringService _service;

        public LongestVowelSubstringServiceTests()
        {
            _service = new LongestVowelSubstringService();
        }

        [Fact]
        public void FindLongestVowelSubstringSingleVowelReturnsSameVowel()
        {
            var input = "aa";
            var expected = "aa";

            var result = _service.FindLongestVowelSubstring(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindLongestVowelSubstringMultipleVowelsReturnsLongestSubstring()
        {
            var input = "abcdef";
            var expected = "abcde";

            var result = _service.FindLongestVowelSubstring(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindLongestVowelSubstringNoMatchingSubstringReturnsEmptyString()
        {
            var input = "bcdfg";

            var result = _service.FindLongestVowelSubstring(input);

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void FindLongestVowelSubstringEmptyStringThrowsArgumentException()
        {
            var input = "";

            var exception = Assert.Throws<ArgumentException>(() => _service.FindLongestVowelSubstring(input));

            Assert.Equal("Input string cannot be null or empty.", exception.Message);
        }

        [Fact]
        public void FindLongestVowelSubstringStringWithMixedCharactersReturnsCorrectSubstring()
        {
            var input = "abracadabra";
            var expected = "abracadabra";

            var result = _service.FindLongestVowelSubstring(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindLongestVowelSubstringMultipleSubstringsReturnsLongest()
        {
            var input = "applebananaorange";
            var expected = "applebananaorange";

            var result = _service.FindLongestVowelSubstring(input);

            Assert.Equal(expected, result);
        }
    }
}
