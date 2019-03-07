using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler
{
    public static class PowersOfTwo
    {
        public static IEnumerable<BigInteger> GetPowersOfTwoLessThan(BigInteger max)
        {
            var listOfPowers = new List<BigInteger>();
            BigInteger power = 1;

            while (power < max)
            {
                listOfPowers.Add(power);
                power *= 2;
            }

            return listOfPowers;
        }

        public static BigInteger SumOfDigits(int power)
        {
            int sumOfDigits = 0;
            BigInteger value = BigInteger.Pow(2, power);

            while (value > 0)
            {
                sumOfDigits += (int)(value % 10);
                value /= 10;
            }

            return sumOfDigits;
        }
    }
}
