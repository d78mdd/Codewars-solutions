// https://www.codewars.com/kata/51b66044bce5799a7f000003/train/csharp

using System.Text;

namespace Roman_Numerals_Helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ToRoman(1666));
            Console.WriteLine(ToRoman(2000));
            Console.WriteLine(ToRoman(86));
            Console.WriteLine(ToRoman(1));

            Console.WriteLine(FromRoman("IV"));
        }

        public static string ToRoman(int n)
        {
            StringBuilder result = new StringBuilder();

            int num = n;

            for (; ; )
            {
                if (num == 0)
                {
                    break;
                }

                if (num >= 1000)
                {
                    num -= 1000;
                    result.Append("M");
                }
                else if (num >= 900)
                {
                    num -= 900;
                    result.Append("CM");
                }
                else if (num >= 500)
                {
                    num -= 500;
                    result.Append("D");
                }
                else if (num >= 400)
                {
                    num -= 400;
                    result.Append("CD");
                }
                else if (num >= 100)
                {
                    num -= 100;
                    result.Append("C");
                }
                else if (num >= 90)
                {
                    num -= 90;
                    result.Append("XC");
                }
                else if (num >= 50)
                {
                    num -= 50;
                    result.Append("L");
                }
                else if (num >= 40)
                {
                    num -= 40;
                    result.Append("XL");
                }
                else if (num >= 10)
                {
                    num -= 10;
                    result.Append("X");
                }
                else if (num >= 9)
                {
                    num -= 9;
                    result.Append("IX");
                }
                else if (num >= 5)
                {
                    num -= 5;
                    result.Append("V");
                }
                else if (num >= 4)
                {
                    num -= 4;
                    result.Append("IV");
                }
                else if (num >= 1)
                {
                    num -= 1;
                    result.Append("I");
                }
            }

            return result.ToString();
        }

        public static int FromRoman(string romanNumeral)
        {
            int result = 0;

            string r = romanNumeral;

            for (int i = 0; i < r.Length; i++)
            {
                if (r[i] == 'I')
                {
                    if (i < r.Length - 1 && r[i + 1] == 'X')
                    {
                        result += 9;
                        i++;
                    }
                    else if (i < r.Length - 1 && r[i + 1] == 'V')
                    {
                        result += 4;
                        i++;
                    }
                    else
                    {
                        result += 1;
                    }
                }
                else if (r[i] == 'X')
                {
                    if (i < r.Length - 1 && r[i + 1] == 'C')
                    {
                        result += 90;
                        i++;
                    }
                    else if (i < r.Length - 1 && r[i + 1] == 'L')
                    {
                        result += 40;
                        i++;
                    }
                    else
                    {
                        result += 10;
                    }
                }
                else if (r[i] == 'C')
                {
                    if (i < r.Length - 1 && r[i + 1] == 'M')
                    {
                        result += 900;
                        i++;
                    }
                    else if (i < r.Length - 1 && r[i + 1] == 'D')
                    {
                        result += 400;
                        i++;
                    }
                    else
                    {
                        result += 100;
                    }
                }
                else if (r[i] == 'M')
                {
                    result += 1000;
                }
                else if (r[i] == 'D')
                {
                    result += 500;
                }
                else if (r[i] == 'L')
                {
                    result += 50;
                }
                else if (r[i] == 'V')
                {
                    result += 5;
                }

            }

            return result;
        }
    }
}
