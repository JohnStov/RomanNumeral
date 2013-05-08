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
            string result;

            result = value <= 3 ? ThreeOrLess() : FourOrFive();

            return result;
        }

        private string ThreeOrLess()
        {
            string result = string.Empty;
            for (int i = 1; i <= value; ++i)
            {
                result += "I";
            }
            return result;
        }

        private string FourOrFive()
        {
            return value == 4 ? "IV" : "V";
        }

    }
}
