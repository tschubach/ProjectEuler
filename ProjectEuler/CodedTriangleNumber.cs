using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal static class CodedTriangleNumber
    {
        public static int Run()
        {
            string filename = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\p042_words.txt";
            var words = Utilities.ReadLinesFromFile(filename, ",");
            var count = 0;

            for (int i = 0; i < words.Count; i++)
            {
                words[i] = words[i].Replace("\"", "");
            }

            foreach (var word in words)
            {
                if (Utilities.IsTriangleWord(Utilities.WordScore(word)))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
