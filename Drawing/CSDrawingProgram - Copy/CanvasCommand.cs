using System;

namespace CSDrawingProgram
{
    public class CanvasCommand : IDrawingObjectCommand
    {
        private readonly DrawingHelper _drawingHelper;
        private readonly char _horizontalDrawingChar;
        private readonly char _verticalDrawingChar;
        private const int _offset = 1;
        private static char _defaultHorizontalDrawingCharacter = '-';
        private static char _defaultVerticalDrawingCharacter = '|';

        public char[,] DrawingCanvas;

        public int Width { get; set; }
        public int Height { get; set; }

        public CanvasCommand(int width, int height, char horizontalDrawingChar, char verticalDrawingChar, DrawingHelper drawingHelper)
        {
            Width = width;
            Height = height;
            _horizontalDrawingChar = horizontalDrawingChar;
            _verticalDrawingChar = verticalDrawingChar;
            _drawingHelper = drawingHelper;
        }

        //public void DrawMe()
        //{
        //    PointCoordinate startPointVerticalLeft = new PointCoordinate (0, _offset);
        //    PointCoordinate endPointVerticalLeft = new PointCoordinate (0, Height);
            
        //    PointCoordinate startPointVerticalRight = new PointCoordinate (Width + _offset, _offset);
        //    PointCoordinate endPointVerticalRight = new PointCoordinate(Width + _offset, Height);

        //    PointCoordinate startPointHorizontalTop = new PointCoordinate(0, 0);
        //    PointCoordinate endPointHorizontalTop = new PointCoordinate(Width + _offset, 0);

        //    PointCoordinate startPointHorizontalBottom = new PointCoordinate(0, Height + _offset);
        //    PointCoordinate endPointHorizontalBottom = new PointCoordinate(Width + _offset, Height + _offset);

        //    // draw top horizontal line
        //    _drawingHelper.DrawHorizontalLine(startPointHorizontalTop, endPointHorizontalTop, _horizontalDrawingChar);

        //    // draw bottom horizontal line
        //    _drawingHelper.DrawHorizontalLine(startPointHorizontalBottom, endPointHorizontalBottom, _horizontalDrawingChar);

        //    // draw left vertical line
        //    _drawingHelper.DrawVerticalLine(startPointVerticalLeft, endPointVerticalLeft, _verticalDrawingChar);

        //    // draw right vertical line
        //    _drawingHelper.DrawVerticalLine(startPointVerticalRight, endPointVerticalRight, _verticalDrawingChar);
        //}

        public void DrawMe()
        {
            for (int j = 0; j < DrawingCanvas.GetUpperBound(1); j++)
            {
                for (int i = 0; i < DrawingCanvas.GetUpperBound(0); i++)
                {
                    Console.Write(DrawingCanvas[i, j]);
                }

                Console.Write("\n");
            }
        }

        IDrawingObjectCommand IDrawingObjectCommand.ValidateInputReturnObject(string[] input)
        {
            return ValidateInputReturnObject(input);
        }

        public static IDrawingObjectCommand ValidateInputReturnObject(string[] input)
        {
            // validate number of params
            if (input == null || input.Length != 3)
                return null;

            int width;
            if (!int.TryParse(input[1], out width))
                return null;

            int height;
            if (!int.TryParse(input[2], out height))
                return null;

            return new CanvasCommand(width, height, _defaultHorizontalDrawingCharacter, _defaultVerticalDrawingCharacter, new DrawingHelper());
        }
    }
}
