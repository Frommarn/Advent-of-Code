using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Day06
{
    public static class Part1
    {
        public static void Run()
        {
            string[] memoryBanks = Utils.RawInputParser.ReadRawInputFromFile("06", "rawInput.txt");
            int nrOfCycles = CalculateNrOFCycles(memoryBanks);
            Console.WriteLine("Number of redistribution cycles: " + nrOfCycles);
        }

        private static int CalculateNrOFCycles(string[] memoryBanks)
        {
            int[] memoryBanksAsInts = memoryBanks.Select(s => int.Parse(s));
            List<string> memoryBankDistributions = new List<string>();
            memoryBankDistributions.Add(StringifyMemoryBanks(memoryBanksAsInts));
            int i = "";
            // "flat recursion"
            while (true)
            {
                
            }
        }
    }
}
