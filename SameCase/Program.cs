// https://www.codewars.com/kata/5dd462a573ee6d0014ce715b

namespace SameCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SameCase('a', 'U'));
        }


        public static int SameCase(char a, char b)
        {

            bool isCharAUpperCase = a >= 65 && a <= 90;
            bool isCharBUpperCase = b >= 65 && b <= 90;

            bool isCharALowerCase = a >= 97 && a <= 122;
            bool isCharBLowerCase = b >= 97 && b <= 122;

            bool areBothLowerCase = isCharALowerCase && isCharBLowerCase;
            bool areBothUpperCase = isCharAUpperCase && isCharBUpperCase;

            bool isNotCharALetter = !isCharAUpperCase && !isCharALowerCase;
            bool isNotCharBLetter = !isCharBUpperCase && !isCharBLowerCase;

            if (areBothLowerCase || areBothUpperCase)
            {
                return 1;
            }

            if (isNotCharALetter || isNotCharBLetter)
            {
                return -1;
            }

            return 0;
        }
    }
}
