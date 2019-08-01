using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler
{
    public static class PowersOfTwo
    {
        public static IEnumerable<int> GetPowersOfTwo(BigInteger max)
        {
            var listOfPowers = new List<int>();

            while (max > 0)
            {
                listOfPowers.Add((int)max % 2);
                max /= 2;
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
