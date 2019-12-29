using System;

namespace CSDrawingProgram
{
    public class RectangleCommand : IDrawingObjectCommand
    {
        private readonly DrawingHelper _drawingHelper;
        private static char _defaultDrawingCharacter = 'x';

        public PointCoordinate TopLeftCoordinate { get; set; }
        public PointCoordinate BottomRightCoordinate { get; set; }

        public char DrawingCharacter { get; set; }

        public RectangleCommand(PointCoordinate topLeftCoordinate, PointCoordinate bottomRightCoordinate, char drawingCharacter, DrawingHelper drawingHelper)
        {
            TopLeftCoordinate = topLeftCoordinate;
            BottomRightCoordinate = bottomRightCoordinate;
            DrawingCharacter = drawingCharacter;
            _drawingHelper = drawingHelper;
        }

        public void DrawMe()
        {
            Console.SetCursorPosition(TopLeftCoordinate.X, TopLeftCoordinate.Y);

            // derive bottom left coordinate
            PointCoordinate bottomLeftCoordinate = new PointCoordinate(TopLeftCoordinate.X, BottomRightCoordinate.Y);

            // derive top right coordinate
            PointCoordinate topRightCoordinate = new PointCoordinate(BottomRightCoordinate.X, TopLeftCoordinate.Y);

            // draw top horizontal line
            _drawingHelper.DrawHorizontalLine(TopLeftCoordinate, topRightCoordinate, DrawingCharacter);

            // draw bottom horizontal line
            _drawingHelper.DrawHorizontalLine(bottomLeftCoordinate, BottomRightCoordinate, DrawingCharacter);

            // draw left vertical line
            _drawingHelper.DrawVerticalLine(TopLeftCoordinate, bottomLeftCoordinate, DrawingCharacter);

            // draw right vertical line
            _drawingHelper.DrawVerticalLine(topRightCoordinate, BottomRightCoordinate, DrawingCharacter);
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

            return new RectangleCommand(new PointCoordinate(x1, y1), new PointCoordinate(x2, y2), _defaultDrawingCharacter, new DrawingHelper());
        }
    }
}