using System;

namespace AdventOfCode2017.Day08
{
    /// <summary>
    /// A representation of a register instructions condition
    /// </summary>
    internal class Condition
    {
        /// <summary>
        /// Creates a new instance of <see cref="Condition"/>
        /// </summary>
        /// <param name="otherRegister"></param>
        /// <param name="conditionType"></param>
        /// <param name="value"></param>
        public Condition(Register otherRegister, ConditionType conditionType, int value)
        {
            OtherRegister = otherRegister ?? throw new ArgumentNullException(nameof(otherRegister));
            If = conditionType;
            Value = value;
        }

        /// <summary>
        /// Name of the other register whose value is the first part of the condition
        /// </summary>
        internal Register OtherRegister { get; }
        /// <summary>
        /// The condition comparer
        /// </summary>
        internal ConditionType If { get; }
        /// <summary>
        /// The value which is the second part of the condition
        /// </summary>
        internal int Value { get; }
    }
}
