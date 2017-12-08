using System;
using System.Collections.Generic;

namespace AdventOfCode2017.Day01
{
    public class Part1
    {
        public static void Run()
        {
            List<short> input = RawInput.ParseInput(RawInput.mInput);
            int result = CalculateReverseCaptcha(input);
            Console.WriteLine("The inverse Captcha is: " + result);
            Console.ReadKey();
        }

        /// <summary>
        /// Calculates the reverse captcha.
        /// If the current int is the same as the next int in the list,
        /// add it to the sum. The list is circular.
        /// </summary>
        /// <param name="input">The m input.</param>
        /// <returns></returns>
        private static int CalculateReverseCaptcha(List<short> input)
        {

            int sum = 0;
            for (int i = 0; i < input.Count - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    sum += input[i];
                }
            }

            // End edge case
            if (input[input.Count - 1] == input[0])
            {
                sum += input[input.Count - 1];
            }

            return sum;
        }
    }
}
