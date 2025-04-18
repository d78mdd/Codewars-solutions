﻿// https://www.codewars.com/kata/54eb33e5bc1a25440d000891/train/csharp

using System.Text;

// strictly increasing sequence

// so that the sum of the squares is equal to n^2

// return as far as possible the result with the largest possible values (of the last number)

////////////////////////////////////////////////////////////

// 1^2 + 2^2 + 3^2 + 4^4 + 5^2 +.....

// would compare all these with n^2
// 1^2 + 2^2 
// 1^2 + 2^2 + 3^2
// 1^2 + 2^2 + 3^2 + 4^2
// 1^2 + 2^2 + 3^2 + 4^2 + 5^2
// 1^2 + 2^2 + 3^2 + 5^2
// 1^2 + 2^2 + 4^2 
// 1^2 + 2^2 + 5^2
// 1^2 + 3^2
// 1^2 + 3^2 + 4^2
// 1^2 + 3^2 + 4^2 + 5^2
// 1^2 + 3^2 + 5^2
// 1^2 + 4^2
// 1^2 + 4^2 + 5^2
// 1^2 + 5^2

// at least 2 numbers



namespace Square_into_Squares._Protect_trees
{
    public class Decompose
    {
        static void Main(string[] args)
        {
            int n = 60;

            Console.WriteLine(n);

            string bestList = new Decompose().decompose(n);

            //PrintAllResults();

            Console.WriteLine(bestList);

            /* gets the list of largest consecutive numbers whose squares' sum is equal to a number's square
             * 60
               1 2 3 4 5 8 59
             */
        }



        // number to decompose
        private static long n;

        // n squared
        private static long ns;

        private static List<List<int>> results = new List<List<int>>();
        
        // found a result with last number == n-1 - can't have a sequence with larger last number
        private static bool foundBestResult;


        public string decompose(long n)
        {
            Decompose.n = n;
            Decompose.ns = n * n;

            AddToSum(new List<int>());

            string result = GetAsString(GetBestResult());

            // cleanup
            Decompose.n = 0;
            Decompose.ns = 0;
            results = new List<List<int>>();
            foundBestResult = false;

            return result;
        }

        private string GetAsString(List<int> intsList)
        {
            return string.Join(' ', intsList);
        }

        private List<int> GetBestResult()
        {
            // take the list with largest last number
            return results
                .OrderBy(ints => ints.Last())
                .Last();
        }

        public static void AddToSum(List<int> numbers)
        {
            if (foundBestResult)
            {
                return;
            }

            List<int> nums = new List<int>(numbers);

            int sum = Sum(nums);
            if (sum == ns)
            {
                if (nums.Count >= 2)
                {
                    results.Add(nums);

                    if (nums.Last() == n - 1)
                    {
                        foundBestResult = true;
                    }
                }
            }
            else if (sum < ns)
            {
                int nextNum = GetNextNum(nums);

                for (int i = nextNum; i * i + sum <= ns; i++)
                {
                    nums.Add(i);
                    AddToSum(nums);
                    nums.Remove(i);
                }
            }
        }

        private static int GetNextNum(List<int> nums)
        {
            int lastIndex = nums.Count - 1;

            if (lastIndex >= 0)
            {
                return nums[lastIndex] + 1;
            }
            else
            {
                return 1;
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

        private static void PrintAllResults()
        {
            foreach (List<int> result in results)
            {
                foreach (int num in result)
                {
                    Console.Write(num);
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }

    }
}
