using System;

namespace AdventOfCode2017.Utils
{
    static class ExitKey
    {
        public static void ExitAppIfEsc()
        {
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }
    }
}
