// https://www.codewars.com/kata/5263c6999e0f40dee200059d/train/csharp

namespace The_observed_PIN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Kata
    {
        public static List<string> GetPINs(string observed)
        {
            int observedInt = int.Parse(observed);

            List<int> result = new List<int>();

            /* 
             * if 1 then 2 and 4
             * if 2 then 1,3,5
             * if 3 then 2,6
             * if 4 then 1,5,7
             * if 5 then 2,4,6,8
             * if 6 then 3,5,9
             * if 7 then 4,8
             * if 8 then 5,7,9,0
             * if 9 then 6,8
             * if 0 then 8
             */

            for (int i = 0; i < UPPER; i++)
            {
                
            }



            return result
                .Select(i => i.ToString())
                .ToList();
        }
    }

}
