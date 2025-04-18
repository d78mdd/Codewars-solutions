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
            else if (args.Length == 1)
            {
                list.Add($"{args[0]}");

                return string.Join(',', list);
            }
            else if (args.Length == 0)
            {
                list.Add("");

                return string.Join(',', list);
            }


            // track whether current item is being included in a sequence
            bool inSequence = true;
            int sequenceLength = 0;

            int start = args[0];
            int end = args[0];

            sequenceLength = 1;
            for (int i = 1; i < args.Length; i++)
            {
        

                if (args[i] - args[i-1] == 1) // in sequence
                {

                    inSequence = true;

                    
                }
                else // end of sequence
                {
                    inSequence = false;

                    end = args[i - 1]; // if a single number with no sequence then start would == end, and no inSequence needed?
                    // also sequenceLength is end-start

                    
                }

                


                if (!inSequence && sequenceLength == 1)  // if a single number
                {
                    list.Add($"{start}");

                    sequenceLength = 0;

                    start = args[i];
                    //end = args[i]?;
                }
                else if (!inSequence && sequenceLength >= 3) // if a sequence ended
                {
                    list.Add($"{start}-{end}");

                    sequenceLength = 0;

                    start = args[i];
                    //end = args[i]?;
                }
                else if (!inSequence && sequenceLength == 2) // sequence of 2 does not qualify
                {
                    list.Add($"{start}");
                    list.Add($"{end}");

                    start = args[i];
                    end = args[i];

                    sequenceLength = 0;
                }

                
                sequenceLength++;


                if (i == args.Length - 1 && inSequence && sequenceLength >= 3)  // if it's the last index and we're in a sequence
                {
                    end = args[i];
                    list.Add($"{start}-{end}");
                }
                else if (i == args.Length - 1 && !inSequence && sequenceLength == 1)  // if last 1 number out of sequence
                {
                    end = args[i];
                    list.Add($"{start}");
                }
                else if (i == args.Length - 1 && inSequence && sequenceLength == 2)  // if last 2 numbers - consecutive
                {
                    end = args[i];
                    list.Add($"{start}");
                    list.Add($"{end}");
                }

            }





            return string.Join(',', list);
        }


    }
}
