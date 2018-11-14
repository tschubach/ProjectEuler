using System;

namespace ProjectEuler
{
    internal static class Probability
    {
        internal static long ArrangedProbability()
        {
            long blue = 85;
            long total = 120;
            long minDiscs = 1000000000001;

            while (total < minDiscs)
            {
                var blue2 = (3 * blue) + (2 * total) - 2;
                var total2 = (4 * blue) + (3 * total) - 3;
                blue = blue2;
                total = total2;
            }

            return blue;
        }
    }
}
