using System;
using System.Collections.Generic;
using ProjectEuler.Utilities;

namespace ProjectEuler
{
    internal static class RomanNumerals
    {
        private static readonly Dictionary<string, int> Map = new Dictionary<string, int>()
        {
            { "I", 1 },
            { "V", 5 },
            { "X", 10 },
            { "L", 50 },
            { "C", 100 },
            { "D", 500 },
            { "M", 1000 }
        };

        internal static int Problem89()
        {
            var result = 0;
            string filename = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\p089_roman.txt";
            var numberList = Helpers.ReadLinesFromFile(filename);

            // Read from right to left; if next char is less than current, subtract
            return result;
        }
    }
}
