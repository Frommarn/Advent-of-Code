using System;
using System.Linq;

namespace AdventOfCode2017.Day05
{
    public static class Part1
    {
        public static void Run()
        {
            int nrOfJumps = CountNrOfJumpsNeeded(Utils.RawInputParser.ReadRawInputFromFile("05", "rawInput.txt"));
            Console.WriteLine("Nr of jumps to escape the maze: " + nrOfJumps);
            Utils.ExitKey.ExitAppIfEsc();
        }

        private static int CountNrOfJumpsNeeded(string[] jumpLines)
        {
            //jumpLines = new string[] { "0", "3", "0", "1", "-3" };
            int[] jumpLinesAsInts = jumpLines.Select(s => int.Parse(s)).ToArray();
            int nrOfJumpsJumped = 0;
            int currentLinePosition = 0;

            while (true)
            {
                // Debug printing
                //for (int i = 0; i < jumpLinesAsInts.Count(); i++)
                //{
                //    if (i == currentLinePosition)
                //    {
                //        Console.Write("(" + jumpLinesAsInts[i] + ") ");
                //    }
                //    else
                //    {
                //        Console.Write(jumpLinesAsInts[i] + " ");
                //    }
                //}
                //Console.WriteLine();

                try
                {
                    ExecuteJump(ref jumpLinesAsInts, ref currentLinePosition);
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
                nrOfJumpsJumped++;
            }

            return nrOfJumpsJumped;
        }

        private static void ExecuteJump(ref int[] jumpLinesAsInts, ref int currentLinePosition)
        {
            currentLinePosition += jumpLinesAsInts[currentLinePosition]++;
        }
    }
}
