using FluentAssertions;

using RomanNumeral;

using Xunit;

namespace RomanNumeralTest
{
    public class RomanIntTest
    {
        [Fact]
        public void OneIsI()
        {
            var num = new RomanInt(1);
            num.ToString().Should().Be("I");
        }
    }
}
