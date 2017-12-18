using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Day09
{
    public static class GarbageBase
    {
        public static int FindFirstGarbageStart(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '<')
                {
                    return i;
                }
            }
            return int.MinValue;    // This should never happen!
        }

        public static int FindFirstGarbageEnd(string line, int startPosition)
        {
            for (int i = startPosition; i < line.Length; i++)
            {
                if (line[i] == '>' && IsNrOfPreceedingExclamationMarksEven(line, i - 1))
                {
                    return i;
                }
            }
            return int.MinValue;    // This should never happen!
        }

        public static bool IsNrOfPreceedingExclamationMarksEven(string line, int index)
        {
            int nrOfPreceedingExclamationMarks = 0;
            while (index > -1)
            {
                if (line[index] == '!')
                {
                    nrOfPreceedingExclamationMarks++;
                    index--;
                }
                else
                {
                    break;
                }
            }
            return nrOfPreceedingExclamationMarks % 2 == 0;
        }
    }
}
