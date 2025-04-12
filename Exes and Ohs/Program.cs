namespace Exes_and_Ohs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public static bool XO(string input)
        {
            bool result = false;

            int countX;
            int countO;

            countX = input.Count(c => c == 'x' || c == 'X');
            countO = input.Count(c => c == 'o' || c == 'O');

            return countO == countX;
        }
    }
}
