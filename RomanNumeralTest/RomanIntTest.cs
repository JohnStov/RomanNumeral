using FluentAssertions;

using RomanNumeral;

using Xunit;
using Xunit.Extensions;

namespace RomanNumeralTest
{
    public class RomanIntTest
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        public void ArabicToRoman(int value, string expected)
        {
            var num = new RomanInt(value);
            num.ToString().Should().Be(expected);
        }

        [Fact]
        public void True()
        {
            Assert.True(true);
        }
    }
}
