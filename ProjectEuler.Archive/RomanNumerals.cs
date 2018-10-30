using System;
using System.Collections.Generic;
using ProjectEuler.Utilities;

namespace ProjectEuler.Archive
{
	internal static class RomanNumerals
	{
		private static readonly string _filename = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\p089_roman.txt";

		private static readonly Dictionary<string, int> RomanToArabicMap = new Dictionary<string, int>()
		  {
				{ "I", 1 },
				{ "IV", 4 },
				{ "V", 5 },
				{ "IX", 9 },
				{ "X", 10 },
				{ "XL", 40 },
				{ "L", 50 },
				{"XC", 90 },
				{ "C", 100 },
				{ "CD", 400 },
				{ "D", 500 },
				{ "CM", 900 },
				{ "M", 1000 }
		  };

		private static readonly Dictionary<int, string> ArabicToRomanMap = new Dictionary<int, string>()
		  {
				{ 1, "I" },
				{ 4, "IV" },
				{ 5, "V" },
				{ 9, "IX" },
				{ 10, "X" },
				{ 40, "XL" },
				{ 50, "L" },
				{ 90, "XC" },
				{ 100, "C" },
				{ 400, "CD" },
				{ 500, "D" },
				{ 900, "CM" },
				{ 1000, "M" }
		  };

		internal static int Problem89()
		{
			var count = 0;
			var newValue = "";
			var numberList = Helpers.ReadLinesFromFile(_filename);
			//var numberList = new List<string>() { "XXXXVIIII" };
			var origLength = 0;
			var newLength = 0;

			foreach (var number in numberList)
			{
				Console.Write(number);
				origLength += number.Length;
				newValue = ArabicToRoman(RomanToArabic(number));
				newLength += newValue.Length;
				Console.WriteLine(" - " + newValue);
				count = (origLength - newLength);
			}

			return count;
		}

		internal static int RomanToArabic(string roman)
		{
			var curr = 0;
			var prev = 0;
			var value = 0;

			// Read from right to left; if next char is less than current, subtract
			for (int i = roman.Length - 1; i >= 0; i--)
			{
				curr = RomanToArabicMap[roman[i].ToString()];
				value = curr < prev ? value - curr : value + curr;
				prev = curr;
			}

			return value;
		}

		public static string ArabicToRoman(int arabic)
		{
			var value = "";
			var repeat = 0;
			var divisor = 1000;

			// Thousands
			repeat = (int)(arabic / 1000);
			value = (repeat > 0) ? value += Concatenate(ArabicToRomanMap[1000], repeat) : value;
			arabic %= 1000;
			divisor /= 10;

			// Hundreds place
			var test = (int)(arabic / divisor) * divisor;
			repeat = 0;
			var hundreds = "";

			if (test > 0)
			{
				repeat = MapArabicToRoman(test, divisor, out hundreds);
				value += hundreds;
				value += Concatenate(ArabicToRomanMap[divisor], repeat);
			}
			arabic %= 100;
			divisor /= 10;

			// Tens place
			repeat = 0;
			test = (int)(arabic / divisor) * divisor;
			var tens = "";

			if (test > 0)
			{
				repeat = MapArabicToRoman(test, divisor, out tens);
				value += tens;
				value += Concatenate(ArabicToRomanMap[divisor], repeat);
			}
			arabic %= 10;
			divisor /= 10;

			// Ones place
			repeat = 0;
			test = (int)(arabic / divisor) * divisor;
			var ones = "";

			if (test > 0)
			{
				repeat = MapArabicToRoman(test, divisor, out ones);
				value += ones;
				value += Concatenate(ArabicToRomanMap[divisor], repeat);
			}

			return value;
		}

		private static int MapArabicToRoman(int test, int unit, out string roman)
		{
			var repeat = 0;
			while (!ArabicToRomanMap.TryGetValue(test, out roman))
			{
				test -= unit;
				repeat++;
			}

			return repeat;
		}

		private static string Concatenate(string v, int multiplier)
		{
			var result = "";
			if (multiplier == 0)
			{
				return result;
			}

			for (int i = 0; i < multiplier; i++)
			{
				result += v;
			}

			return result;
		}
	}
}
