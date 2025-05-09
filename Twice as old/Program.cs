namespace Twice_as_old
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            TwiceAsOldSolution.TwiceAsOld(23, 7);
            /*
             *False 23 7
               False 24 8
               False 25 9
               False 26 10
               False 27 11
               False 28 12
               False 29 13
               False 30 14
               False 31 15
               True 32 16
               False 33 17
               False 34 18
               False 35 19
               False 36 20
               False 37 21
               False 38 22
               False 39 23
               False 40 24
               False 41 25
               False 42 26
               False 43 27
               False 44 28
               False 45 29
               False 46 30
               False 47 31
               False 48 32
               False 49 33
               False 50 34
               False 51 35
               False 52 36
               False 53 37
               False 54 38
               False 55 39
               False 56 40
               False 57 41
               False 58 42
               False 59 43
               False 60 44
               False 61 45
               False 62 46
               False 63 47
               False 64 48
               False 65 49
               False 66 50
               False 67 51
               False 68 52
               False 69 53
               False 70 54
               False 71 55
               False 72 56
               False 73 57
               False 74 58
               False 75 59
               False 76 60
               False 77 61
               False 78 62
               False 79 63
               False 80 64
               False 81 65
               False 82 66
               False 83 67
               False 84 68
               False 85 69
               False 86 70
               False 87 71
               False 88 72
               False 89 73
               False 90 74
               False 91 75
               False 92 76
               False 93 77
               False 94 78
               False 95 79
               False 96 80
               False 97 81
               False 98 82
               False 99 83
               False 100 84
               False 101 85
               False 102 86
               False 103 87
               False 104 88
               False 105 89
               False 106 90
               False 107 91
               False 108 92
               False 109 93
               False 110 94
               False 111 95
               False 112 96
               False 113 97
               False 114 98
               False 115 99
               False 116 100
               False 117 101
               False 118 102
               False 119 103
               False 120 104
               False 121 105
               False 122 106
             */
        }
    }

    public class TwiceAsOldSolution
    {
        public static int TwiceAsOld(int dadYears, int sonYears)
        {
            int current = dadYears;

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"{(dadYears == sonYears * 2)} {dadYears} {sonYears}");

                if (dadYears == sonYears * 2)
                {
                    return dadYears - current;
                }

                dadYears++;
                sonYears++;

            }

            for (; sonYears > 0; sonYears--)
            {
                Console.WriteLine($"{(dadYears == sonYears * 2)} {dadYears} {sonYears}");

                if (dadYears == sonYears * 2)
                {
                    return Math.Abs(dadYears - current);
                }

                dadYears--;
            }

            return 0;
        }
    }


}
