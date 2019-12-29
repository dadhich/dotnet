package com.dadhichabhishek;

public class DrawingHelper {

    public static final String ANSI_RESET = "\u001B[0m";
    public static final String ANSI_RED = "\u001B[31m";

    public static boolean DrawLine(DrawingCanvas canvas, PointCoordinate startCoordinates, PointCoordinate endCoordinates, char drawingChar) {
        // check if the canvas is initialized
        if (!IsValidCanvas(canvas)) {
            return false;
        }

        // check if only vertical/horizontal lines are demanded to be drawn
        if ((endCoordinates.getY() - startCoordinates.getY()) != 0 && (endCoordinates.getX() - startCoordinates.getX()) != 0) {
            PrintError("Only Horizontal or Vertical lines are supported in this version.");
            return false;
        }

        // Is it a vertical line?
        if (startCoordinates.getX() - endCoordinates.getX() == 0) {
            return DrawVerticalLine(canvas, startCoordinates, endCoordinates, drawingChar);
        }

        // Or is it horizontal line?
        if (startCoordinates.getY() - endCoordinates.getY() == 0) {
            return DrawHorizontalLine(canvas, startCoordinates, endCoordinates, drawingChar);
        }

        return false;
    }

    public static boolean DrawRectangle(DrawingCanvas canvas, PointCoordinate topLeftCoordinates, PointCoordinate bottomRightCoordinates, char drawingChar) {
        // check if the canvas is initialized
        if (!IsValidCanvas(canvas)) {
            return false;
        }

        // derive bottom left coordinate
        PointCoordinate bottomLeftCoordinate = new PointCoordinate(topLeftCoordinates.getX(), bottomRightCoordinates.getY());

        // derive top right coordinate
        PointCoordinate topRightCoordinate = new PointCoordinate(bottomRightCoordinates.getX(), topLeftCoordinates.getY());

        // draw top horizontal line
        if (!DrawHorizontalLine(canvas, topLeftCoordinates, topRightCoordinate, drawingChar)) {
            return false;
        }

        // draw bottom horizontal line
        if (!DrawHorizontalLine(canvas, bottomLeftCoordinate, bottomRightCoordinates, drawingChar)) {
            return false;
        }

        // draw left vertical line
        if (!DrawVerticalLine(canvas, topLeftCoordinates, bottomLeftCoordinate, drawingChar)) {
            return false;
        }

        // draw right vertical line
        if (!DrawVerticalLine(canvas, topRightCoordinate, bottomRightCoordinates, drawingChar)) {
            return false;
        }

        return true;
    }

    private static boolean IsValidCanvas(DrawingCanvas canvas) {
        if (canvas == null || (canvas.DrawingCanvasMatrix.length - 1 <= 0 && canvas.DrawingCanvasMatrix[0].length - 1 <= 0)) {
            PrintError("Canvas not defined yet. Define Canvas using command 'C width height' and then issue commands to draw shapes.");
            return false;
        }
        return true;
    }

    /**
     * Draws horizontal line from start point to end point using the supplied character
     *
     * @param canvas
     * @param startPointCoordinate
     * @param endPointCoordinate
     * @param drawingCharacter
     */
    private static boolean DrawHorizontalLine(DrawingCanvas canvas, PointCoordinate startPointCoordinate, PointCoordinate endPointCoordinate, char drawingCharacter) {
        try {
            int length = endPointCoordinate.getX() - startPointCoordinate.getX();

            for (int i = 0; i <= length; i++) {
                canvas.DrawingCanvasMatrix[startPointCoordinate.getY()][startPointCoordinate.getX() + i] = drawingCharacter;
            }

            return true;
        } catch (RuntimeException ex) {
            PrintError("Unexpected Exception: " + ex.getMessage());
            return false;
        }
    }

    /**
     * Draws vertical line from start point to end point using the supplied character
     *
     * @param canvas
     * @param startPointCoordinate
     * @param endPointCoordinate
     * @param drawingCharacter
     */
    private static boolean DrawVerticalLine(DrawingCanvas canvas, PointCoordinate startPointCoordinate, PointCoordinate endPointCoordinate, char drawingCharacter) {
        try {
            int height = endPointCoordinate.getY() - startPointCoordinate.getY();

            for (int i = 0; i <= height; i++) {
                canvas.DrawingCanvasMatrix[startPointCoordinate.getY() + i][startPointCoordinate.getX()] = drawingCharacter;
            }

            return true;
        } catch (RuntimeException ex) {
            PrintError("Unexpected Exception: " + ex.getMessage());
            return false;
        }
    }

    public static void DrawBucketFill(DrawingCanvas canvas, PointCoordinate startPointCoordinate, char drawingCharacter) {
        int x = startPointCoordinate.getX();
        int y = startPointCoordinate.getY();

        // return if selected point is not blank
        if((int)canvas.DrawingCanvasMatrix[y][x] != 0) {
            return;
        }

        // selected point should be within the bounds of canvas
        if(x > 0 || x < canvas.DrawingCanvasMatrix[0].length || y > 0 || y  < canvas.DrawingCanvasMatrix.length) {

            // draw character only if that place is blank
            if((int)canvas.DrawingCanvasMatrix[y][x] == 0)
                canvas.DrawingCanvasMatrix[y][x] = drawingCharacter;

            // call for next row
            DrawBucketFill(canvas, new PointCoordinate(x + 1, y), drawingCharacter);

            // call for previous row
            DrawBucketFill(canvas, new PointCoordinate(x-1,y), drawingCharacter);

            // call for next column
            DrawBucketFill(canvas, new PointCoordinate(x,y-1), drawingCharacter);

            // call for previous column
            DrawBucketFill(canvas, new PointCoordinate(x,y+1), drawingCharacter);
        }
    }


    public static void PrintError() {
        PrintError("Invalid Input. Please try again...");
    }

    public static void PrintError(String message) {
        System.out.println(ANSI_RED + message + ANSI_RESET);
    }
}
