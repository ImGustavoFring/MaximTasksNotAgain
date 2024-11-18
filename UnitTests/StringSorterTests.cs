using Logic.Services;
using Xunit;

namespace UnitTests
{
    public abstract class StringSorterTests
    {
        protected IStringSorter sorter;

        [Fact]
        public void SortStringSortsAlphabetically()
        {
            var input = "dcba";

            var result = sorter.SortString(input);

            Assert.Equal("abcd", result);
        }

        [Fact]
        public void SortStringEmptyStringThrowsException()
        {
            Assert.Throws<ArgumentException>(() => sorter.SortString(string.Empty));
        }

        [Fact]
        public void SortStringNullStringThrowsException()
        {
            Assert.Throws<ArgumentException>(() => sorter.SortString(null));
        }

        [Fact]
        public void SortStringStringWithDuplicatesSortsCorrectly()
        {
            var input = "banana";

            var result = sorter.SortString(input);

            Assert.Equal("aaabnn", result);
        }

        [Fact]
        public void SortStringAlreadySortedReturnsSameString()
        {
            var input = "abcdef";

            var result = sorter.SortString(input);

            Assert.Equal(input, result);
        }
    }
}
