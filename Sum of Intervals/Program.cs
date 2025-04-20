// https://www.codewars.com/kata/52b7ed099cdc285c300001cd/train/csharp

namespace Sum_of_Intervals
{
    public class Intervals
    {

        static void Main(string[] args)
        {
            //Console.WriteLine(SumIntervals(new (int, int)[] { (4, 4), (6, 6), (8, 8) }));
            //Console.WriteLine(SumIntervals(new (int, int)[] { (-1, 4), (-5, -3) }));
            Console.WriteLine(SumIntervals(new (int, int)[] { (1, 4), (7, 10), (3, 5) }));
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
            List<(int, int)> asList = intervals
                .OrderBy(tuple => tuple.Item1)
                .ToList();

            List<(int, int)> combined = new List<(int, int)>();

            for (int i = 0; i < asList.Count; i++)
            {
                (int, int) intervalCurrent = asList[i];
                bool overlap = false;
                int begC = -1;
                int endC = -1;
                int begO = -1;
                int endO = -1;
                (int, int) intervalOther = new ValueTuple<int, int>(-1, -1);

                begC = intervalCurrent.Item1;
                endC = intervalCurrent.Item2;


                for (int j = i + 1; j < asList.Count; j++)
                {
                    intervalOther = asList[j];

                    begO = intervalOther.Item1;
                    endO = intervalOther.Item2;

                    overlap = endC > begO;

                    if (overlap)
                    {
                        i++;
                        break;
                    }
                }


                if (overlap)
                {
                    combined.Add((begC, endO)); // add a combined interval
                }
                else // no overlapping
                {
                    combined.Add((begC, endC)); // just add the current interval
                }
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

                lengths[i] = interval.Item2 - interval.Item1;
            }

            result = lengths.Sum();

            return result;
        }


    }
}
