// https://www.codewars.com/kata/56541980fa08ab47a0000040/train/csharp

namespace Printer_Errors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PrinterError("aaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbmmmmmmmmmmmmmmmmmmmxyz"));
        }

        public static string PrinterError(String s)
        {
            string validColors = "abcdefghijklm";

            int errors = s.Count(c => !validColors.Contains(c));
            int length = s.Length;

            return $"{errors}/{length}";
        }


    }
}
