package com.dadhichabhishek;

public class DrawingCanvas {
    public static char HorizontalDrawingCharacter = '-';
    public static char VerticalDrawingCharacter = '|';

    public char[][] DrawingCanvasMatrix;

    public DrawingCanvas(int width, int height) {
        DrawingCanvasMatrix = new char[height + 2][width + 2];

        InitializeDrawingCanvasMatrix();
    }

    private void InitializeDrawingCanvasMatrix() {
        // top and bottom row
        for (int i = 0; i <= DrawingCanvasMatrix[0].length - 1; i++) {
            DrawingCanvasMatrix[0][i] = DrawingCanvasMatrix[DrawingCanvasMatrix.length - 1][i] = HorizontalDrawingCharacter;
        }

        // left and right column
        for (int i = 1; i < DrawingCanvasMatrix.length - 1; i++) {
            DrawingCanvasMatrix[i][0] = DrawingCanvasMatrix[i][DrawingCanvasMatrix[0].length - 1] = VerticalDrawingCharacter;
        }
    }

    public final void DrawMe() {
        for (int i = 0; i <= DrawingCanvasMatrix.length - 1; i++) {
            for (int j = 0; j <= DrawingCanvasMatrix[0].length - 1; j++) {
                System.out.print(DrawingCanvasMatrix[i][j]);
            }
            System.out.print("\n");
        }
    }
}
