using System;
using System.ComponentModel;

namespace Catching_Car_Mileage_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(IsInteresting(3, new List<int>() { 1337, 256 }));
            //Console.WriteLine(IsInteresting(1336, new List<int>() { 1337, 256 }));
            //Console.WriteLine(IsInteresting(1337, new List<int>() { 1337, 256 }));
            //Console.WriteLine(IsInteresting(11208, new List<int>() { 1337, 256 }));
            //Console.WriteLine(IsInteresting(11209, new List<int>() { 1337, 256 }));
            //Console.WriteLine(IsInteresting(11211, new List<int>() { 1337, 256 }));

            Console.WriteLine(IsInteresting(1590, new List<int>() { }));
        }


        private static List<int> _awesomePhrases = new List<int>();

        public static int IsInteresting(int number, List<int> awesomePhrases)
        {
            _awesomePhrases = new List<int>(awesomePhrases);

            if (InterestingChecks(number))
            {
                return 2;
            }
            else if (InterestingChecks(number + 1) ||
                     InterestingChecks(number + 2))
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        private static bool InterestingChecks(int number)
        {
            return
            (
                Greater(number)
                &&
                (
                    //any of these
                    Followed(number) ||
                    SameDigits(number) ||
                    SequentialInc(number) ||
                    SequentialDecr(number) ||
                    Palindrome(number) ||
                    Phrases(number)
                )
            );
        }

        //> -A number is only interesting if it is greater than `99`!
        private static bool Greater(int number)
        {
            return number > 99;
        }

        //  > -The digits match one of the values in the `awesomePhrases` array
        private static bool Phrases(int number)
        {
            return _awesomePhrases.Contains(number);
        }

        //   > -The digits are a palindrome: `1221` or `73837`
        private static bool Palindrome(int number)
        {
            string asStr = number.ToString();

            // 10
            // 12312 31231
            // 01234 56789
            // 9
            // 1231 2 3123
            // 0123 4 5678
            //for (int beg = 0, end = asStr.Length - 1; beg < asStr.Length / 2, end > asStr.Length / 2; beg++ end--)
            int left = 0;
            int right = asStr.Length - 1;
            for (; ; )
            {
                if (left > asStr.Length / 2 - 1 ||
                    right < asStr.Length / 2)
                {
                    break;
                }

                if (asStr[left] != asStr[right])
                {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }

        //   > -The digits are sequential, decrementing‡: `4321`
        private static bool SequentialDecr(int number)
        {
            string baseStr = "9876543210";

            return baseStr.Contains(number.ToString());
        }

        //   > -The digits are sequential, incrementing: `1234`
        private static bool SequentialInc(int number)
        {
            string baseStr = "1234567890";

            return baseStr.Contains(number.ToString());
        }

        //   > -Every digit is the same number: `1111`
        private static bool SameDigits(int number)
        {
            string asStr = number.ToString();

            foreach (char digit in asStr)
            {
                if (digit != asStr[0])
                {
                    return false;
                }
            }

            return true;
        }

        // 3-or-more digit numbers
        //   > -Any digit followed by all zeros: `100`, `90000`
        private static bool Followed(int num)
        {
            return num % 100 == 0;
        }
    }
}
