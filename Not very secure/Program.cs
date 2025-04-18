namespace Not_very_secure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Alphanumeric("Mazinkaiser"));
            Console.WriteLine(Alphanumeric("hello world_"));
            Console.WriteLine(Alphanumeric("PassW0rd"));
            Console.WriteLine(Alphanumeric("     "));
        }

        public static bool Alphanumeric(string str)
        {
            return (
                str.Length > 0 &&
                str.All(c => "abcdefghijklmnopqrstuvwxwzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".Contains(c))
                );
        }

    }
}
