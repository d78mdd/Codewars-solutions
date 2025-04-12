namespace Array.diff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (int item in ArrayDiff(new int[] { 1, 2, 2, 2, 3 }, new int[] { 2 }))
            {
                Console.Write(item);
            }
            Console.WriteLine();

            foreach (int item in ArrayDiff(new int[] { 1, 2, 2 }, new int[] { 1 }))
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }


        public static int[] ArrayDiff(int[] a, int[] b)
        {
            List<int> result = a.ToList();

            result.RemoveAll(i => b.Contains(i));

            return result.ToArray();
        }

    }
}
