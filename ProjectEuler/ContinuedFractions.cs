using System.Numerics;

namespace ProjectEuler
{
    internal static class ContinuedFractions
    {
        internal static long ConvergentsOfE()
        {
            long sum = 0;
            var alpha = new BigInteger[102];
            var numerators = new BigInteger[102];

            // Initialize terms
            alpha[0] = 2;
            numerators[0] = 2;
            numerators[1] = 3;
            numerators[2] = 8;

            BigInteger set = 1;
            for (int i = 1; i < alpha.Length; i++)
            {

                alpha[i] = 1;
                if ((i % 3) == 2)
                {
                    alpha[i] = set * 2;
                    set++;
                }

                numerators[i] = (i <= 2) ? numerators[i] : (alpha[i] * numerators[i - 1]) + numerators[i - 2];
            }

            var digits = numerators[99].ToString().ToCharArray();

            foreach (var digit in digits)
            {
                sum += long.Parse(digit.ToString());
            }

            return sum;
        }
    }
}
