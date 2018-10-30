using System;

namespace ProjectEuler
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Answer: \n" + TrinaryTriumph.LargestPrimeFactor(600851475143));
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
