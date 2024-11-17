using WebAPI.Services;

namespace UnitTests
{
    public class StringProcessorServiceTests
    {
        protected virtual IStringProcessorService service => new StringProcessorService();

        [Fact]
        public void ProcessStringEvenLengthReturnsProcessedString()
        {
            var input = "abcdef";
            var expected = "cbafed";

            var result = service.ProcessString(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ProcessStringOddLengthReturnsProcessedString()
        {
            var input = "abcde";
            var expected = "edcbaabcde";

            var result = service.ProcessString(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ProcessStringNullInputThrowsArgumentException()
        {
            string input = null;

            var exception = Assert.Throws<ArgumentException>(() => service.ProcessString(input));
            Assert.Equal("Input string cannot be null or empty.", exception.Message);
        }

        [Fact]
        public void ProcessStringEmptyInputThrowsArgumentException()
        {
            var input = "";

            var exception = Assert.Throws<ArgumentException>(() => service.ProcessString(input));
            Assert.Equal("Input string cannot be null or empty.", exception.Message);
        }

        [Fact]
        public void ProcessStringWhitespaceInputThrowsArgumentException()
        {
            var input = "   ";

            var exception = Assert.Throws<ArgumentException>(() => service.ProcessString(input));
            Assert.Equal("Input string cannot be null or empty.", exception.Message);
        }
    }
}
