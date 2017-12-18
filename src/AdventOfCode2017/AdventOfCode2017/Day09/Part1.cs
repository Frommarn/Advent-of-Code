using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2017.Day09
{
    public static class Part1
    {
        public static void Run()
        {
            //string[] data = Utils.RawInputParser.ReadRawInputFromFile("09", "testInput.txt");
            string[] data = Utils.RawInputParser.ReadRawInputFromFile("09", "rawInput.txt");
            List<int> scores = FindTotalScores(data);
            foreach (int score in scores)
            {
                 Console.WriteLine("The score is: " + score);
            }
            Utils.ExitKey.ExitAppIfEsc();
        }

        private static List<int> FindTotalScores(string[] data)
        {
            List<int> totalScores = new List<int>();
            int score;

            foreach (string line in data)
            {
                score = FindTotalScore(line);
                totalScores.Add(score);
            }
            return totalScores;
        }

        private static int FindTotalScore(string line)
        {
            string cleanedLine = GarbageRemover.RemoveGarbage(line);
            return CalculateTotalScore(cleanedLine, 0, 0);
        }

       

        private static int CalculateTotalScore(string cleanedLine, int index, int groupValue)
        {
            // Base case
            if (cleanedLine.Length == index)
            {
                return 0;
            }

            if (cleanedLine[index] == '{')
            {
                groupValue++;   // Stepped into a group, increment group value
                return groupValue + CalculateTotalScore(cleanedLine, index + 1, groupValue);
            }
            else if (cleanedLine[index] == '}')
            {
                groupValue--;   // Stepped out of a group, decrement group value
                return CalculateTotalScore(cleanedLine, index + 1, groupValue);
            }
            else
            {
                return CalculateTotalScore(cleanedLine, index + 1, groupValue);
            }
        }
    }
}
