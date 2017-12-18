using System;

namespace AdventOfCode2017.Day08
{
    /// <summary>
    /// A representation of a register
    /// </summary>
    internal class Register
    {
        /// <summary>
        /// Create a new instrance of <see cref="Register"/>
        /// </summary>
        /// <param name="name"></param>
        public Register(string name)
        {
            Name = name; // ?? throw new ArgumentNullException(nameof(name));
            Value = 0;
        }

        /// <summary>
        /// Name of the register
        /// </summary>
        internal string Name { get; } // Can only be set in the constructor
        internal int Value { get; private set; }

        /// <summary>
        /// Modify the Register value by <paramref name="value"/>
        /// </summary>
        /// <param name="value"></param>
        internal void ModifyValueBy(int value)
        {
            Value += value;
        }
    }
}