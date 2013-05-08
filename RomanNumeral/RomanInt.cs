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

            if (remainder > 8)
                result = NearSignificantValue(10, "X", ref remainder);

            if (remainder > 3)
                result += NearSignificantValue(5, "V", ref remainder);

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

        private string NearSignificantValue(int value, string numeral, ref int remainder)
        {
            var result = remainder == value - 1 ? "I" + numeral : numeral;
            remainder = Math.Max(remainder - value, 0);
            return result;
        }

    }
}
