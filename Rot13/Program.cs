// https://www.codewars.com/kata/530e15517bc88ac656000716/train/csharp

using System.Text;

namespace Rot13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Rot13("Hello, World!"));
            Console.WriteLine(Rot13("test")); // "grfg"
            Console.WriteLine(Rot13("Test")); // "Grfg"
        }

        public static string Rot13(string message)
        {
            StringBuilder result = new StringBuilder();

            // abcdefghijklmnopqrstuvwxyz
            // 97 - 122

            // ABCDEFGHIJKLMNOPQRSTUVWXYZ
            // 65 - 90

            // 01234567890
            // .,;

            for (int i = 0; i < message.Length; i++)
            {
                char c = message[i];

                if (c >= 97 && c <= 122)
                {
                    c = (char)(c + 13);
                    if (c > 122)
                    {
                        c = (char)(c - 26);
                    }
                }
                else if (c >= 65 && c <= 90)
                {
                    c = (char)(c + 13);
                    if (c > 90)
                    {
                        c = (char)(c - 26);
                    }
                }
                else
                {
                    c = message[i];
                }

                result.Append(c);
            }

            return result.ToString();
        }

    }
}
