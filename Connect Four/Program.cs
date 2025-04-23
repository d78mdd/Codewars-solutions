namespace Connect_Four
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

        public static bool[][] PlayerAPieces = new bool[6][]; // correct?
        public static bool[][] PlayerBPieces = new bool[6][];


        //public static string WhoIsWinner(List<string> piecesPositionList)
        //{

        //    for (int i = 0; i < piecesPositionList.Count; i++)
        //    {
        //        string[] input = piecesPositionList[i].Split('_');
        //        string column = input[0];
        //        string player = input[1];

        //        AddPiece(column, player);
        //        if (Wins(player))
        //        {
        //            return player;
        //        }
        //    }

        //    return Results.Draw;
        //}


        //public static bool[] AddPiece(string column, string player)
        //{
        //    bool[][] result = new bool[6][];



        //    return result;
        //}


        //public static bool Wins(string player)
        //{
        //    for (int i = 0; i < UPPER; i++)
        //    {
        //        for (int j = 0; j < UPPER; j++)
        //        {
        //            if ()
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

    }

    public class Results
    {
        public static string Red = "Red";
        public static string Yellow = "Yellow";

        public static string Draw = "Draw";
    }

}
