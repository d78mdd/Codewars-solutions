// https://www.codewars.com/kata/52bb6539a4cf1b12d90005b7/train/csharp

namespace Battleship_field_validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = new int[,]
            {
                { 0, 1, 1 },
                { 0, 0, 0 },
                { 1, 0, 0 },
                { 1, 0, 1 }
            };

            Console.WriteLine(BattleshipField.ValidateBattlefield(input));
        }
    }

    public class BattleshipField
    {
        public static Dictionary<int, int> shipsCounts;

        public static int[,] board;

        public static bool ValidateBattlefield(int[,] field)
        {
            shipsCounts = new Dictionary<int, int>()
            {
                { 1, 0 },
                { 2, 0 },
                { 3, 0 },
                { 4, 0 },
                { 5, 0 }
            };
            board = field;

            CountVertical();
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
            // iterate from 1st to next to last row
            for (var row = 0; row < board.GetLength(0) - 1; row++)
            {
                for (var col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == 1) // ship piece
                    {
                        if (col == 0) // 1st - starting cell
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
            }

            return false;
        }

        private static void CountShips1()  // count ships of size 1
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                int shipPieces = 0;

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == 1)  // ship piece
                    {
                        if (((row < board.GetLength(0) - 1 && board[row + 1, col] == 0) || row == board.GetLength(0) - 1) &&  // below is empty
                            ((row > 0 && board[row - 1, col] == 0) || row == 0))  // above is empty
                        {
                            shipPieces++;
                        }
                    }

                    if (board[row, col] == 0 ||  // no ship piece (empty)
                        col == board.GetLength(1) - 1)  // end of row
                    {
                        if (shipPieces == 1)
                        {
                            shipsCounts[1]++;
                        }
                        // else do nothing

                        shipPieces = 0;
                    }

                }
            }

        }

        private static void CountHorizontal()  // count 1+ ships placed horizontally
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                int shipPieces = 0;

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == 1)  // ship piece
                    {
                        shipPieces++;
                    }

                    if (board[row, col] == 0 ||  // no ship piece
                        col == board.GetLength(1) - 1)  // end of row
                    {
                        if (shipPieces == 2)
                        {
                            shipsCounts[2]++;
                        }
                        else if (shipPieces == 3)
                        {
                            shipsCounts[3]++;
                        }
                        else if (shipPieces == 4)
                        {
                            shipsCounts[4]++;
                        }
                        else if (shipPieces > 4)
                        {
                            shipsCounts[5]++; // long ships >4 pieces
                        }
                        else
                        {
                            // do nothing
                        }

                        shipPieces = 0;
                    }

                }
            }
        }

        private static void CountVertical() // count 1+ ships placed vertically
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                int shipPieces = 0;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    if (board[row, col] == 1)  // ship piece
                    {
                        shipPieces++;
                    }

                    if (board[row, col] == 0 || // no ship piece (empty)
                      row == board.GetLength(0) - 1)// end of column
                    {
                        if (shipPieces == 2)
                        {
                            shipsCounts[2]++;
                        }
                        else if (shipPieces == 3)
                        {
                            shipsCounts[3]++;
                        }
                        else if (shipPieces == 4)
                        {
                            shipsCounts[4]++;
                        }
                        else if (shipPieces > 4)
                        {
                            shipsCounts[5]++; // long ships >4 pieces
                        }
                        else
                        {
                            // do nothing
                        }

                        shipPieces = 0;
                    }

                }
            }

        }
    }
}
