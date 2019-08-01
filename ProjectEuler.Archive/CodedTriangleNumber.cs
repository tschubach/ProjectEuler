using System;
using System.Linq;
using ProjectEuler.Utilities;

namespace ProjectEuler
{
    internal static class CodedTriangleNumber
    {
        public static int Run()
        {
            string filename = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\p042_words.txt";
            var words = Helpers.ReadLinesFromFile(filename, ',').ToList();
            var count = 0;

            for (int i = 0; i < words.Count; i++)
            {
                words[i] = words[i].Replace("\"", "");
            }

            foreach (var word in words)
            {
                if (Helpers.IsTriangleWord(Helpers.WordScore(word)))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
