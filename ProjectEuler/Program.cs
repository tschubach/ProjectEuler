using System;

namespace ProjectEuler
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Answer: " + ContinuedFractions.FractionPeriod(Math.Sqrt(3)));
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
    }
}
