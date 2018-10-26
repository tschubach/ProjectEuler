namespace ProjectEuler
{
    public static class CollatzSequence
    {
        private static int[] cache;

        public static int LongestSequence(int number)
        {
            var sequenceLength = 0;
            var startingNumber = 0;

            InitializeCache(number);

            for (int i = 2; i < number; i++)
            {
                long sequence = i;
                var count = 0;

                while (sequence != 1 && sequence >= i)
                {
                    count++;
                    sequence = (sequence % 2 == 0) ? (sequence / 2) : (3 * sequence) + 1;
                }

                cache[i] = count + cache[sequence];
                if (cache[i] > sequenceLength)
                {
                    sequenceLength = cache[i];
                    startingNumber = i;
                }
            }

            return startingNumber;
        }

        private static void InitializeCache(int number)
        {
            cache = new int[number + 1];

            // Initialize cache
            for (int i = 0; i < cache.Length; i++)
            {
                cache[i] = -1;
            }
            cache[1] = 1;
        }
    }
}
