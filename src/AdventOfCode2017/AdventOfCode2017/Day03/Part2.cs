using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Day03
{
    public class Part2
    {
        private enum Direction
        {
            Right,
            Up,
            Left,
            Down
        }

        private static int mTargetNr = 361527;
        private static int[,] mGrid = new int[20, 20];

        public static void Run()
        {
            PrimeGrid(mGrid, 20, 20, -1);
            int result = FindFirstLargerValue(mTargetNr);
            Console.WriteLine("The first larger value written is: " + result);
            Console.ReadKey();
        }

        private static void PrimeGrid(int[,] grid, int xLength, int yLength, int primer)
        {
            for (int i = 0; i < xLength; i++)
            {
                for (int j = 0; j < yLength; j++)
                {
                    grid[i, j] = primer;
                }
            }
        }

        private static int FindFirstLargerValue(int targetNr)
        {
            mGrid[10, 10] = 1;
            int result = CalculateCurrentCell(Direction.Up, 11, 10);
            return result;
        }

        private static int CalculateCurrentCell(
            Direction currentDirection,
            int xPos,
            int yPos)
        {
            // calculate value of current cell
            int calculatedCellValue = 0;

            // Top left
            calculatedCellValue += IgnoreMinusOne(mGrid[xPos - 1, yPos - 1]);
            // Top
            calculatedCellValue += IgnoreMinusOne(mGrid[xPos, yPos - 1]);
            // Top right
            calculatedCellValue += IgnoreMinusOne(mGrid[xPos + 1, yPos - 1]);
            // Right
            calculatedCellValue += IgnoreMinusOne(mGrid[xPos + 1, yPos]);
            // Low right
            calculatedCellValue += IgnoreMinusOne(mGrid[xPos + 1, yPos + 1]);
            // Low
            calculatedCellValue += IgnoreMinusOne(mGrid[xPos, yPos + 1]);
            // Low left
            calculatedCellValue += IgnoreMinusOne(mGrid[xPos - 1, yPos + 1]);
            // Left
            calculatedCellValue += IgnoreMinusOne(mGrid[xPos - 1, yPos]);

            // special case: first-cell does only have -1 cells around it
            calculatedCellValue = calculatedCellValue == 0 ? 1 : calculatedCellValue;

            mGrid[xPos, yPos] = calculatedCellValue;

            // base case
            if (mGrid[xPos, yPos] > mTargetNr)
            {
                return mGrid[xPos, yPos];
            }

            // recursive case
            return MoveToNextCell(currentDirection, xPos, yPos);
        }

        private static int IgnoreMinusOne(int value)
        {
            return value == -1 ? 0 : value;
        }

        private static int MoveToNextCell(Direction currentDirection, int xPos, int yPos)
        {
            switch (currentDirection)
            {
                case Direction.Right:
                    if (mGrid[xPos, yPos - 1] == -1)
                    {
                        // We have reached the corner, change direction
                        currentDirection = Direction.Up;
                        return CalculateCurrentCell(currentDirection, xPos, yPos - 1);
                    }
                    // Continue left
                    return CalculateCurrentCell(currentDirection, xPos + 1, yPos);
                case Direction.Up:
                    if (mGrid[xPos - 1, yPos] == -1)
                    {
                        // We have reached the corner, change direction
                        currentDirection = Direction.Left;
                        return CalculateCurrentCell(currentDirection, xPos - 1, yPos);
                    }
                    // Continue upwards
                    return CalculateCurrentCell(currentDirection, xPos, yPos - 1);
                case Direction.Left:
                    if (mGrid[xPos, yPos + 1] == -1)
                    {
                        // We have reached the corner, change direction
                        currentDirection = Direction.Down;
                        return CalculateCurrentCell(currentDirection, xPos, yPos + 1);
                    }
                    // Continue left
                    return CalculateCurrentCell(currentDirection, xPos - 1, yPos);
                case Direction.Down:
                    if (mGrid[xPos + 1, yPos] == -1)
                    {
                        // We have reached the corner, change direction
                        currentDirection = Direction.Right;
                        return CalculateCurrentCell(currentDirection, xPos + 1, yPos);
                    }
                    // Continue left
                    return CalculateCurrentCell(currentDirection, xPos, yPos + 1);
                default:
                    return -1;
            }
        }
    }
}
