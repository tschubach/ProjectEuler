using System;

namespace ProjectEuler
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Answer: " + ContinuedFractions.OddPeriodicSquares());
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
