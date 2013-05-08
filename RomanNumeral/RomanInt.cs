using System;

namespace RomanNumeral
{
    public class RomanInt
    {
        private readonly int value;

        public RomanInt(int value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            string result = string.Empty;
            int remainder = value;
            
            if (value > 3)
                result = FourOrFive(ref remainder);

            result += ThreeOrLess(remainder);

            return result;
        }

        private string ThreeOrLess(int remainder)
        {
            string result = string.Empty;
            for (int i = 1; i <= remainder; ++i)
            {
                result += "I";
            }
            return result;
        }

        private string FourOrFive(ref int remainder)
        {
            var result = remainder == 4 ? "IV" : "V";
            remainder = Math.Max(remainder - 5, 0);
            return result;
        }

    }
}
