using System;

namespace CSDrawingProgram
{
    public class DrawingHelper
    {
        /// <summary>
        /// Draws horizontal line from start point to end point using the supplied character
        /// </summary>
        /// <param name="startPointCoordinate"></param>
        /// <param name="endPointCoordinate"></param>
        /// <param name="drawingCharacter"></param>
        public void DrawHorizontalLine(PointCoordinate startPointCoordinate, PointCoordinate endPointCoordinate, char drawingCharacter)
        {
            int length = endPointCoordinate.X - startPointCoordinate.X;

            Console.SetCursorPosition(startPointCoordinate.X, startPointCoordinate.Y);

            for (int i = 0; i <= length; i++)
            {
                Console.Write(drawingCharacter);
            }
        }

        /// <summary>
        /// Draws vertical line from start point to end point using the supplied character
        /// </summary>
        /// <param name="startPointCoordinate"></param>
        /// <param name="endPointCoordinate"></param>
        /// <param name="drawingCharacter"></param>
        public void DrawVerticalLine(PointCoordinate startPointCoordinate, PointCoordinate endPointCoordinate, char drawingCharacter)
        {
            int height = endPointCoordinate.Y - startPointCoordinate.Y;
            int j = 1;

            Console.SetCursorPosition(startPointCoordinate.X, startPointCoordinate.Y);

            for (int i = 0; i <= height; i++)
            {
                Console.Write(drawingCharacter);
                Console.SetCursorPosition(startPointCoordinate.X, startPointCoordinate.Y + j++);
            }
        }

        
    }
}