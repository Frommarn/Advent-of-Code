using System;

namespace AdventOfCode2017.Day03
{
    public class Part1
    {
        private enum Corner
        {
            UpperRight,
            UpperLeft,
            LowerLeft,
            LowerRight
        }

        private static int mTargetNr = 361527;

        public static void Run()
        {
            foreach (int targetNr in new int[] { 1, 12, 23, 1024, mTargetNr })
            {
                int nrOfSteps = CalculateSteps(targetNr);
                Console.WriteLine("NrOfSteps for " + targetNr + " is " + nrOfSteps);
            }
            Console.ReadKey();
        }

        private static int CalculateSteps(int targetNr)
        {
            int stepSize = 0;
            int currentCornerNr = 1;
            Corner currentEdge;

            while (true)
            {
                // increase step size
                stepSize++;

                // step right
                currentEdge = Corner.LowerRight;
                currentCornerNr += stepSize;
                if (currentCornerNr >= targetNr)
                {
                    break;
                }

                // step up
                currentEdge = Corner.UpperRight;
                currentCornerNr += stepSize;
                if (currentCornerNr >= targetNr)
                {
                    break;
                }

                // increase step size
                stepSize++;

                // step left
                currentEdge = Corner.UpperLeft;
                currentCornerNr += stepSize;
                if (currentCornerNr >= targetNr)
                {
                    break;
                }

                // step down
                currentEdge = Corner.LowerLeft;
                currentCornerNr += stepSize;
                if (currentCornerNr >= targetNr)
                {
                    break;
                }
            }

            // stepSize is the length of the outermost edge our target
            // number is on.

            // Manhattan distance from corner
            int distanceFromCurrentCorner;
            switch (currentEdge)
            {
                case Corner.UpperRight:
                    distanceFromCurrentCorner = ((stepSize + 1) / 2) * 2;
                    break;
                case Corner.UpperLeft:
                    distanceFromCurrentCorner = (stepSize / 2) * 2;
                    break;
                case Corner.LowerLeft:
                    distanceFromCurrentCorner = (stepSize / 2) * 2;
                    break;
                case Corner.LowerRight:
                    distanceFromCurrentCorner = ((stepSize - 1) / 2) * 2 + 1;
                    break;
                default:
                    distanceFromCurrentCorner = 0;
                    break;
            }

            // find how long from the currentCorner our targetNr is
            int distanceFromCorner = currentCornerNr - targetNr;

            // subtract from cornerToCenter distance
            int actualDistance = distanceFromCurrentCorner - distanceFromCorner;

            return actualDistance;
        }
    }
}
