using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day06
{
    public static class Part2
    {
        private class Data
        {
            public string Distribution { get; set; }
            public int Cycle { get; set; }
        }

        public static void Run()
        {
            string[] memoryBanks = Utils.RawInputParser.ReadRawInputFromFile("06", "rawInput.txt")[0].Split('\t');
            int nrOfCycles = CalculateNrOFCycles(memoryBanks);
            Console.WriteLine("Number of redistribution cycles: " + nrOfCycles);
            Utils.ExitKey.ExitAppIfEsc();
        }

        private static int CalculateNrOFCycles(string[] memoryBanks)
        {
            //int[] memoryBanksAsInts = new int[] { 0, 2, 7, 0 };
            int[] memoryBanksAsInts = memoryBanks.Select(s => int.Parse(s)).ToArray();
            List<Data> memoryBankDistributions = new List<Data>();
            memoryBankDistributions.Add(new Data() { Distribution = StringifyMemoryBanks(memoryBanksAsInts), Cycle = 0 });
            int nrOfCycles = 0;

            // "flat recursion"
            while (true)
            {
                nrOfCycles++;
                RedistributeMemory(ref memoryBanksAsInts);

                string stringifiedMemoryBanks = StringifyMemoryBanks(memoryBanksAsInts);
                
                // base case
                if (memoryBankDistributions.Any(o => o.Distribution == stringifiedMemoryBanks))
                {
                    return nrOfCycles - memoryBankDistributions.Find(o => o.Distribution == stringifiedMemoryBanks).Cycle;
                }

                memoryBankDistributions.Add(new Data() { Distribution = stringifiedMemoryBanks, Cycle = nrOfCycles });
            }
        }

        private static void RedistributeMemory(ref int[] memoryBanksAsInts)
        {
            // Find out which Memory Bank has the most blocks (position and nr of blocks)
            int blocksTodistribute = memoryBanksAsInts.Max();
            int position = memoryBanksAsInts.ToList().IndexOf(blocksTodistribute);
            memoryBanksAsInts[position] = 0;

            // Redistribute the blocks
            while (blocksTodistribute > 0)
            {
                position++;
                // Wrap around to the beginning
                if (position >= memoryBanksAsInts.Count())
                {
                    position = 0;
                }

                // Place a block
                memoryBanksAsInts[position]++;
                blocksTodistribute--;
            }
        }

        private static string StringifyMemoryBanks(int[] memoryBanksAsInts)
        {
            return memoryBanksAsInts.Aggregate("", (s, i) => s += i.ToString().PadLeft(3));
        }
    }
}
