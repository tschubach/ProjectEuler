using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Utilities
{
    public static class Helpers
    {

        public static IEnumerable<string> ReadLinesFromFile(string filename)
        {
            var line = "";
            var lines = new List<string>();

            var r = new StreamReader(filename);
            while ((line = r.ReadLine()) != null)
            {
                lines.Add(line);
            }

            r.Close();
            return lines;
        }

        public static IEnumerable<string> ReadLinesFromFile(string filename, char separator)
        {
            var result = new List<string>();
            var lines = ReadLinesFromFile(filename);

            if (separator == null)
            {
                return lines;
            }

            foreach (var line in lines)
            {
                string[] temp = line.Split(separator);
                for (int i = 0; i < temp.Length; i++)
                {
                    result.Add(temp[i]);
                }
            }

            return result;
        }

        public static IEnumerable<long> PrimeFactors(long num)
        {
            var result = new List<long>();

            // Take out the 2s.
            while (num % 2 == 0)
            {
                //  Just add a single occurrence
                if (!result.Contains(2))
                {
                    result.Add(2);
                }
                num /= 2;
            }

            // Take out other primes.
            long factor = 3;
            while (factor * factor <= num)
            {
                if (num % factor == 0)
                {
                    // This is a factor.
                    if (!result.Contains(factor))
                    {
                        result.Add(factor);
                    }
                    num /= factor;
                }
                else
                {
                    // Go to the next odd number.
                    factor += 2;
                }
            }

            // If num is not 1, then whatever is left is prime.
            if (num > 1)
            {
                if (!result.Contains(num))
                {
                    result.Add(num);
                }
            }

            return result;
        }

        public static int[] Primes(int max)
        {
            var primes = new List<int>();

            for (int i = 2; i <= max; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add((i));
                }
            }

            primes.Sort();
            return primes.ToArray();
        }

        public static int SumOfFactors(int number)
        {
            int result = 0;


            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    result += i;
                }
            }

            return result;
        }

        public static long SumOfFactorsPrime(long number, long[] primeList)
        {
            long n = number;
            long sum = 1;
            long p = primeList[0];
            long j;
            long i = 0;

            while (p * p <= n && n > 1 && i < primeList.Length)
            {
                p = primeList[i];

                if (n % p == 0)
                {
                    j = p * p;
                    n = n / p;
                    while (n % p == 0)
                    {
                        j = j * p;
                        n = n / p;
                    }
                    sum = sum * (j - 1) / (p - 1);
                }

                i++;
            }

            // A prime factor larger than the square root remains
            if (n > 1)
            {
                sum *= n + 1;
            }


            return sum - number;
        }

        /// <summary>
        /// Returns list of prime numbers
        /// </summary>
        /// <param name="upperLimit"></param>
        /// <returns></returns>
        public static long[] ESieve(long upperLimit)
        {
            int sieveBound = (int)(upperLimit - 1) / 2;
            int upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;

            BitArray primeBits = new BitArray(sieveBound + 1, true);

            for (int i = 1; i <= upperSqrt; i++)
            {
                if (primeBits.Get(i))
                {
                    for (int j = i * 2 * (i + 1); j <= sieveBound; j += 2 * i + 1)
                    {
                        primeBits.Set(j, false);
                    }
                }
            }

            var numbers = new List<long>
            {
                2
            };

            for (int i = 1; i <= sieveBound; i++)
            {
                if (primeBits.Get(i))
                {
                    numbers.Add(2 * i + 1);
                }
            }

            numbers.Sort();
            return numbers.ToArray();
        }

        public static bool IsAbundantNumber(int number)
        {
            return (SumOfFactors(number) > number);
        }

        public static void RotateRight(IList sequence, int count)
        {
            var tmp = sequence[count - 1];
            sequence.RemoveAt(count - 1);
            sequence.Insert(0, tmp);
        }

        public static IEnumerable<IList> Permutate(IList sequence, int count)
        {
            if (count == 1)
            {
                yield return sequence;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    foreach (var perm in Permutate(sequence, count - 1))
                    {
                        yield return perm;
                    }

                    RotateRight(sequence, count);
                }
            }
        }

        public static IEnumerable<string> Permutate(string word)
        {
            string a = word;
            var list = new List<string>();
            foreach (List<char> perm in Permutate(a.ToCharArray().ToList(), a.Length))
            {
                string s = new string(perm.ToArray());
                list.Add(s);
            }

            list.Sort();
            return list;
        }

        public static IEnumerable<string> Permutate(long number, bool includeZero = false)
        {
            var numbers = new List<string>();

            foreach (List<char> perm in Permutate(number.ToString().ToCharArray().ToList(), number.ToString().Length))
            {
                string s = new string(perm.ToArray());
                if (!includeZero && s.IndexOf("0") != -1)
                {
                    continue;
                }

                numbers.Add(s);
            }

            numbers.Sort();
            return numbers;
        }

        public static IEnumerable<string> Permutate(string number, bool includeZero)
        {
            var numbers = new List<string>();

            foreach (List<char> perm in Permutate(number.ToCharArray().ToList(), number.Length))
            {
                string s = new string(perm.ToArray());
                if (!includeZero && s.IndexOf("0") != -1)
                {
                    continue;
                }

                numbers.Add(s);
            }

            numbers.Sort();
            return numbers;
        }

        private static void CreatePermutations(string start, List<char> charList, List<string> permutations)
        {
            for (int i = 0; i < charList.Count; i++)
            {
                var current = charList[i];
                charList.RemoveAt(i);
                if (charList.Count == 0)
                {
                    var permutation = $"{start}{current}";
                    if (!permutations.Contains(permutation))
                    {
                        permutations.Add(permutation);
                    }
                }
                else
                {
                    CreatePermutations($"{start}{current}", charList, permutations);
                }

                charList.Insert(i, current);
            }
        }

        private static void CreatePermutations(string start, List<int> intList, List<string> permutations)
        {
            for (int i = 0; i < intList.Count; i++)
            {
                var current = intList[i];
                intList.RemoveAt(i);
                if (intList.Count == 0)
                {
                    var permutation = $"{start}{current}";
                    if (!permutations.Contains(permutation))
                    {
                        permutations.Add(permutation);
                    }
                }
                else
                {
                    CreatePermutations($"{start}{current}", intList, permutations);
                }

                intList.Insert(i, current);
            }
        }

        public static IEnumerable<string> GetPermutations(string chars)
        {
            var permutations = new List<string>();
            var charList = chars.ToArray().ToList();

            CreatePermutations(null, charList, permutations);

            return permutations;
        }

        //public static bool IsPermutation(long first, long second)
        //{
        //    var result = false;


        //    return result;
        //}

        // Function to count the total number
        // of digits in a number.
        public static int NumDigits(long number)
        {
            int count = 0;
            while (number > 0)
            {
                count++;
                number = number / 10;
            }

            return count;
        }

        public static bool IsPrime(long candidate)
        {
            if (candidate < 2)
            {
                return false;
            }

            if (candidate < 4)
            {
                return true;
            }

            if (candidate % 2 == 0)
            {
                return false;
            }

            if (candidate < 9)
            {
                return true;
            }

            if (candidate % 3 == 0)
            {
                return false;
            }

            if (candidate < 25)
            {
                return true;
            }

            var s = (int)Math.Sqrt(candidate);
            for (int i = 5; i <= s; i += 6)
            {
                if (candidate % i == 0)
                {
                    return false;
                }

                if (candidate % (i + 2) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsRepeatingDecimal(int numerator, int denominator)
        {
            if (numerator % denominator == 0)
                return false;

            var primes = PrimeFactors(denominator);

            foreach (int n in primes)
            {
                if (n != 2 && n != 5)
                    return true;
            }

            return false;
        }

        private static int FactorialDigitSum(int num)
        {
            BigInteger factorial = 1;

            for (int i = 2; i <= num; i++)
            {
                factorial *= i;
            }

            return SumOfDigits(factorial);
            ;
        }

        public static long Factorial(long num)
        {
            long factorial = 1;

            for (int i = 2; i <= num; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        private static int SumOfDigits(BigInteger num)
        {
            int sumOfDigits = 0;

            while (num > 0)
            {
                sumOfDigits += (int)(num % 10);
                num /= 10;
            }

            return sumOfDigits;
        }

        public static long[] DigitArray(long n)
        {
            var numDigits = n.ToString().Length;
            var result = new long[numDigits];
            for (int i = result.Length - 1; i >= 0; i--)
            {
                result[i] = n % 10;
                n /= 10;
            }
            return result;
        }

        public static long DigitFactorialSum()
        {
            long sum = 0;
            for (long i = 1999999; i > 2; i--)
            {
                var digits = DigitArray(i);
                long factorialSum = 0;
                foreach (long digit in digits)
                {
                    factorialSum += Factorial(digit);
                }

                if (factorialSum == i)
                {
                    sum += i;
                }
            }

            return sum;
        }

        public static int[,] ReadInput(string filename)
        {
            string[] linePieces;
            int lineCount = 0;
            List<string> lines;

            lines = ReadLinesFromFile(filename).ToList();
            lineCount = lines.Count;

            int[,] inputTriangle = new int[lineCount, lineCount];

            int j = 0;
            for (int i = 0; i < lines.Count; i++)
            {

                linePieces = lines[i].Split(' ');
                for (int k = 0; k < linePieces.Length; k++)
                {
                    inputTriangle[j, k] = Int32.Parse(linePieces[k]);
                }
                j++;
            }

            return inputTriangle;
        }

        public static bool IsPalindrome(int value)
        {
            int n = 0;
            int m = value;

            while (value > 0)
            {
                n = n * 10 + value % 10;
                value = value / 10 | 0;
            }

            return n == m;
        }

        public static bool IsPalindrome(string value)
        {
            return value == Reverse(value);
        }

        public static bool IsPalindrome(ulong value)
        {
            ulong n = 0;
            ulong m = value;

            while (value > 0)
            {
                n = n * 10 + value % 10;
                value = value / 10 | 0;
            }

            return n == m;
        }

        public static string Reverse(string value)
        {
            var reversed = "";
            var upper = value.Length - 1;

            for (int i = 0; i < value.Length; i++)
            {
                reversed += value[upper - i];
            }

            return reversed;
        }

        public static string IntToBase(int value, int target)
        {
            // Determine # of digits needed
            var digits = (int)Math.Ceiling(Math.Log(value + 1, 2));
            int i = digits;
            char[] buffer = new char[i];
            char[] baseChars = new char[target];


            for (int j = 0; j < target; j++)
            {
                baseChars[j] = j.ToString()[0];
            }

            while (value > 0)
            {
                buffer[--i] = baseChars[value % target];
                value = value / target;
            }

            char[] result = new char[digits];
            for (int j = 0; j <= result.GetUpperBound(0); j++)
            {
                result[j] = '0';
            }
            Array.Copy(buffer, i, result, digits - (digits - i), digits - i);

            return new string(result);
        }

        public static string IntToBase(int value, int target, bool halfByteSegments)
        {
            // Determine # of binary digits needed
            var digits = (int)Math.Ceiling(Math.Log(value + 1, 2));

            if (halfByteSegments)
            {
                digits = digits + (int)(Math.Ceiling((decimal)(digits / 4)) * 4) - (digits - 4);
            }

            int i = digits;
            char[] buffer = new char[i];
            char[] baseChars = new char[target];


            for (int j = 0; j < target; j++)
            {
                baseChars[j] = j.ToString()[0];
            }

            while (value > 0)
            {
                buffer[--i] = baseChars[value % target];
                value = value / target;
            }

            char[] result = new char[digits];
            for (int j = 0; j <= result.GetUpperBound(0); j++)
            {
                result[j] = '0';
            }
            Array.Copy(buffer, i, result, digits - (digits - i), digits - i);

            return new string(result);
        }

        public static int[] Rotations(int number)
        {
            var rotations = new List<int>();
            var digits = number.ToString().Length;

            for (int j = 0; j < digits; j++)
            {
                number = Rotate(number);
                rotations.Add(number);
            }

            rotations.Sort();

            return rotations.ToArray();
        }

        public static int Rotate(int number)
        {
            var digits = number.ToString().Length;
            return (int)((number % 10) * Math.Pow(10, digits - 1) + (number / 10));
        }

        public static bool IsPandigital(long n)
        {
            int digits = 0;
            int count = 0;
            int tmp;

            while (n > 0)
            {
                tmp = digits;
                digits = digits | 1 << (int)((n % 10) - 1);
                if (tmp == digits)
                {
                    return false;
                }

                count++;
                n /= 10;
            }

            return digits == (1 << count) - 1;
        }

        public static int TrianglePerimeter(int max)
        {
            var result = 0;

            int perimeter = 0;
            var perimeters = new Dictionary<int, int>();

            // Initialize dictionary
            for (int i = 0; i < max; i++)
            {
                perimeters.Add(i, 0);
            }

            var checkArray = new int[max, max];
            for (int i = 0; i < checkArray.GetUpperBound(0); i++)
            {
                for (int j = 0; j < checkArray.GetUpperBound(1); j++)
                {
                    checkArray[i, j] = -1;
                }

            }

            for (int a = 1; a < max; a++)
            {
                for (int b = 1; b < max; b++)
                {
                    var c = Math.Sqrt((a * a) + (b * b));

                    if (c % 1 == 0)
                    {
                        if (checkArray[a, b] == -1 && checkArray[b, a] == -1)
                        {
                            perimeter = a + b + (int)c;
                            checkArray[a, b] = perimeter;
                            checkArray[b, a] = perimeter;
                            if (perimeter == 120)
                            {
                                Console.WriteLine("{" + a.ToString() + ", " + b.ToString() + ", " + c.ToString() + "}");
                            }

                            if (perimeter < max)
                            {
                                perimeters[perimeter]++;
                            }
                        }
                    }
                }

            }

            var maxCount = 0;
            foreach (var item in perimeters)
            {
                if (item.Value > maxCount)
                {
                    maxCount = item.Value;
                    result = item.Key;
                }
            }

            return result;
        }

        public static int Concatenate(int front, int back)
        {
            return int.Parse(front.ToString() + back.ToString());
        }

        public static Dictionary<string, int> CodedAlphabet()
        {
            var ay = 'A';
            var zee = 'Z';
            var alphabet = new Dictionary<string, int>();
            for (int i = (int)ay; i <= (int)zee; i++)
            {
                alphabet.Add(((char)i).ToString(), (i + 1) - ay);
            }

            return alphabet;
        }

        public static bool IsTriangleWord(long wordScore)
        {
            var term = 1;

            while (true)
            {
                var value = (int)(term * (term + 1)) / 2;

                if (value > wordScore)
                {
                    return false;
                }

                if (value == wordScore)
                {
                    return true;
                }

                term++;
            }
        }

        public static long WordScore(string word)
        {
            var alphabet = Helpers.CodedAlphabet();
            var score = 0;

            for (int i = 0; i < word.Length; i++)
            {
                char t = word[i];
                score += alphabet[t.ToString()];
            }

            return score;
        }

        public static IEnumerable<ulong> TriangleSeries(ulong numTerms)
        {
            var series = new List<ulong>();

            for (ulong i = 1; i <= numTerms; i++)
            {
                series.Add((i * (i + 1)) / 2);
            }

            return series;
        }

        public static IEnumerable<ulong> PentagonSeries(ulong numTerms)
        {
            var series = new List<ulong>();

            for (ulong i = 1; i <= numTerms; i++)
            {
                series.Add((i * ((3 * i) - 1)) / 2);
            }

            return series;
        }

        public static IEnumerable<ulong> HexagonSeries(ulong numTerms)
        {
            var series = new List<ulong>();

            for (ulong i = 1; i <= numTerms; i++)
            {
                series.Add(i * ((2 * i) - 1));
            }

            return series;
        }

        public static BigInteger SelfPower(int num)
        {
            BigInteger result = num;
            for (int i = 2; i <= num; i++)
            {
                result *= num;
            }

            return result;
        }

        public static bool IsPermutation(long m, long n)
        {
            long[] arr = new long[10];

            long temp = n;
            while (temp > 0)
            {
                arr[temp % 10]++;
                temp /= 10;
            }

            temp = m;
            while (temp > 0)
            {
                arr[temp % 10]--;
                temp /= 10;
            }

            for (int i = 0; i < 10; i++)
            {
                if (arr[i] != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
