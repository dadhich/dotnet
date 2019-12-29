using System;

namespace CSDrawingProgram
{
    public class DrawingCanvas
    {
        public static char HorizontalDrawingCharacter = '-';
        public static char VerticalDrawingCharacter = '|';

        public char[,] DrawingCanvasMatrix;

        public DrawingCanvas(int width, int height)
        {
            DrawingCanvasMatrix = new char[height + 2, width + 2];

            InitializeDrawingCanvasMatrix();
        }

        private void InitializeDrawingCanvasMatrix()
        {
            // top and bottom row
            for (int i = 0; i <= DrawingCanvasMatrix.GetUpperBound(1); i++)
                DrawingCanvasMatrix[0, i] = DrawingCanvasMatrix[DrawingCanvasMatrix.GetUpperBound(0), i]  = HorizontalDrawingCharacter;

            // left and right column
            for (int i = 1; i < DrawingCanvasMatrix.GetUpperBound(0); i++)
                DrawingCanvasMatrix[i, 0] = DrawingCanvasMatrix[i, DrawingCanvasMatrix.GetUpperBound(1)] = VerticalDrawingCharacter;
        }

        public void DrawMe()
        {
            for (int i = 0; i <= DrawingCanvasMatrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= DrawingCanvasMatrix.GetUpperBound(1); j++)
                {
                    Console.Write(DrawingCanvasMatrix[i, j]);
                }
                Console.Write("\n");
            }
        }
    }
}
