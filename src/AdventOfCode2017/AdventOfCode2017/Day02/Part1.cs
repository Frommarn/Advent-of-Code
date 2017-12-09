using System;

namespace AdventOfCode2017.Day02
{
    class Part1
    {

        public static void Run()
        {
            int checksum = CalculateChecksum(RawInput.mInput);
            Console.WriteLine("Checksum:           " + checksum);
            Utils.ExitKey.ExitAppIfEsc();
        }

        private static int CalculateChecksum(string[] rawInput)
        {
            int sum = 0;
            foreach (string line in rawInput)
            {
                sum += GetChecksumPart(line);
            }
            return sum;
        }

        private static int GetChecksumPart(string line)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            int[] ints = RawInput.TransformInputFromStringToInts(line);

            foreach (int i in ints)
            {
                if (i > max)
                {
                    max = i;
                }
                if (i < min)
                {
                    min = i;
                }
            }
            return max - min;
        }
    }
}
