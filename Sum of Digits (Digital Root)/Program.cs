// https://www.codewars.com/kata/541c8630095125aba6000c00/train/csharp

namespace Sum_of_Digits__Digital_Root_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DigitalRoot(16));
            Console.WriteLine(DigitalRoot(942));
            Console.WriteLine(DigitalRoot(132189));
            Console.WriteLine(DigitalRoot(493193));
            Console.WriteLine(DigitalRoot(3209485432908523905));
            Console.WriteLine(DigitalRoot(5));
        }

        public static int DigitalRoot(long n)
        {
            long number = n;

            int result = -1;

            for (; ; )
            {
                // separate the digits into array
                string numberString = number.ToString();


                // sum the array
                int sum = numberString
                    .ToCharArray()
                    .Select(c => int.Parse(c.ToString()))
                    .Sum();

                

                // if the sum is larger than 9 repeat / if smaller than 10 finish?
                /*
                 * if the sum is <= 9
                 * break the loop
                 * else
                 * assign the sum to be the new number
                 * continue the loop
                 */

                if (sum <= 9)
                {
                    result = sum;
                    break;
                }
                else
                {
                    number = sum;
                }

                // try without recursion?
            }

            // return the last sum

            return result;
        }
    }
}
