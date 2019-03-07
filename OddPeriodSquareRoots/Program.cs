using System;
using System.Collections.Generic;

namespace OddPeriodSquareRoots
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var sqrts = new Dictionary<int, double>()
                {
                    {2, Math.Sqrt(2)},
                    {3, Math.Sqrt(3)},
                    {5, Math.Sqrt(5)},
                    {6, Math.Sqrt(6)},
                    {7, Math.Sqrt(7)},
                    {8, Math.Sqrt(8)},
                    {10, Math.Sqrt(10)},
                    {11, Math.Sqrt(11)},
                    {12, Math.Sqrt(12)},
                    {13, Math.Sqrt(13)},
                };

                //Console.WriteLine("Answer: " + SquareRootPeriods());

                foreach (var sqrt in sqrts)
                {
                    Console.WriteLine(sqrt.Key.ToString() + ": " + FractionPeriod(sqrt.Value));
                }
                Console.WriteLine("Answer: " + FractionPeriod(Math.Sqrt(23)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private static int SquareRootPeriods()
        {
            var count = 4;

            for (int i = 14; i <= 10000; i++)
            {
                if (!IsPerfectSquare(i))
                {
                    if (FractionPeriod(Math.Sqrt(i)) % 2 != 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private static int FractionPeriod(double value)
        {
            var period = 0;
            double number = value;
            int term = (int)number;
            double mantissa = 1 / (value - term);
            var mantissas = new List<double>();

            while (!mantissas.Contains(mantissa))
            {
                period++;
                mantissas.Add(mantissa);
                number = (1 / mantissa);
                term = (int)number;
                mantissa = 1 / (value - term);
            }

            return period;
        }

        private static bool IsPerfectSquare(int square)
        {
            return (Math.Sqrt(square) % 1 == 0);
        }
    }
}
