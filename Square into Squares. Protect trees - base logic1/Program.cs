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


///////////////////////////////////////////////////////////

// strictly increasing sequence

// so that the sum of the numbers is equal to n-1

// 2 + 3 + 4 + 5 +.....

// would compare all these with n-1
// 2 
// 2 + 3
// 2 + 3 + 4
// 2 + 3 + 4 + 5
// 2 + 3 + 5
// 2 + 4 
// 2 + 4 + 5 !
// 2 + 5
// 3
// 3 + 4
// 3 + 4 + 5
// 3 + 5
// 4
// 4 + 5
// 5

// at least 1 number

namespace Square_into_Squares._Protect_trees___base_logic1
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

            /* gets lists of consecutive numbers equal to a number
             there's a 1 off error from the actual number
             *11
               1 2 3 4
               1 2 7
               1 3 6
               1 4 5
               1 9
             */
        }

        private static int n;

        private static List<List<int>> results = new List<List<int>>();


        public static List<int> decompose(int n)
        {
            int sum = 0;

            Program.n = n;

            List<int> result = AddToSum(new List<int>() { 1 });

            return result;
        }

        public static List<int> AddToSum(List<int> numbers)
        {
            List<int> nums = new List<int>(numbers);

            int nextNum = nums[nums.Count - 1] + 1;

            if (nums.Sum() == n - 1)
            {
                results.Add(nums);
                return nums;
            }
            else if (nums.Sum() > n - 1)
            {
                return nums;
            }
            else
            {
                for (int i = nextNum; i + nums.Sum() <= n - 1; i++)
                {

                    nums.Add(i);
                    AddToSum(nums);
                    nums.Remove(i);
                }

                return nums;

            }
        }

    }
}
