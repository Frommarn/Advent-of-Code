using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Day07
{
    public static class Part2
    {
        private class Data
        {
            public int Weight { get; private set; }
            public bool IsThisTheCorrectedFaultyWeight { get; private set; }

            public Data(int weight, bool isThisTheCorrectedFaultyWeight)
            {
                Weight = weight;
                IsThisTheCorrectedFaultyWeight = isThisTheCorrectedFaultyWeight;
            }
        }

        public static void Run()
        {
            //string[] data = Utils.RawInputParser.ReadRawInputFromFile("07", "TestInput.txt");
            string[] data = Utils.RawInputParser.ReadRawInputFromFile("07", "rawInput.txt");
            int faultymProgramWeight = FindWeightOfFaultyPorgram(data);
            Console.WriteLine("The correct weight of the faulty program is: " + faultymProgramWeight);
            Utils.ExitKey.ExitAppIfEsc();
        }

        private static int FindWeightOfFaultyPorgram(string[] data)
        {
            List<ProgramData2> programs = ParsePrograms(data);

            ProgramData2 rootProgram = programs.Find(o => o.IsCarried == false && o.IsCarryingOthers == true);
            return CalculateProgramWeight(rootProgram).Weight;
        }

        private static Data CalculateProgramWeight(ProgramData2 program)
        {
            // Base case
            if (program.IsCarryingOthers == false)
            {
                return new Data(program.Weight, false);
            }

            // Recursive case
            List<int> carriedProgramWeights = new List<int>();
            foreach (ProgramData2 carriedProgram in program.GetCarriedPrograms())
            {
                Data result = CalculateProgramWeight(carriedProgram);
                if (result.IsThisTheCorrectedFaultyWeight)
                {
                    return result;
                }
                else
                {
                    carriedProgramWeights.Add(result.Weight);
                }
            }

            // Evaluation
            List<int> distinctWeights = carriedProgramWeights.Distinct().ToList();
            // All carried programs have the same weight - OK
            // Only two carried programs, with different weights - One is faulty, don't know which
            if (distinctWeights.Count == 1 || carriedProgramWeights.Count == 2)
            {
                program.TotalWeight = carriedProgramWeights.Sum() + program.Weight;
                return new Data(program.TotalWeight, false);
            }
            // One of the programs weights are faulty
            else
            {
                // Only two carried programs, with different weights - One is faulty, don't know which
                if (carriedProgramWeights.Count == 2)
                {
                    return new Data(carriedProgramWeights.Sum() + program.Weight, false);
                }

                // Three or more carried programs, one with different weight than the others - Faulty one found!
                carriedProgramWeights.Sort();

                // The faulty programs weight is too light
                if (carriedProgramWeights[0] < carriedProgramWeights[1])
                {
                    ProgramData2 faultyProgram = program.GetCarriedPrograms().Select(o => o as ProgramData2).ToList()
                        .Find(o => o.TotalWeight == carriedProgramWeights[0]);
                    int correctWeight = CalculateCorrectWeight(faultyProgram, carriedProgramWeights[1]);
                    return new Data(correctWeight, true);
                }
                // The faulty programs weight is too heavy
                else if (carriedProgramWeights[carriedProgramWeights.Count - 2] < carriedProgramWeights[carriedProgramWeights.Count - 1])
                {
                    ProgramData2 faultyProgram = program.GetCarriedPrograms().Select(o => o as ProgramData2).ToList()
                        .Find(o => o.TotalWeight == carriedProgramWeights[carriedProgramWeights.Count - 1]);
                    int correctWeight = CalculateCorrectWeight(faultyProgram, carriedProgramWeights[carriedProgramWeights.Count - 2]);
                    return new Data(correctWeight, true);
                }
                else
                {
                    throw new Exception("The recursive algorithm is broken!");
                }
            }
        }

        private static int CalculateCorrectWeight(ProgramData2 faultyProgram, int correctWeight)
        {
            // Only two carried programs, with different weights - One is faulty, don't know which
            if (faultyProgram.GetCarriedPrograms().Count == 2 &&
                faultyProgram.GetCarriedPrograms()[0].Weight != faultyProgram.GetCarriedPrograms()[1].Weight)
            {
                return (correctWeight - faultyProgram.Weight) / 2;
            }
            else
            {
                int carriedWeight = faultyProgram.GetCarriedPrograms().Select(o => o as ProgramData2).Sum(o => o.TotalWeight == 0 ? o.Weight : o.TotalWeight);
                return correctWeight - carriedWeight;
            }
        }

        private static List<ProgramData2> ParsePrograms(string[] data)
        {
            List<ProgramData2> programs = new List<ProgramData2>();

            // First parse program names & weights (& raw link data)
            foreach (string rawProgramData2 in data)
            {
                ProgramData2 program = ParseProgram(rawProgramData2);
                programs.Add(program);
            }

            // Then parse the linked (carried) programs
            foreach (ProgramData2 program in programs)
            {
                ParseProgramLinks(program, programs);
            }

            return programs;
        }

        private static ProgramData2 ParseProgram(string rawProgramData2)
        {
            string[] parts = rawProgramData2.Split(new string[] { " (", ")" }, StringSplitOptions.RemoveEmptyEntries );
            ProgramData2 program = new ProgramData2();
            if (parts.Count() >= 1)
            {
                program.Name = parts[0];
            }
            if (parts.Count() >= 2)
            {
                program.Weight = int.Parse(parts[1]);
            }
            if (parts.Count() >= 3)
            {
                program.RawCarriedProgramNames = parts[2].Substring(4); // Skip ' -> '
            }
            return program;
        }

        private static void ParseProgramLinks(ProgramData2 program, List<ProgramData2> programs)
        {
            if (program.RawCarriedProgramNames == "")
            {
                return;
            }
            string[] otherProgramNames = program.RawCarriedProgramNames.Split(new string[] { ", " }, StringSplitOptions.None);
            foreach (string programName in otherProgramNames)
            {
                ProgramData2 linkedProgram = programs.Find(o => o.Name == programName);
                if (linkedProgram != null)
                {
                    program.AddCarriedProgram(linkedProgram);
                }
            }
        }
    }
}
