using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Utilities;

namespace ProjectEuler
{
    internal static class Pandigital
	{
		public static IEnumerable<string> Permutations(int maxDigit, bool includeZero)
		{
			var start = includeZero ? 0 : 1;
			var temp = "";

			for (int i = maxDigit; i >= start; i--)
			{
				temp += i.ToString();
			}

			return Helpers.Permutate(temp, includeZero);
		}

		public static long NDigitPrime()
		{
			// Find the largest n-digit pandigital prime
			// -- Largest possible = 987654321
			// For n-digits, get all permutations, then check each for prime
			// Compare each prime against most recent found, save largest
			// If a prime found, for a given n, no need to check lower values of n

			// Start with n = 9 and work down
			long result = 0;
			var maxFound = false;

			for (int i = 9; i > 1; i--)
			{
				var digits = i;
				var num = "";
				for (int j = 1; j <= digits; j++)
				{
					num += j.ToString();
				}

				var permutations = Helpers.GetPermutations(num).ToList();
				for (int k = permutations.Count() - 1; k >= 0; k--)
				{
					if (Helpers.IsPrime(long.Parse(permutations[k])))
					{
						maxFound = true;
						result = long.Parse(permutations[k]);
						break;
					}
				}

				if (maxFound)
				{
					break;
				}
			}

			return result;
		}

		public static ulong SubstringDivisibility()
		{
			ulong sum = 0;
			var permutations = Permutations(9, true);

			foreach (var perm in permutations)
			{
				var sub234 = int.Parse(perm.Substring(1, 3));
				var sub345 = int.Parse(perm.Substring(2, 3));
				var sub456 = int.Parse(perm.Substring(3, 3));
				var sub567 = int.Parse(perm.Substring(4, 3));
				var sub678 = int.Parse(perm.Substring(5, 3));
				var sub789 = int.Parse(perm.Substring(6, 3));
				var sub890 = int.Parse(perm.Substring(7, 3));

				if (sub234 % 2 == 0 && sub345 % 3 == 0 && sub456 % 5 == 0 && sub567 % 7 == 0 &&
					 sub678 % 11 == 0 && sub789 % 13 == 0 && sub890 % 17 == 0)
				{
					sum += ulong.Parse(perm);
				}
			}

			return sum;
		}
	}
}
