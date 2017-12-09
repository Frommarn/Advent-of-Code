using System;
using System.Linq;

namespace AdventOfCode2017.Day04
{
    public static class Part1
    {
        public static void Run()
        {
            int nrOfValidPassPhrases = CountValidPassPhrases(Utils.RawInputParser.ReadRawInputFromFile("04", "rawInput.txt"));
            Console.WriteLine("The number of valid passphrases are: " + nrOfValidPassPhrases);
            Utils.ExitKey.ExitAppIfEsc();
        }

        private static int CountValidPassPhrases(string[] passPhrases)
        {
            int count = 0;
            foreach (string passPhrase in passPhrases)
            {
                if (IsPassPhraseValid(passPhrase))
                {
                    count++;
                }
            }
            return count;
        }

        private static bool IsPassPhraseValid(string passPhrase)
        {
            string[] passWords = passPhrase.Split(' ');
            return !passWords.Any(s1 => passWords.Where(s2 => s1.Equals(s2)).Count() != 1);
        }
    }
}
