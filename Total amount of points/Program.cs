namespace Total_amount_of_points
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TotalPoints(new string[] { "3:1", "2:2", "0:1" }));
        }


        public static int TotalPoints(string[] games)
        {
            int sum = 0;

            foreach (string game in games)
            {
                int x = int.Parse(game[0].ToString());
                int y = int.Parse(game[2].ToString());

                if (x > y)
                {
                    sum += 3;
                }
                else if (x < y)
                {
                    sum += 0;
                }
                else  // x == y
                {
                    sum += 1;
                }
            }

            return sum;
        }
    }
}
