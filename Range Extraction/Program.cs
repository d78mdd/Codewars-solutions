using System.Collections.Generic;
using System.Text;
using System.Linq;
using System;
using static System.Linq.Enumerable;

namespace Range_Extraction
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Extract(new[] { 1, 2 }));
        }

        public static string Extract(int[] args)
        {
            List<string> list = new List<string>();

            if (args.Length == 2)
            {
                list.Add($"{args[0]}");
                list.Add($"{args[1]}");

                return string.Join(',', list);
            }
            if (args.Length == 1)
            {
                return $"{args[0]}";
            }
            if (args.Length == 0)
            {
                return "";
            }

            // track whether current item is being included in a sequence
            bool inSequence;
            int sequenceLength;

            int start = args[0];
            int end = start;

            sequenceLength = 1;
            for (int i = 1; i < args.Length; i++)
            {
                if (args[i] - args[i - 1] == 1) // in sequence
                {
                    inSequence = true;
                }
                else // end of sequence
                {
                    inSequence = false;

                    end = args[i - 1]; // if a single number with no sequence then start would == end, and no inSequence needed?
                                       // also sequenceLength is end-start
                }


                if (!inSequence)
                {
                    if (sequenceLength == 1) // if a single number
                    {
                        list.Add($"{start}");
                    }
                    else if (sequenceLength >= 3) // if a sequence ended
                    {
                        list.Add($"{start}-{end}");
                    }
                    else if (sequenceLength == 2) // sequence of 2 does not qualify
                    {
                        list.Add($"{start}");
                        list.Add($"{end}");
                    }

                    start = args[i];
                    end = start;

                    sequenceLength = 0;
                }


                sequenceLength++;


                if (i == args.Length - 1)
                {
                    end = args[i];

                    if (sequenceLength >= 3)  // if it's the last index, and we're in a sequence
                    {
                        list.Add($"{start}-{end}");
                    }
                    else if (sequenceLength == 1)  // if last 1 number out of sequence
                    {
                        list.Add($"{start}");
                    }
                    else if (sequenceLength == 2)  // if last 2 numbers - consecutive
                    {
                        list.Add($"{start}");
                        list.Add($"{end}");
                    }
                }

            }

            return string.Join(',', list);
        }

    }
}
