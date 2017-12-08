using System;
using System.Linq;

namespace AdventOfCode2017.Day02
{
    class Part2
    {
        public static void Run()
        {
            int divisibleChecksum = CalculateDivisibleChecksum(RawInput.mInput);
            Console.WriteLine("Divisible checksum: " + divisibleChecksum);
            Console.ReadKey();
        }

        private static int CalculateDivisibleChecksum(string[] rawInput)
        {
            int sum = 0;
            foreach (string line in rawInput)
            {
                sum += GetDivisibleChecksumPart(line);
            }
            return sum;
        }

        private static int GetDivisibleChecksumPart(string line)
        {
            int divResult = 0;
            int divRest = -1;
            int[] ints = RawInput.TransformInputFromStringToInts(line).OrderBy(i => i).ToArray();

            for (int i = 0; i < ints.Length; i++)
            {
                for (int j = i + 1; j < ints.Length; j++)
                {
                    divResult = Math.DivRem(ints[j], ints[i], out divRest);
                    if (divRest == 0)
                    {
                        return divResult;
                    }
                }
            }
            return 0;
        }
    }
}
