using System;
using System.Collections.Generic;

namespace CSDrawingProgram
{
    class Program
    {
        private static DrawingCanvas _drawingCanvas;

        static void Main()
        {
            DoWork();
        }

        private static void DoWork()
        {
            while (true)
            {
                // take input from keyboard
                string command = TakeInput();

                // validate input and get relevant object created from factory
                if (ValidateAndFillCanvasMatrix(command))
                {
                    if (_drawingCanvas != null)
                    {
                        _drawingCanvas.DrawMe();
                    }
                    else
                    {
                        DrawingHelper.PrintError("Canvas not defined yet. Define Canvas using command 'C width height' and then issue commands to draw shapes.");
                    }
                }
                else
                {
                    DrawingHelper.PrintError();
                }
            }
        }

        private static bool ValidateAndFillCanvasMatrix(string command)
        {
            string[] commandParts = command.Split();

            if (commandParts.Length <= 0)
            {
                DrawingHelper.PrintError();
                return false;
            }

            switch (commandParts[0])
            {
                case "C":
                    return FillCanvasMatrix(commandParts);
                case "L":
                    return FillLineInCanvasMatrix(commandParts);
                case "R":
                    return FillRectangleInCanvasMatrix(commandParts);
                case "B":
                    return FillBucketFillInCanvasMatrix(commandParts);
                case "Q":
                    Environment.Exit(0);
                    break;
            }

            // to keep compiler happy
            return false;
        }

        private static bool FillCanvasMatrix(string[] input)
        {
            // validate number of params
            if (input == null || input.Length != 3)
                return false;

            int width;
            if (!int.TryParse(input[1], out width))
                return false;

            int height;
            if (!int.TryParse(input[2], out height))
                return false;

            _drawingCanvas = new DrawingCanvas(width, height);
            
            return true;
        }

        private static bool FillLineInCanvasMatrix(string[] input)
        {
            // validate number of params
            if (input == null || input.Length != 5)
                return false;

            int x1;
            if (!int.TryParse(input[1], out x1))
                return false;

            int y1;
            if (!int.TryParse(input[2], out y1))
                return false;

            int x2;
            if (!int.TryParse(input[3], out x2))
                return false;

            int y2;
            if (!int.TryParse(input[4], out y2))
                return false;

            return DrawingHelper.DrawLine(_drawingCanvas, new PointCoordinate(x1, y1), new PointCoordinate(x2, y2), 'x');
        }

        private static bool FillRectangleInCanvasMatrix(string[] input)
        {
            // validate number of params
            if (input == null || input.Length != 5)
                return false;

            int x1;
            if (!int.TryParse(input[1], out x1))
                return false;

            int y1;
            if (!int.TryParse(input[2], out y1))
                return false;

            int x2;
            if (!int.TryParse(input[3], out x2))
                return false;

            int y2;
            if (!int.TryParse(input[4], out y2))
                return false;

            return DrawingHelper.DrawRectangle(_drawingCanvas, new PointCoordinate(x1, y1), new PointCoordinate(x2, y2), 'x');
        }

        private static bool FillBucketFillInCanvasMatrix(string[] input)
        {
            // validate number of params
            if (input == null || input.Length != 4)
                return false;

            int x1;
            if (!int.TryParse(input[1], out x1))
                return false;

            int y1;
            if (!int.TryParse(input[2], out y1))
                return false;

            char drawingChar;
            if (!char.TryParse(input[3], out drawingChar))
                return false;

            DrawingHelper.DrawBucketFill(_drawingCanvas, new PointCoordinate(x1, y1), drawingChar);

            return true;
        }

        private static string TakeInput()
        {
            while (true)
            {
                Console.Write("\nEnter Command: ");
                string command = Console.ReadLine()?.Trim().ToUpper();
                if (command?.Length > 0)
                    return command;

                DrawingHelper.PrintError();
            }
        }

        
    }
}
