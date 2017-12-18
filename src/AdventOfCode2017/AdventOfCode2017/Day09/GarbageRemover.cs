using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Day09
{
    public static class GarbageRemover
    {
        public static string RemoveGarbage(string line)
        {
            int startPosition;
            int endPosition;
            string firstPart;
            string secondPart;

            while (true)
            {
                startPosition = GarbageBase.FindFirstGarbageStart(line);
                if (startPosition != int.MinValue)
                {
                    endPosition = GarbageBase.FindFirstGarbageEnd(line, startPosition);
                    if (endPosition == int.MinValue)
                    {
                        throw new Exception("This should never happen! Did not find an end to the garbage!");
                    }
                    firstPart = line.Substring(0, startPosition);
                    secondPart = line.Substring(endPosition + 1);
                    line = firstPart + secondPart;
                }
                else
                {
                    break;
                }
            }
            return line;
        }
    }
}
