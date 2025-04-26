// https://www.codewars.com/kata/5263c6999e0f40dee200059d/train/csharp

using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

/*
 * 369 :
 *
 * 236
 * 238
 * 239
 *
 * 256
 * 258
 * 259
 *
 * 296
 * 298
 * 299
 *
 * 266
 * 268
 * 269
 *
 *
 * 636
 * 638
 * 639
 *
 * 656
 * 658
 * 659
 *
 * 696
 * 698
 * 699
 *
 * 666
 * 668
 * 669
 *
 *
 * 336
 * 338
 * 339
 *
 * 356
 * 358
 * 359
 *
 * 396
 * 398
 * 399
 *
 * 366
 * 368
 * 369
 *
 *
 */

/*
 * if 0 then 8
 * if 1 then 2 and 4
 * if 2 then 1,3,5
 * if 3 then 2,6
 * if 4 then 1,5,7
 * if 5 then 2,4,6,8
 * if 6 then 3,5,9
 * if 7 then 4,8
 * if 8 then 5,7,9,0
 * if 9 then 6,8
 */

namespace The_observed_PIN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kata.GetPINs("571");
        }
    }

    public class Kata
    {
        // key - digit 0-9
        // value - its variances
        public static Dictionary<char, char[]> allVariations = new Dictionary<char, char[]>()
        {
            { '0', new char[] { '0', '8' } },
            { '1', new char[] { '1', '2', '4' } },
            { '2', new char[] { '2', '1', '3', '5' } },
            { '3', new char[] { '3', '2', '6' } },
            { '4', new char[] { '4', '1', '5', '7' } },
            { '5', new char[] { '5', '2', '4', '6', '8' } },
            { '6', new char[] { '6', '3', '5', '9' } },
            { '7', new char[] { '7', '4', '8' } },
            { '8', new char[] { '8', '5', '7', '9', '0' } },
            { '9', new char[] { '9', '6', '8' } }
        };

        public static List<char[]> variationsList = new List<char[]>();  // variations of each of the observed digits

        public static string Observed;

        public static List<string> possiblePins = new List<string>();

        // keep track of current number variation being constructed
        public static List<char> numberVariationChars = new List<char>();

        public static List<string> GetPINs(string observed)
        {
            // init
            variationsList = new List<char[]>();
            Observed = observed;
            possiblePins = new List<string>();
            numberVariationChars = new List<char>();


            // collect incoming digits' variations
            for (int j = 0; j < observed.Length; j++)
            {
                variationsList.Add(allVariations[observed[j]]);
            }



            //// for keeping track of indexes to use during variations composing/constructing
            // init all with 0
            Dictionary<int, int> indexesCurrent = new Dictionary<int, int>();
            for (int dI = 0; dI < variationsList.Count; dI++)  // digitIndex
            {
                indexesCurrent.Add(dI, 0);
            }

            // get all digits' counts of variations (max/last possible index in its variations list)
            List<int> indexesLast = new List<int>();
            for (int i = 0; i < variationsList.Count; i++)
            {
                int count = variationsList[i].Length;
                indexesLast.Add(count - 1);
            }



            // keep track of digit index and thus variationsList index
            int digitIndex = 0;



            bool done = false;

            for (; ; )
            {
                TakeValue(digitIndex, indexesCurrent);


                bool wasNotFinalDigit = digitIndex + 1 <= variationsList.Count - 1;
                if (wasNotFinalDigit)  // this was not final digit
                {
                    // move on to the next digit thus its variations
                    digitIndex++;

                    continue;
                }
                // else  // (digitIndex > variationsList.Count - 1)  // this was final digit

                //// One possible number's digits were collected

                Add();


                bool wasNotLastDigitVariant = indexesCurrent[digitIndex] + 1 <= indexesLast[digitIndex];
                if (wasNotLastDigitVariant)  // this was not last variant of the digit
                {
                    // increment the variation internal index (move on to the next variant of this digit)
                    indexesCurrent[digitIndex]++;
                }
                else  // this was the last variant of this digit
                {
                    //// update current and previous digits' variants indexes

                    // if a previous digit exists go to previous digit's next variants index if such exists
                    for (int i = digitIndex; ; i--)
                    {

                        // update all variants' indexes to 0 except the leftmost one that's not last - increment that one

                        if (i >= 0) // valid digit index
                        {
                            if (indexesCurrent[i] + 1 <= indexesLast[i])  // if not last variant index
                            {
                                indexesCurrent[i]++;
                                break;
                            }
                            else  // last variant index
                            {
                                indexesCurrent[i] = 0;
                            }
                        }
                        else  // all indexes were exhausted - done
                        {
                            done = true;
                            break;
                        }

                    }

                }

                digitIndex = 0;  // go back to 1st digit - 1st variations array

                if (done)
                {
                    break;
                }

            }

            return possiblePins;
        }

        private static void Add()
        {
            // add possible number's digits to the list of possible PINs and refresh the var that keeps track of current
            string newNumber = string.Join("", numberVariationChars);
            possiblePins.Add(newNumber);
            numberVariationChars = new List<char>();
        }

        private static void TakeValue(int digitIndex, Dictionary<int, int> indexesCurrent)
        {
            // take a variations array
            char[] variations = variationsList[digitIndex];

            // take a value from it
            int variationIndex = indexesCurrent[digitIndex];
            char variation = variations[variationIndex];

            // put the value in the currently constructed number
            numberVariationChars.Add(variation);
        }
    }

}
