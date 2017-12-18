using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Day09
{
    public static class Part2
    {
        public static void Run()
        {
            //string[] data = Utils.RawInputParser.ReadRawInputFromFile("09", "testInput.txt");
            string[] data = Utils.RawInputParser.ReadRawInputFromFile("09", "rawInput.txt");
            List<int> scores = FindAllAmountsOfGarbage(data);
            foreach (int score in scores)
            {
                Console.WriteLine("The score is: " + score);
            }
            Utils.ExitKey.ExitAppIfEsc();
        }

        private static List<int> FindAllAmountsOfGarbage(string[] data)
        {
            List<int> totalScores = new List<int>();
            int score;

            foreach (string line in data)
            {
                score = FindAmountOfGarbage(line);
                totalScores.Add(score);
            }
            return totalScores;
        }

        private static int FindAmountOfGarbage(string line)
        {
            List<string> extractedGarbageLines = GarbageExtracter.ExtractGarbage(line);
            int sum = 0;
            foreach (string garbage in extractedGarbageLines)
            {
                int count = CountGarbage(garbage);
                sum += count;
            }
            return sum;
        }

        private static int CountGarbage(string garbage)
        {
            string cleanedGarbage = RemoveCancelledGarbage(garbage);
            return cleanedGarbage.Length - 2;  // subtract the first '<' & the last '>'
        }

        private static string RemoveCancelledGarbage(string garbage)
        {
            int exclamationIndex;
            string firstPart;
            string secondPart;
            while (garbage.Contains("!"))
            {
                exclamationIndex = garbage.IndexOf('!');
                firstPart = garbage.Substring(0, exclamationIndex);
                secondPart = garbage.Substring(exclamationIndex + 2);   // Remove the '!' and the next character
                garbage = firstPart + secondPart;
            }
            return garbage;
        }
    }
}
