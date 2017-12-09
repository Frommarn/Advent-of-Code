using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Day07
{
    public static class Part1
    {
        public static void Run()
        {
            //string[] data = Utils.RawInputParser.ReadRawInputFromFile("07", "TestInput.txt");
            string[] data = Utils.RawInputParser.ReadRawInputFromFile("07", "rawInput.txt");
            string bottomProgramName = FindNameOfBottomProgram(data);
            Console.WriteLine("The name of the bottom program is: " + bottomProgramName);
            Utils.ExitKey.ExitAppIfEsc();
        }

        private static string FindNameOfBottomProgram(string[] data)
        {
            List<ProgramData> programs = ParsePrograms(data);

            return programs.Find(o => o.IsCarried == false && o.IsCarryingOthers == true).Name;
        }

        private static List<ProgramData> ParsePrograms(string[] data)
        {
            List<ProgramData> programs = new List<ProgramData>();

            // First parse program names & weights (& raw link data)
            foreach (string rawProgramData in data)
            {
                ProgramData program = ParseProgram(rawProgramData);
                programs.Add(program);
            }

            // Then parse the linked (carried) programs
            foreach (ProgramData program in programs)
            {
                ParseProgramLinks(program, programs);
            }

            return programs;
        }

        private static ProgramData ParseProgram(string rawProgramData)
        {
            string[] parts = rawProgramData.Split(new string[] { " (", ")" }, StringSplitOptions.RemoveEmptyEntries );
            ProgramData program = new ProgramData();
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

        private static void ParseProgramLinks(ProgramData program, List<ProgramData> programs)
        {
            if (program.RawCarriedProgramNames == "")
            {
                return;
            }
            string[] otherProgramNames = program.RawCarriedProgramNames.Split(new string[] { ", " }, StringSplitOptions.None);
            foreach (string programName in otherProgramNames)
            {
                ProgramData linkedProgram = programs.Find(o => o.Name == programName);
                if (linkedProgram != null)
                {
                    program.AddCarriedProgram(linkedProgram);
                }
            }
        }
    }
}
