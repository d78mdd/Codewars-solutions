using System.Text;

namespace Sum_by_Factors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            sumOfDivided(new[] { -21, -15 });
        }

        public static string sumOfDivided(int[] lst)
        {
            //// collect all unique prime numbers
            List<int> primeFactors = new List<int>();
            // iterate over I's elements
            foreach (int elem in lst)
            {
                primeFactors.AddRange(GetPrimeFactors(elem));
            }
            // get all unique prime numbers
            HashSet<int> uniquePrimeFactors = new HashSet<int>(primeFactors);


            //// collect all dividees for each prime number
            Dictionary<int, List<int>> dividees = new Dictionary<int, List<int>>();
            // key - prime number
            // value - list of dividees - numbers from I(lst) this prime number divides

            foreach (int prime in uniquePrimeFactors)
            {
                dividees.Add(prime, new List<int>());

                foreach (int number in lst)
                {
                    if (number % prime == 0)
                    {
                        dividees[prime].Add(number);
                    }
                }
            }


            //// sum dividees
            Dictionary<int, int> divideesSummed = new Dictionary<int, int>();
            foreach (KeyValuePair<int, List<int>> dividee in dividees)
            {
                divideesSummed.Add(dividee.Key, dividee.Value.Sum());
            }


            //// format/collect output
            StringBuilder sb = new StringBuilder();
            foreach (var d in divideesSummed.OrderBy(pair => pair.Key))
            {
                sb.Append($"({d.Key} {d.Value})");
            }

            return sb.ToString();
        }

        public static List<int> GetPrimeFactors(int elem)
        {
            return GetFactors(elem)
                .Where(IsPrime)
                .ToList();

        }

        // get factors of elem = any positive or negative number
        public static List<int> GetFactors(int elem)
        {
            List<int> result = new List<int>();

            for (int i = 2; i <= Math.Abs(elem); i++)
            {
                if (elem % i == 0)
                {
                    result.Add(i);
                }
            }

            return result;
        }

        // return true if num is prime (assumed positive)
        public static bool IsPrime(int num)
        {
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
