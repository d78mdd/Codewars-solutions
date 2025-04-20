// https://www.codewars.com/kata/52b7ed099cdc285c300001cd/train/csharp

namespace Sum_of_Intervals
{
    public class Intervals
    {

        static void Main(string[] args)
        {
            //Console.WriteLine(SumIntervals(new (int, int)[] { (4, 4), (6, 6), (8, 8) }));
            //Console.WriteLine(SumIntervals(new (int, int)[] { (-1, 4), (-5, -3) }));
            //Console.WriteLine(SumIntervals(new (int, int)[] { (1, 4), (7, 10), (3, 5) }));
            Console.WriteLine(SumIntervals(new (int, int)[] { (1, 5), (10, 20), (1, 6), (16, 19), (5, 11) }));
        }

        // implement overlapping  
        // (should work also for containing intervals?)
        // (are they sorted?)
        /*
         * add all intervals to a list
         * get 1by1
         *  compare with all others - by left's end and right's start
         *  if >
         *  then remove both and add new with left's start and right's end
         */

        public static int SumIntervals((int, int)[] intervals)
        {
            List<(int, int)> asOrderedList = intervals
                .OrderBy(interval => interval.Item1) // order by the left number (the interval start)
                .ToList();

            List<(int, int)> combined = new List<(int, int)>();

            for (int i = 0; i < asOrderedList.Count; i++)
            {
                (int, int) intervalCurrent = asOrderedList[i];

                int begC = intervalCurrent.Item1;
                int endC = intervalCurrent.Item2;

                for (int j = i + 1; j < asOrderedList.Count; j++)
                {
                    (int, int) intervalOther = asOrderedList[j];

                    int begO = intervalOther.Item1;
                    int endO = intervalOther.Item2;

                    bool overlap = endC > begO;

                    if (overlap)
                    {
                        i++; // skip an index (the other interval) in the large loop
                        // overlapping intervals will always be consecutive when sorted by left number

                        endC = Math.Max(endC, endO);
                        // update the end of the currently processed interval
                        // endC larger : current contains the entire other
                        // endO larger : the other ends after the current
                    }
                }

                combined.Add((begC, endC)); // add the current interval be it a regular one or a combined one
            }

            return Sum(combined);
        }

        public static int Sum(List<(int, int)> intervals)
        {
            int result = -1;

            int[] lengths = new int[intervals.Count];

            for (int i = 0; i < intervals.Count; i++)
            {
                (int, int) interval = intervals[i];

                lengths[i] = interval.Item2 - interval.Item1;  // The first value of the interval will always be less than the second value
            }

            result = lengths.Sum();

            return result;
        }

    }
}
