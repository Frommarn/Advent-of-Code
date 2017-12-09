using System.Collections.Generic;

namespace AdventOfCode2017.Day07
{
    public class ProgramData
    {
        private List<ProgramData> mCarriedProgramNames;

        public ProgramData()
        {
            Name = "";
            Weight = -1;
            RawCarriedProgramNames = "";
            mCarriedProgramNames = new List<ProgramData>();
            IsCarried = false;
            IsCarryingOthers = false;
        }

        public string Name { get; set; }
        public int Weight { get; set; }
        public string RawCarriedProgramNames { get; set; }
        public bool IsCarried { get; set; }
        public bool IsCarryingOthers { get; set; }

        public void AddCarriedProgram(ProgramData carriedProgram)
        {
            mCarriedProgramNames.Add(carriedProgram);
            carriedProgram.IsCarried = true;
            this.IsCarryingOthers = true;
        }
    }
}
