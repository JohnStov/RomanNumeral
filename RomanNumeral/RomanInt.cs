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

            while (remainder >= 40)
                result += NearSignificantValue(50, "L", ref remainder);

            while (remainder > 8)
                result += NearSignificantValue(10, "X", ref remainder);

            if (remainder > 3)
                result += NearSignificantValue(5, "V", ref remainder);

            while (remainder > 0)
                result += AppendI(ref remainder);

            return result;
        }

        private string AppendI(ref int remainder)
        {
            --remainder;
            return "I";
        }

        private string NearSignificantValue(int value, string numeral, ref int remainder)
        {
            string result;
            if (numeral == "X" || numeral =="V")
                result = remainder == value - 1 ? "I" + numeral : numeral;
            else
                result = remainder == value - 10 ? "X" + numeral : numeral;
            remainder = Math.Max(remainder - value, 0);
            return result;
        }

    }
}
