namespace What_s_a_Perfect_Power_anyway
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsPerfectPower(4));
        }

        public static (int, int)? IsPerfectPower(int n)
        {
            int maxAllowed = 1000;

            for (int m = 2; m < maxAllowed; m++)
            {
                for (int k = 2; k < maxAllowed; k++)
                {
                    if (Math.Pow(m, k) == n)
                    {
                        return (m, k);
                    }
                }
            }

            return null;
        }

    }
}
