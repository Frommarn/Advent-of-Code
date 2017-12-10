using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Day08
{
    public static class Part2
    {
        private static int mHighestValueDuringExecution = int.MinValue;

        public static void Run()
        {
            //string[] data = Utils.RawInputParser.ReadRawInputFromFile("08", "testInput.txt");
            string[] data = Utils.RawInputParser.ReadRawInputFromFile("08", "rawInput.txt");
            ExecuteRegisterInstructions(data);
            Console.WriteLine("The largest value in the registers during execution is: " + mHighestValueDuringExecution);
            Utils.ExitKey.ExitAppIfEsc();
        }

        private static void ExecuteRegisterInstructions(string[] data)
        {
            // Create the registers
            List<Register> registers = new List<Register>();
            foreach (string rawRegisterInstruction in data)
            {
                string registerName = rawRegisterInstruction.Split(' ')[0];
                if (registers.Any(o => o.Name == registerName) == false)
                {
                    registers.Add(new Register(registerName));
                }
            }

            // Create the register instructions
            List<RegisterInstruction> registerInstructions = new List<RegisterInstruction>();
            foreach (string rawRegisterInstruction in data)
            {
                registerInstructions.Add(ParseRegisterInstruction(rawRegisterInstruction, ref registers));
            }

            // Execute the register instructions
            foreach (RegisterInstruction instruction in registerInstructions)
            {
                ExecuteRegisterInstruction(instruction);
            }
        }

        private static void ExecuteRegisterInstruction(RegisterInstruction instruction)
        {
            Condition condition = instruction.Condition;
            bool isConditionFulfilled;

            // Evaluate the condition
            switch (condition.If)
            {
                case ConditionType.GreaterThan:
                    isConditionFulfilled = condition.OtherRegister.Value > condition.Value ? true : false;
                    break;
                case ConditionType.LesserThan:
                    isConditionFulfilled = condition.OtherRegister.Value < condition.Value ? true : false;
                    break;
                case ConditionType.Equal:
                    isConditionFulfilled = condition.OtherRegister.Value == condition.Value ? true : false;
                    break;
                case ConditionType.NotEqual:
                    isConditionFulfilled = condition.OtherRegister.Value != condition.Value ? true : false;
                    break;
                case ConditionType.GreaterOrEqual:
                    isConditionFulfilled = condition.OtherRegister.Value >= condition.Value ? true : false;
                    break;
                case ConditionType.LesserOrEqual:
                    isConditionFulfilled = condition.OtherRegister.Value <= condition.Value ? true : false;
                    break;
                default:
                    isConditionFulfilled = false;
                    break;
            }

            // If condition is fulfilled, update the register
            if (isConditionFulfilled)
            {
                instruction.Register.ModifyValueBy(instruction.IncDec * instruction.ValueToIncDec);
            }
            else
            {
                // Do nothing
            }

            if (mHighestValueDuringExecution < instruction.Register.Value)
            {
                mHighestValueDuringExecution = instruction.Register.Value;
            }
        }

        private static RegisterInstruction ParseRegisterInstruction(string rawRegisterInstruction, ref List<Register> registers)
        {
            // Format: [RegName] [IncDec] [IncDecValue] if Condition:([RegName] [Comparer] [Value])   Example: b inc 5 if a > 1
            string[] instructionParts = rawRegisterInstruction.Split(' ');
            Register register = registers.Find(o => o.Name == instructionParts[0]);
            int incDec = instructionParts[1] == "inc" ? 1 : -1;
            int valueToIncDec = int.Parse(instructionParts[2]);
            Register otherRegister = registers.Find(o => o.Name == instructionParts[4]);
            Condition condition = new Condition(otherRegister, ParseConditionType(instructionParts[5]), int.Parse(instructionParts[6]));
            return new RegisterInstruction(register, incDec, valueToIncDec, condition);
        }

        private static ConditionType ParseConditionType(string conditionTypeAsString)
        {
            if (conditionTypeAsString == ">") { return ConditionType.GreaterThan; }
            else if (conditionTypeAsString == "<") { return ConditionType.LesserThan; }
            else if (conditionTypeAsString == "==") { return ConditionType.Equal; }
            else if (conditionTypeAsString == "!=") { return ConditionType.NotEqual; }
            else if (conditionTypeAsString == ">=") { return ConditionType.GreaterOrEqual; }
            else if (conditionTypeAsString == "<=") { return ConditionType.LesserOrEqual; }
            else { throw new ArgumentOutOfRangeException(nameof(conditionTypeAsString), "Raw condition not recognised! " + conditionTypeAsString); }
        }
    }
}
