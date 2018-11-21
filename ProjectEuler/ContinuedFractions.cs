using System;
using System.Collections.Generic;
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

        internal static int OddPeriodicSquares()
        {
            int upperBound = 10000;
            int result = 0;

            for (int n = 2; n <= upperBound; n++)
            {
                int a0 = (int)Math.Sqrt(n);

                if (a0 * a0 == n)
                {
                    continue;
                }

                int period = 0;
                int d = 1;
                int m = 0;
                int a = a0;

                do
                {
                    m = d * a - m;
                    d = (n - m * m) / d;
                    a = (a0 + m) / d;
                    period++;
                } while (a != 2 * a0);

                if (period % 2 == 1)
                {
                    result++;
                }
            }

            return result;
        }

        public static int FractionPeriod(double value)
        {
            int period = 0;
            double number = value;
            List<double> mantissas = new List<double>();

            int term = (int)number;
            double mantissa = (value - term);

            while (!mantissas.Contains(mantissa))
            {
                mantissas.Add(mantissa);
                period++;
                var reciprocal = 1 / mantissa;
                term = (int) reciprocal;
                mantissa = (reciprocal - term);
            }

            return period;
        }
    }
}
