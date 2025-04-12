namespace Persistent_Bugger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Persistence(39));
            Console.WriteLine(Persistence(999));
            Console.WriteLine(Persistence(4));
            Console.WriteLine(Persistence(1231231231232));
            Console.WriteLine(Persistence(1));
            Console.WriteLine(Persistence(0));
        }

        public static int Persistence(long n)
        {
            int result = 0;

            long number = n;

            for (; ; )
            {
                string digits = number.ToString();

                if (digits.Length == 1)
                {
                    break;
                }

                int mult = 1;

                foreach (char c in digits)
                {
                    int digit = int.Parse(c.ToString());

                    mult *= digit;

                    
                }

                number = mult;

                result++;
            }

            return result;
        }
    }
}
