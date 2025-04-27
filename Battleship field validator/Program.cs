// https://www.codewars.com/kata/52bb6539a4cf1b12d90005b7/train/csharp

namespace Battleship_field_validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = new int[,]
            {
                { 1, 1 },
                { 0, 0 },
                { 1, 0 },
                { 0, 1 }
            };

            Console.WriteLine(BattleshipField.ValidateBattlefield(input));
        }
    }

    public class BattleshipField
    {
        public static Dictionary<int, int> shipsCounts = new Dictionary<int, int>();

        public static int[,] board;

        public static bool ValidateBattlefield(int[,] field)
        {
            shipsCounts = new Dictionary<int, int>();
            board = field;

            CountVertial();
            CountHorizontal();
            CountShips1();

            return
                !HasDiagonals() &&
                Ships4 == 1 &&
                Ships3 == 2 &&
                Ships2 == 3 &&
                Ships1 == 4 &&
                ShipsLong == 0;
        }

        public static int ShipsLong =>
            shipsCounts
                .Where(pair => pair.Key > 4)
                .Sum(pair => pair.Value);

        public static int Ships1 => shipsCounts[1];

        public static int Ships2 => shipsCounts[2];

        public static int Ships3 => shipsCounts[3];

        public static int Ships4 => shipsCounts[4];

        private static bool HasDiagonals()
        {
            bool result = false;

            for (var row = 0; row < board.GetLength(0); row++)
                for (var col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == 1) // ship piece
                    {
                        if (row == board.GetLength(0) - 1) // last row
                        {
                            break; // no diagonals to check
                        }

                        if (col == 0) // 1st - starting scell
                        {
                            if (board[row + 1, col + 1] == 1) // ship piece
                            {
                                return true;
                            }
                        }
                        else if (col == board.GetLength(1) - 1) // 10th - last cell
                        {
                            if (board[row + 1, col - 1] == 1) // ship piece
                            {
                                return true;
                            }
                        }
                        else // 2nd to 9th cells
                        {
                            if (board[row + 1, col + 1] == 1 ||
                                board[row + 1, col - 1] == 1) // ship piece
                            {
                                return true;
                            }
                        }
                    }

                }

            return result;
        }

        private static void CountShips1()
        {
            throw new NotImplementedException();
        }

        private static void CountHorizontal()
        {
            throw new NotImplementedException();
        }

        private static void CountVertial()
        {
            throw new NotImplementedException();
        }
    }
}
