namespace Moving_Zeros_To_The_End
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (int elem in MoveZeroes(new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 }))
            {
                Console.WriteLine(elem);
            }
        }


        public static int[] MoveZeroes(int[] arr)
        {
            List<int> nonZeroes = new List<int>();
            int zeroesCount = 0;

            foreach (int elem in arr)
            {
                if (elem != 0)
                {
                    nonZeroes.Add(elem);
                }
                else
                {
                    zeroesCount++;
                }
            }

            List<int> result = new List<int>(nonZeroes);

            for (int i = 0; i < zeroesCount; i++)
            {
                result.Add(0);
            }
            
            return result.ToArray();
        }

    }
}
