using System;

namespace CSDrawingProgram
{
    public class LineCommand : IDrawingObjectCommand
    {
        private readonly DrawingHelper _drawingHelper;
        private static char _defaultDrawingCharacter = 'x';

        public PointCoordinate StartCoordinate { get; set; }
        public PointCoordinate EndCoordinate { get; set; }
        public char DrawingCharacter { get; set; }

        public LineCommand(PointCoordinate startCoordinate, PointCoordinate endCoordinate, char drawingCharacter, DrawingHelper drawingHelper)
        {
            StartCoordinate = startCoordinate;
            EndCoordinate = endCoordinate;
            DrawingCharacter = drawingCharacter;
            _drawingHelper = drawingHelper;
        }

        public void DrawMe()
        {
            if ((EndCoordinate.Y - StartCoordinate.Y) != 0 && (EndCoordinate.X - StartCoordinate.X) != 0)
            {
                Console.SetCursorPosition(Console.WindowHeight - 1, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Only Horizontal or Vertical lines are supported in this version.");
                Console.ResetColor();
                return;
            }

            Console.SetCursorPosition(StartCoordinate.X, StartCoordinate.Y);

            if (StartCoordinate.X - EndCoordinate.X == 0)
            {
                _drawingHelper.DrawVerticalLine(StartCoordinate, EndCoordinate, DrawingCharacter);
            }
            else if (StartCoordinate.Y - EndCoordinate.Y == 0)
            {
                _drawingHelper.DrawHorizontalLine(StartCoordinate, EndCoordinate, DrawingCharacter);
            }
        }

        IDrawingObjectCommand IDrawingObjectCommand.ValidateInputReturnObject(string[] input)
        {
            return ValidateInputReturnObject(input);
        }

        public static IDrawingObjectCommand ValidateInputReturnObject(string[] input)
        {
            // validate number of params
            if (input == null || input.Length != 5)
                return null;

            int x1;
            if (!int.TryParse(input[1], out x1))
                return null;

            int y1;
            if (!int.TryParse(input[2], out y1))
                return null;

            int x2;
            if (!int.TryParse(input[3], out x2))
                return null;

            int y2;
            if (!int.TryParse(input[4], out y2))
                return null;

            return new LineCommand(new PointCoordinate(x1, y1), new PointCoordinate(x2, y2), _defaultDrawingCharacter, new DrawingHelper());
        }
    }
}
