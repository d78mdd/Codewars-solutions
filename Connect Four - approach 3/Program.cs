// https://www.codewars.com/kata/56882731514ec3ec3d000009/train/csharp

using System.Data;
using System.IO.Enumeration;
using Microsoft.VisualBasic;

namespace Connect_Four___approach_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectFour.InitBoard();

            //ConnectFour.AddPiece("A", "Red");
            //ConnectFour.AddPiece("B", "Red");
            //ConnectFour.AddPiece("C", "Red");
            ConnectFour.AddPiece("E", "Red");
            ConnectFour.AddPiece("F", "Red");
            ConnectFour.AddPiece("G", "Ред");

            Console.WriteLine(ConnectFour.HasHorizontal("Red"));

            ConnectFour.Print();
        }
    }


    public class ConnectFour
    {
        public static List<List<Piece>> Board = new List<List<Piece>>(); // static ok?

        public static string WhoIsWinner(List<string> piecesPositionList)
        {
            //InitBoard();

            for (int i = 0; i < piecesPositionList.Count; i++) // max 42?
            {
                string[] input = piecesPositionList[i].Split('_');
                string column = input[0];
                string player = input[1];

                AddPiece(column, player);
                if (Wins(player))
                {
                    return player;
                }
            }

            return Results.Draw.ToString();
        }

        public static void InitBoard()
        {
            for (int row = 0; row < 6; row++)
            {
                Board.Add(new List<Piece>());

                for (int col = 0; col < 7; col++)
                {
                    Board[row].Add(Piece.Empty);
                }
            }
        }

        public static void AddPiece(string column, string player)
        {
            int columnInt;

            Piece piece;

            switch (player)
            {
                case "Red": piece = Piece.Red; break;
                case "Yellow": piece = Piece.Yellow; break;
                default:
                    throw new Exception($"invalid player {player}");
            }

            switch (column)
            {
                case "A": columnInt = 0; break;
                case "B": columnInt = 1; break;
                case "C": columnInt = 2; break;
                case "D": columnInt = 3; break;
                case "E": columnInt = 4; break;
                case "F": columnInt = 5; break;
                case "G": columnInt = 6; break;
                default: throw new Exception($"invalid column {column}");
            }

            int position = 5; // bottom row

            /* first 4 moves according to description
             *
             * A B C D E F G
             * 0 1 2 3 4 5 6 columnInt
             * x x x x x x x  row = 0
             * x x x x x x x  row = 1
             * x x x x x x x  row = 2
             * x x x x x x x  row = 3
             * x x x x x x x  row = 4
             * x x x x x x x  row = 5
             *
             * A B C D E F G
             * 0 1 2 3 4 5 6 columnInt
             * x x x x x x x  row = 0
             * x x x x x x x  row = 1
             * x x x x x x x  row = 2
             * x x x x x x x  row = 3
             * x x x x x x x  row = 4
             * R x x x x x x  row = 5
             *
             * A B C D E F G
             * 0 1 2 3 4 5 6 columnInt
             * x x x x x x x  row = 0
             * x x x x x x x  row = 1
             * x x x x x x x  row = 2
             * x x x x x x x  row = 3
             * x x x x x x x  row = 4
             * R Y x x x x x  row = 5
             *
             * A B C D E F G
             * 0 1 2 3 4 5 6 columnInt
             * x x x x x x x  row = 0
             * x x x x x x x  row = 1
             * x x x x x x x  row = 2
             * x x x x x x x  row = 3
             * R x x x x x x  row = 4
             * R Y x x x x x  row = 5
             *
             * A B C D E F G
             * 0 1 2 3 4 5 6 columnInt
             * x x x x x x x  row = 0
             * x x x x x x x  row = 1
             * x x x x x x x  row = 2
             * x x x x x x x  row = 3
             * R Y x x x x x  row = 4
             * R Y x x x x x  row = 5
             *
             *
             */

            // find position for the new piece
            for (int row = 5; row >= 0; row--)
            {
                if (Board[row][columnInt] != Piece.Empty)
                {
                    position--; // next row - up
                }
                else
                {
                    break; // row found
                }
            }

            // put the piece
            Board[position][columnInt] = piece;
        }


        public static bool Wins(string player)
        {
            if (HasHorizontal(player) || HasVertical(player) || HasDiagonal(player))
            {
                return true;
            }
            return false;
        }

        public static bool HasDiagonal(string player)
        {
            //for (int i = 3; i < 7; i++) // ?
            //{
            //    for (int j = 0; i <= 6 - 4; j++) // ?
            //    {
            //        // forward diagonal "/"
            //        if (Board[i][j?] == Board[i - 1][j]
            //            && Board[i - 1][j] == Board[i - 2][j]
            //            && Board[i - 2][j] == Board[i - 3][j])
            //        {
            //            return true;
            //        }

            //        // backwards diagonal "\"
            //        if (Board[i][j] == Board[i + 1][j]
            //            && Board[i + 1][j] == Board[i + 2][j]
            //            && Board[i + 2][j] == Board[i + 3][j])
            //        {
            //            return true;
            //        }
            //    }
            //}
            return false;
        }
        public static bool HasVertical(string player)
        {
            /*
             * A B C D E F G
             * 0 1 2 3 4 5 6 col
             * x x x x x x x  row = 0
             * x x x x x x x  row = 1
             * x x x x x x x  row = 2
             * x x x x x x x  row = 3
             * R Y x x x x x  row = 4
             * R Y x x x x x  row = 5
             */

            // no need to check above row 3 - not possible to have vertical line of 4 above it
            int row3 = 3;

            for (int row = 5; row >= row3; row--)
            {
                for (int col = 0; col <= 6; col++)
                {
                    if (Board[row][col] != Piece.Empty &&
                        Board[row][col] == Board[row - 1][col] &&
                        Board[row][col] == Board[row - 2][col] &&
                        Board[row][col] == Board[row - 3][col])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool HasHorizontal(string player)
        {
            /*
             * A B C D E F G
             * 0 1 2 3 4 5 6 col
             * x x x x x x x  row = 0
             * x x x x x x x  row = 1
             * x x x x x x x  row = 2
             * x x x x x x x  row = 3
             * x x x x x x x  row = 4
             * Y Y Y x x x x  row = 5
             */

            // no need to check right of column 3 - not possible to have horizontal line of 4 after it
            int col3 = 3;

            for (int col = 0; col <= col3; col++)
            {
                for (int row = 0; row <= 5; row++)
                {
                    if (Board[row][col] != Piece.Empty &&
                        Board[row][col] == Board[row][col + 1] &&
                        Board[row][col] == Board[row][col + 2] &&
                        Board[row][col] == Board[row][col + 3])
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public static void Print()
        {
            foreach (List<Piece> column in Board)
            {
                Console.WriteLine(string.Join('\t', column));
            }

        }

    }


    public enum Columns
    {
        A, B, C, D, E, F, G
    }

    public enum Piece
    {
        Empty,
        Red,
        Yellow
    }

    public enum Results
    {
        Draw,
        Yellow,
        Red
    }

    //public class Results
    //{
    //    public static string Red = "Red";
    //    public static string Yellow = "Yellow";

    //    public static string Draw = "Draw";
    //}

}
