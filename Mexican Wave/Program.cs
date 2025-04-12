namespace Mexican_Wave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (string elem in new Program().wave("asdasd"))
            {
                Console.WriteLine(elem);
            }
            foreach (string elem in new Program().wave(" asd asd"))
            {
                Console.WriteLine(elem);
            }
        }


        public List<string> wave(string str)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    continue;
                }

                char[] waveFrameArray = str.ToCharArray();

                waveFrameArray[i] = char.ToUpper(waveFrameArray[i]);

                string waveFrame = new string(waveFrameArray);

                result.Add(waveFrame);
            }

            return result;
        }

    }
}
