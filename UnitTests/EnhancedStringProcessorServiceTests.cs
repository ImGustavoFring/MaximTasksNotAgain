using Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Services;

namespace UnitTests
{
    public class EnhancedStringProcessorServiceTests : StringProcessorServiceTests
    {
        protected override IStringProcessorService service => new EnhancedStringProcessorService();

        [Fact]
        public void ProcessStringInvalidCharactersThrowsArgumentException()
        {
            var input = "abc123";
            var expectedError = "Input contains invalid characters: 1, 2, 3";

            var exception = Assert.Throws<ArgumentException>(() => service.ProcessString(input));
            Assert.Equal(expectedError, exception.Message);
        }

        [Fact]
        public void ProcessStringValidCharactersReturnsProcessedString()
        {
            var input = "abcdefgh";
            var expected = "dcbahgfe";

            var result = service.ProcessString(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ProcessStringWithMixedCaseThrowsArgumentException()
        {
            var input = "AbcDef";
            var expectedError = "Input contains invalid characters: A, D";

            var exception = Assert.Throws<ArgumentException>(() => service.ProcessString(input));
            Assert.Equal(expectedError, exception.Message);
        }
    }
}
