using System;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler
{
    public static class PowersOfTwo
    {
        public static List<int> List(int max)
        {
            var listOfPowers = new List<int>();
            var power = 1;

            while (power < max)
            {
                power *= 2;
                if (power < max)
                {
                    listOfPowers.Add(power);
                }
            }

            return listOfPowers;
        }

        public static int SumOfDigits(int power)
        {
            int sumOfDigits = 0;
            BigInteger value = BigInteger.Pow(2, power);

            while (value > 0)
            {
                sumOfDigits += (int) (value % 10);
                value /= 10;
            }

            return sumOfDigits;
        }
    }
}
