// https://www.codewars.com/kata/5264d2b162488dc400000001/train/csharp

using System.Collections.Generic;
using System.Linq;
using System;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SpinWords("Hey fellow warriors"));
        }


        public static string SpinWords(string sentence)
        {
            string[] words = sentence.Split(' ');

            string[] result = new string[words.Length];

            for (var i = 0; i < words.Length; i++)
            {
                var word = words[i];

                if (word.Length >= 5)
                {
                    var reversed = word.ToCharArray().Reverse();
                    result[i] = string.Join("", reversed);
                }
                else
                {
                    result[i] = word;
                }
            }

            return string.Join(' ', result);
        }


    }
}

 
