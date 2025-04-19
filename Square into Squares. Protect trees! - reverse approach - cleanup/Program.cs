namespace Square_into_Squares._Protect_trees____reverse_approach___cleanup
{
    public class Decompose
    {
        static void Main(string[] args)
        {
            int n = 20000000;

            Console.WriteLine(n);

            string bestList = new Decompose().decompose(n);

            //PrintAllResults();

            Console.WriteLine(bestList);

            /* gets the sequence of largest consecutive numbers whose squares' sum is equal to a number's square
             * 20000000
               2 3 11 83 6324 19999999
             */
        }



        // number to decompose
        private static long n;

        // n squared
        private static long ns;

        private static List<List<long>> results = new List<List<long>>();

        private static bool foundBestResult;


        public string? decompose(long n)
        {
            Decompose.n = n;
            Decompose.ns = n * n;

            AddToSum(new List<long>());

            string? result = GetAsStringOrNull(GetBestResult());

            // cleanup
            Decompose.n = 0;
            Decompose.ns = 0;
            results = new List<List<long>>();
            foundBestResult = false;

            return result;
        }

        private string? GetAsStringOrNull(List<long> intsList)
        {
            if (intsList.Count == 0)
            {
                return null;
            }
            else
            {
                return string.Join(' ', intsList);
            }
        }

        private List<long> GetBestResult()
        {
            // take the list with largest last number

            var result = results
                .OrderBy(ints => ints.Last())
                .LastOrDefault();

            if (result != null)
            {
                return result
                    .OrderBy(longs => longs)
                    .ToList();
            }
            else
            {
                return new List<long>();
            }
        }

        public static void AddToSum(List<long> numbers)
        {
            if (foundBestResult)
            {
                return;
            }

            List<long> nums = new List<long>(numbers);

            long sum = Sum(nums);
            if (sum == ns)
            {
                if (nums.Count >= 2)
                {
                    results.Add(nums);
                    // it's automatically the best result
                    foundBestResult = true;
                }
            }
            else if (sum < ns)
            {
                long nextNum = GetNextNum(nums);

                for (long i = nextNum; i >= 1; i--)
                {
                    nums.Add(i);
                    AddToSum(nums);
                    nums.Remove(i);
                }
            }
        }

        private static long GetNextNum(List<long> nums)
        {
            int lastIndex = nums.Count - 1;

            if (lastIndex >= 0)
            {
                return nums[lastIndex] - 1;
            }
            else
            {
                return n - 1;
            }
        }


        // return the sum of the squares of the numbers in the list
        public static long Sum(List<long> nums)
        {
            long sum = 0;

            foreach (long num in nums)
            {
                sum += num * num;
            }

            return sum;
        }

        private static void PrintAllResults()
        {
            foreach (List<long> result in results)
            {
                foreach (long num in result)
                {
                    Console.Write(num);
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }

    }
}
