// strictly increasing sequence

// so that the sum of the numbers is equal to n

////////////////////////////////////////////////////////////

// 1 + 2 + 3 + 4 + 5 +.....

// would compare all these with n
// 1 + 2 
// 1 + 2 + 3
// 1 + 2 + 3 + 4
// 1 + 2 + 3 + 4 + 5
// 1 + 2 + 3 + 5
// 1 + 2 + 4 
// 1 + 2 + 5
// 1 + 3
// 1 + 3 + 4
// 1 + 3 + 4 + 5
// 1 + 3 + 5
// 1 + 4
// 1 + 4 + 5
// 1 + 5

// at least 2 numbers

namespace Square_into_Squares._Protect_trees____base_logic2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 11;

            Console.WriteLine(n);

            decompose(n);

            foreach (List<int> result in results)
            {
                foreach (int num in result)
                {
                    Console.Write(num);
                    Console.Write(" ");
                }

                Console.WriteLine();
            }

            /* gets lists of consecutive numbers whose squares' sum is equal to a number's square
             * 11
               1 2 4 6 8
               1 2 4 10
             */
        }

        // number to decompose
        private static int n;

        // n squared
        private static int ns;

        private static List<List<int>> results = new List<List<int>>();


        public static List<int> decompose(int n)
        {
            Program.n = n;
            Program.ns = n * n;

            AddToSum(new List<int>() { 1 });

            return null;
        }

        public static void AddToSum(List<int> numbers)
        {
            List<int> nums = new List<int>(numbers);

            //var sum = nums.Sum();
            var sum = Sum(nums);
            if (sum == ns)
            {
                results.Add(nums);
            }
            else if (sum < ns)
            {
                int nextNum = nums[nums.Count - 1] + 1;

                for (int i = nextNum; i + sum <= ns; i++)
                {
                    nums.Add(i);
                    AddToSum(nums);
                    nums.Remove(i);
                }
            }
        }


        // return the sum of the squares of the numbers in the list
        public static int Sum(List<int> nums)
        {
            int sum = 0;

            foreach (int num in nums)
            {
                sum += num * num;
            }

            return sum;
        }

    }
}
