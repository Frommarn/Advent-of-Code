using System;

namespace AdventOfCode2017.Day08
{
    /// <summary>
    /// A representation of a register instruction
    /// </summary>
    internal class RegisterInstruction
    {
        /// <summary>
        /// Create a new instance of <see cref="RegisterInstruction"/>
        /// </summary>
        /// <param name="register"></param>
        /// <param name="incDec"></param>
        /// <param name="valueToIncDec"></param>
        /// <param name="condition"></param>
        public RegisterInstruction(Register register, int incDec, int valueToIncDec, Condition condition)
        {
            Register = register ?? throw new ArgumentNullException(nameof(register));
            IncDec = incDec;
            ValueToIncDec = valueToIncDec;
            Condition = condition ?? throw new ArgumentNullException(nameof(condition));
        }

        /// <summary>
        /// Name of the register
        /// </summary>
        public Register Register { get; }
        /// <summary>
        /// 1 for Increment, -1 for Decrement
        /// </summary>
        public int IncDec { get; }
        /// <summary>
        /// Value to add/subtract if the condition is true
        /// </summary>
        public int ValueToIncDec { get; }
        /// <summary>
        /// The condition for the register instruction
        /// </summary>
        public Condition Condition { get; }
    }
}