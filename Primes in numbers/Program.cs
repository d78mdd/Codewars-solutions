using System.Collections.Generic;
using System.Text;
using System.Linq;
using System;
using static System.Linq.Enumerable;

namespace Primes_in_numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(factors(7775460));
            Console.WriteLine(factors(77754600));
            Console.WriteLine(factors(777546000));
        }

        public static String factors(int lst)
        {
            int[] primeFactors = GetPrimeFactors(lst).ToArray();

            Dictionary<int, int> uniquePrimeFactors = new Dictionary<int, int>();

            // collect primes' counts
            foreach (int primeFactor in primeFactors)
            {
                // add or increment factor count
                if (!uniquePrimeFactors.ContainsKey(primeFactor))
                {
                    uniquePrimeFactors.Add(primeFactor, 1);
                }
                else
                {
                    uniquePrimeFactors[primeFactor]++;
                }
            }

            // format output
            StringBuilder sb = new StringBuilder();

            foreach (var factor in uniquePrimeFactors)
            {
                if (factor.Value > 1)
                {
                    sb.Append($"({factor.Key}**{factor.Value})");
                }
                else
                {
                    sb.Append($"({factor.Key})");
                }
            }

            return sb.ToString();
        }


        // get factors of num - any positive or negative number
        public static List<int> GetPrimeFactors(int num)
        {
            num = Math.Abs(num);

            List<int> result = new List<int>();

            for (int i = 2; i < 400000;)
            {
                if (num % i == 0)
                {
                    num /= i;
                    result.Add(i);
                }
                else
                {
                    i++;
                }
            }

            return result;
        }

    }
}
