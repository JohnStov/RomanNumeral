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
        [InlineData(9, "IX")]
        [InlineData(14, "XIV")]
        [InlineData(19, "XIX")]
        [InlineData(40, "XL")]
        [InlineData(49, "XLIX")]
        [InlineData(50, "L")]
        [InlineData(60, "LX")]
        [InlineData(69, "LXIX")]
        [InlineData(89, "LXXXIX")]
        [InlineData(90, "XC")]
        [InlineData(999, "CMXCIX")]
        [InlineData(2013, "MMXIII")]
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
