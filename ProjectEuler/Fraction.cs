namespace ProjectEuler
{
    internal sealed class Fraction
    {
        private readonly int _numerator;
        private readonly int _denominator;
        private readonly int _commonDigit;

        public Fraction(int numerator, int denominator, int commonDigit)
        {
            _numerator = numerator;
            _denominator = denominator;
            _commonDigit = commonDigit;
        }

        public int Numerator => _numerator;

        public int Denominator => _denominator;

        public int CommonDigit => _commonDigit;

    }
}
