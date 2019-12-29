using System;

namespace CSDrawingProgram
{
    public class DrawingHelper
    {
        public static bool DrawLine(DrawingCanvas canvas, PointCoordinate startCoordinates, PointCoordinate endCoordinates, char drawingChar)
        {
            // check if the canvas is initialized
            if (!IsValidCanvas(canvas))
                return false;

            // check if only vertical/horizontal lines are demanded to be drawn
            if ((endCoordinates.Y - startCoordinates.Y) != 0 && (endCoordinates.X - startCoordinates.X) != 0)
            {
                PrintError("Only Horizontal or Vertical lines are supported in this version.");
                return false;
            }

            // Is it a vetical line?
            if (startCoordinates.X - endCoordinates.X == 0)
                return DrawVerticalLine(canvas, startCoordinates, endCoordinates, drawingChar);

            // Or is it horizontal line?
            if (startCoordinates.Y - endCoordinates.Y == 0)
                return DrawHorizontalLine(canvas, startCoordinates, endCoordinates, drawingChar);

            return false;
        }

        public static bool DrawRectangle(DrawingCanvas canvas, PointCoordinate topLeftCoordinates, PointCoordinate bottomRightCoordinates, char drawingChar)
        {
            // check if the canvas is initialized
            if (!IsValidCanvas(canvas))
                return false;

            // derive bottom left coordinate
            PointCoordinate bottomLeftCoordinate = new PointCoordinate(topLeftCoordinates.X, bottomRightCoordinates.Y);

            // derive top right coordinate
            PointCoordinate topRightCoordinate = new PointCoordinate(bottomRightCoordinates.X, topLeftCoordinates.Y);

            // draw top horizontal line
            if (!DrawHorizontalLine(canvas, topLeftCoordinates, topRightCoordinate, drawingChar))
                return false;

            // draw bottom horizontal line
            if (!DrawHorizontalLine(canvas, bottomLeftCoordinate, bottomRightCoordinates, drawingChar))
                return false;

            // draw left vertical line
            if (!DrawVerticalLine(canvas, topLeftCoordinates, bottomLeftCoordinate, drawingChar))
                return false;

            // draw right vertical line
            if (!DrawVerticalLine(canvas, topRightCoordinate, bottomRightCoordinates, drawingChar))
                return false;

            return true;
        }

        private static bool IsValidCanvas(DrawingCanvas canvas)
        {
            if (canvas == null || (canvas.DrawingCanvasMatrix.GetUpperBound(0) <= 0 && canvas.DrawingCanvasMatrix.GetUpperBound(1) <= 0))
            {
                PrintError("Canvas not defined yet. Define Canvas using command 'C width height' and then issue commands to draw shapes.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Draws horizontal line from start point to end point using the supplied character
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="startPointCoordinate"></param>
        /// <param name="endPointCoordinate"></param>
        /// <param name="drawingCharacter"></param>
        private static bool DrawHorizontalLine(DrawingCanvas canvas, PointCoordinate startPointCoordinate, PointCoordinate endPointCoordinate, char drawingCharacter)
        {
            try
            {
                int length = endPointCoordinate.X - startPointCoordinate.X;

                for (int i = 0; i <= length; i++)
                {
                    canvas.DrawingCanvasMatrix[startPointCoordinate.Y, startPointCoordinate.X + i] = drawingCharacter;
                }

                return true;
            }
            catch (Exception ex)
            {
                PrintError("Unexpected Exception: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Draws vertical line from start point to end point using the supplied character
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="startPointCoordinate"></param>
        /// <param name="endPointCoordinate"></param>
        /// <param name="drawingCharacter"></param>
        private static bool DrawVerticalLine(DrawingCanvas canvas, PointCoordinate startPointCoordinate, PointCoordinate endPointCoordinate, char drawingCharacter)
        {
            try
            {
                int height = endPointCoordinate.Y - startPointCoordinate.Y;

                for (int i = 0; i <= height; i++)
                {
                    canvas.DrawingCanvasMatrix[startPointCoordinate.Y + i, startPointCoordinate.X] = drawingCharacter;
                }

                return true;
            }
            catch (Exception ex)
            {
                PrintError("Unexpected Exception: " + ex.Message);
                return false;
            }
        }

        public static void DrawBucketFill(DrawingCanvas canvas, PointCoordinate startPointCoordinate, char drawingCharacter)
        {
            int x = startPointCoordinate.X;
            int y = startPointCoordinate.Y;

            // return if selected point is not blank
            if ((int)canvas.DrawingCanvasMatrix[y, x] != 0)
            {
                return;
            }

            // selected point should be within the bounds of canvas
            if (x > 0 || x < canvas.DrawingCanvasMatrix.GetUpperBound(0) || y > 0 || y < canvas.DrawingCanvasMatrix.GetUpperBound(1))
            {

                // draw character only if that place is blank
                if ((int)canvas.DrawingCanvasMatrix[y, x] == 0)
                    canvas.DrawingCanvasMatrix[y, x] = drawingCharacter;

                // call for next row
                DrawBucketFill(canvas, new PointCoordinate(x + 1, y), drawingCharacter);

                // call for previous row
                DrawBucketFill(canvas, new PointCoordinate(x - 1, y), drawingCharacter);

                // call for next column
                DrawBucketFill(canvas, new PointCoordinate(x, y - 1), drawingCharacter);

                // call for previous column
                DrawBucketFill(canvas, new PointCoordinate(x, y + 1), drawingCharacter);
            }
        }

        public static void PrintError(string message = "Invalid Input. Please try again...")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}