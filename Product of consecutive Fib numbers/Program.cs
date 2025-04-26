// https://www.codewars.com/kata/5541f58a944b85ce6d00006a/train/csharp

namespace Product_of_consecutive_Fib_numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Fib(0));
            //Console.WriteLine(Fib(1));
            //Console.WriteLine(Fib(2));
            //Console.WriteLine(Fib(3));
            //Console.WriteLine(Fib(4));
            //Console.WriteLine(Fib(5));
            //Console.WriteLine(Fib(6));
            //Console.WriteLine(Fib(7));
            //Console.WriteLine(Fib(8));
            //Console.WriteLine(Fib(9));
            //Console.WriteLine(Fib(10));
            //Console.WriteLine(Fib(11));
            //Console.WriteLine(Fib(12));
            //Console.WriteLine(Fib(13));
            //Console.WriteLine(Fib(14));
            //Console.WriteLine(Fib(15));

            foreach (ulong elem in productFib(5523523523323452345UL))
            {
                Console.WriteLine(elem);
            }
            foreach (ulong elem in productFib(714UL))
            {
                Console.WriteLine(elem);
            }
            foreach (ulong elem in productFib(800UL))
            {
                Console.WriteLine(elem);
            }
        }


        // init 10000 element array with [4] - not a Fibonacci number
        private static ulong initValue = 4UL;
        private static int capacity = 10000;
        private static ulong[] memo = new ulong[capacity];


        public static ulong[] productFib(ulong prod)
        {
            for (int i = 0; i < capacity; i++)
            {
                memo[i] = initValue;
            }


            ulong prevFib = 0;

            for (int i = 0; i < capacity; i++)
            {
                ulong fib1 = prevFib;
                ulong fib2 = Fib(i + 1);

                ulong productOf2FibNumbers = fib1 * fib2;


                if (productOf2FibNumbers == prod)
                {
                    return new ulong[] { fib1, fib2, 1 };
                }

                if (productOf2FibNumbers > prod)
                {
                    return new ulong[] { fib1, fib2, 0 };
                }

                prevFib = fib2;
            }

            return null;
        }


        public static ulong Fib(int n)
        {
            ulong fib;


            if (memo[n] != initValue)
            {
                return memo[n];
            }


            if (n == 0)
            {
                fib = 0;
            }
            else if (n == 1)
            {
                fib = 1;
            }
            else
            {
                fib = Fib(n - 1) + Fib(n - 2);
            }


            memo[n] = fib;


            return fib;
        }
    }
}
