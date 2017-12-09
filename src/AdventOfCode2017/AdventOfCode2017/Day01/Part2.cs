using System;
using System.Collections.Generic;

namespace AdventOfCode2017.Day01
{
    public static class Part2
    {
        public static void Run()
        {
            List<short> input = RawInput.ParseInput(RawInput.mInput);
            int result2 = CalculateHalfwayCaptcha(input);
            Console.WriteLine("The halfway Captcha is: " + result2);
            Utils.ExitKey.ExitAppIfEsc();
        }

        /// <summary>
        /// Calculates the halfway captcha.
        /// If the current int is the same as the int halfway around the
        /// circular list, add it to the sum. The list is circular.
        /// </summary>
        /// <param name="input">The m input.</param>
        /// <returns></returns>
        private static int CalculateHalfwayCaptcha(List<short> input)
        {
            int sum = 0;

            // Check first half circle if there are any matches
            for (int i = 0; i < input.Count / 2; i++)
            {
                if (input[i] == input[i + (input.Count / 2)])
                {
                    sum += input[i];
                }
            }

            // As the same matches will be done from the other
            // half circle, just double the sum.
            return sum * 2;
        }
    }
}
