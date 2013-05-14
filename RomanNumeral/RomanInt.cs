using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RomanNumeral
{
    public class RomanInt
    {
        private Dictionary<int, string> digits = new Dictionary<int, string>
        {
            {100, "C"},
            { 50, "L"},
            { 10, "X"},
            {  5, "V"},
            {  1, "I"}
        };

        public RomanInt(int value)
        {
            Value = value;
        }

        public RomanInt(string numeral)
        {
            Value = Parse(numeral);
        }

        private class NumeralInfo
        {
            public NumeralInfo(int value, char digit, int prefixValue, char prefixDigit)
            {
                Value = value;
                Digit = digit;
                PrefixValue = prefixValue;
                PrefixDigit = prefixDigit;
            }

            public int Value { get; private set; }
            public char Digit { get; private set; }
            public int PrefixValue { get; private set; }
            public char PrefixDigit { get; private set; }
        }

        private static readonly NumeralInfo[] Numerals =
        {
            new NumeralInfo(1000, 'M', 100, 'C'),             
            new NumeralInfo( 500, 'D', 100, 'C'),             
            new NumeralInfo( 100, 'C',  10, 'X'),             
            new NumeralInfo(  50, 'L',  10, 'X'),             
            new NumeralInfo(  10, 'X',   1, 'I'),             
            new NumeralInfo(   5, 'V',   1, 'I'),             
        };

        public int Value { get; private set; }

        public override string ToString()
        {
            string result = string.Empty;
            int remainder = Value;

            foreach (var numeral in Numerals)
            {
                while (remainder >= numeral.Value - numeral.PrefixValue)
                    result += NearSignificantValue(numeral, ref remainder);
            }

            while (remainder > 0)
                result += AppendI(ref remainder);

            return result;
        }

        private static int Parse(string value)
        {
            int result = 0;
            int index = 0;

            while (index < value.Length)
                result += GetDigit(value, ref index);

            return result;
        }

        private static int GetDigit(string value, ref int index)
        {
            char? next = Lookahead(value, index);

            foreach (var numeral in Numerals)
            {
                if (value[index] == numeral.PrefixDigit && next.HasValue && next.Value == numeral.Digit)
                {
                    index += 2;
                    return numeral.Value - numeral.PrefixValue;
                }

                if (value[index] == numeral.Digit)
                {
                    ++index;
                    return numeral.Value;
                }
            }

            if (value[index] == 'I')
            {
                ++index;
                return 1;
            }

            return 0;
        }

        private static char? Lookahead(string numeral, int index)
        {
            return index + 1 < numeral.Length ? numeral[index + 1] : new char?();
        }

        private string AppendI(ref int remainder)
        {
            --remainder;
            return "I";
        }

        private string NearSignificantValue(NumeralInfo numeral, ref int remainder)
        {
            string result;
            if (remainder >= numeral.Value)
            {
                result = numeral.Digit.ToString();
                remainder -= numeral.Value;
            }
            else
            {
                result = string.Format("{0}{1}", numeral.PrefixDigit, numeral.Digit);
                remainder -= numeral.Value - numeral.PrefixValue;
            }

            return result;
        }

    }
}
