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

            for (int i = 1; i <= value; ++i)
                result += "I";

            return result;
        }
    }
}
