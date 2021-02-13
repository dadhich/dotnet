using System;

public class RoutePlanner
{
    public static bool RouteExists(int fromRow, int fromColumn, int toRow, int toColumn,
                                      bool[,] mapMatrix)
    {
        //bool routeExists = true;
        int currentX = fromRow;
        int currentY = fromColumn;
        int allowedIterations = mapMatrix.Length, iterationCount = 0;

        Console.WriteLine("Initial Information:\n fromRow: {0}\t fromColum: {1}\n toRow: {2}\t toColumn: {3}\n  mapMatrix[fromRow, fromColumn]: {4}\n mapMatrix[toRow, toColumn]: {5}",
                fromRow, fromColumn, toRow, toColumn, mapMatrix[fromRow, fromColumn], mapMatrix[toRow, toColumn]);

        if (!mapMatrix[fromRow, fromColumn] || !mapMatrix[toRow, toColumn])
            return false;

        while(iterationCount < allowedIterations)
        {
            // go vertically towards the target as much as possible
            currentX = MoveVertically(toRow, mapMatrix, currentX, currentY, iterationCount);

            // go horizontally towards the target as much as possible
            currentY = MoveHorizontally(toColumn, mapMatrix, currentX, currentY, iterationCount);

            if (currentX == toRow && currentY == toColumn)
                break;

            iterationCount++;
        }
        
        return (mapMatrix[currentX, currentY]);

    }

    private static int MoveHorizontally(int toColumn, bool[,] mapMatrix, int currentX, int currentY, int iterationCount)
    {
        //while (true)
        //{
            // when target is to the right
            if (toColumn > currentY && mapMatrix[currentX, currentY + 1])
                currentY++;
            //else
            //    break;

            // when target is to the left
            if (toColumn < currentY && mapMatrix[currentX, currentY - 1])
                currentY--;
            //else
            //    break;
        //}

        Console.WriteLine("Iteration#: {0}\t Current X: {1}\t Current Y: {2}", iterationCount, currentX, currentY);
        return currentY;
    }

    private static int MoveVertically(int toRow, bool[,] mapMatrix, int currentX, int currentY, int iterationCount)
    {
        //while (true)
        //{
            // if target point is below the current point then keep going down as much as possible
            if (toRow > currentX && mapMatrix[currentX + 1, currentY])
                currentX++;
            //else
            //    break;

            // if target point is above the current point then keep going up as much as possible
            if (toRow < currentX && mapMatrix[currentX - 1, currentY])
                currentX--;
        //    else
        //        break;
        //}

        Console.WriteLine("Iteration#: {0}\t Current X: {1}\t Current Y: {2}", iterationCount, currentX, currentY);

        return currentX;
    }

    public static void Main(string[] args)
    {
        bool[,] mapMatrix = {
            {false, false, true, true},
            {false, true, true, false},
            {false, true, false, false},
            {true, true, true, true},
            {true, false, false, true},
            {false, true, true, true}
        };

        Console.WriteLine(RouteExists(0, 2, 5, 1, mapMatrix));
    }
}