// https://www.codewars.com/kata/52b7ed099cdc285c300001cd/train/csharp

namespace Sum_of_Intervals
{
    public class Intervals
    {

        static void Main(string[] args)
        {
            Console.WriteLine(SumIntervals(new (int, int)[] { (4, 4), (6, 6), (8, 8) }));
        }

        public static int SumIntervals((int, int)[] intervals)
        {
            int result = -1;

            int[] lengths = new int[intervals.Length];

            for (int i = 0; i < intervals.Length; i++)
            {
                (int, int) interval = intervals[i];
                
                lengths[i] = interval.Item2 - interval.Item1;
            }

            result = lengths.Sum();

            return result;
        }

    }
}
