// https://www.codewars.com/kata/56882731514ec3ec3d000009/train/csharp

namespace Connect_Four___approach_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class ConnectFour
    {

        public static List<Stack<Piece>> Board = new List<Stack<Piece>>(); // static ok?


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

        //public static void InitBoard()
        //{
        //    foreach (Stack<Piece> column in Board)
        //    {
        //        for (int i = 0; i < column.Count; i++)
        //        {
        //            column[i] = Piece.Empty;
        //        }
        //    }
        //}

        public static void AddPiece(string column, string player)
        {
            Columns columnC;

            Piece piece;

            switch (player)
            {
                case "Red": piece = Piece.Red; break;
                case "Yellow": piece = Piece.Yellow; break;
                default: piece = Piece.Yellow; break;
            }

            switch (column)
            {
                case "A": columnC = Columns.A; break;
                case "B": columnC = Columns.B; break;
                case "C": columnC = Columns.C; break;
                case "D": columnC = Columns.D; break;
                case "E": columnC = Columns.E; break;
                case "F": columnC = Columns.F; break;
                case "G": columnC = Columns.G; break;
                default: columnC = Columns.G; break;
            }

            Board.ElementAt((int)columnC).Push(piece);
        }


        public static bool Wins(string player)
        {
            if (Horizontal(player) || Vertical(player) || Diagonal(player))
            {
                return true;
            }

            return false;
        }

        public static bool Diagonal(string player)
        {
            for (int i = 0; i <= 7 - 4; i++) // ?
            {
                for (int j = 0; i <= 6 - 4; j++) // ?
                {
                    if (true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool Vertical(string player)
        {
            for (int i = 0; i < 7; i++) // ?
            {
                for (int j = 0; i <= 6 - 4; j++) // ?
                {
                    if (true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool Horizontal(string player)
        {
            //for (int i = 0; i <= 7 - 4; i++) // ?
            //{
            //    for (int j = 0; i < 6; j++) // ?
            //    {
            //        if (Board[i][j] == Board[i][j + 1]
            //            && Board[i][j + 1] == Board[i][j + 2]
            //            && Board[i][j + 2] == Board[i][j + 3])
            //        {
            //            return true;
            //        }
            //    }
            //}
            return false;
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
