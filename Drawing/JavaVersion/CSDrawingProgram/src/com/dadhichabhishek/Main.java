package com.dadhichabhishek;

import java.util.*;

public class Main {
    private static DrawingCanvas _drawingCanvas;

    public static void main(String[] args) {
        DoWork();
    }

    private static void DoWork() {
        while (true) {
            // take input from keyboard
            String command = TakeInput();

            // validate input and get relevant object created from factory
            if (ValidateAndFillCanvasMatrix(command)) {
                if (_drawingCanvas != null) {
                    _drawingCanvas.DrawMe();
                } else {
                    DrawingHelper.PrintError("Canvas not defined yet. Define Canvas using command 'C width height' and then issue commands to draw shapes.");
                }
            } else {
                DrawingHelper.PrintError();
            }
        }
    }

    private static boolean ValidateAndFillCanvasMatrix(String command) {
        String[] commandParts = command.split("\\s+");

        if (commandParts.length <= 0) {
            DrawingHelper.PrintError();
            return false;
        }

        switch (commandParts[0]) {
            case "C":
                return FillCanvasMatrix(commandParts);
            case "L":
                return FillLineInCanvasMatrix(commandParts);
            case "R":
                return FillRectangleInCanvasMatrix(commandParts);
            case "B":
                return FillBucketFillInCanvasMatrix(commandParts);
            case "Q":
                System.exit(0);
                break;
        }

        // to keep compiler happy
        return false;
    }

    private static boolean FillCanvasMatrix(String[] input) {
        // validate number of params
        if (input == null || input.length != 3)
            return false;

        int width = 0;
        int height = 0;

        try {
            width = Integer.parseInt(input[1]);
            height = Integer.parseInt(input[2]);
        } catch (Exception ex) {
            return false;
        }

        _drawingCanvas = new DrawingCanvas(width, height);

        return true;
    }

    private static boolean FillLineInCanvasMatrix(String[] input) {
        // validate number of params
        if (input == null || input.length != 5) {
            return false;
        }

        int x1, y1, x2, y2;

        try {
            x1 = Integer.parseInt(input[1]);
            y1 = Integer.parseInt(input[2]);
            x2 = Integer.parseInt(input[3]);
            y2 = Integer.parseInt(input[4]);
        } catch (Exception ex) {
            return false;
        }

        return DrawingHelper.DrawLine(_drawingCanvas, new PointCoordinate(x1, y1), new PointCoordinate(x2, y2), 'x');
    }

    private static boolean FillRectangleInCanvasMatrix(String[] input) {
        // validate number of params
        if (input == null || input.length != 5) {
            return false;
        }

        int x1, y1, x2, y2;

        try {
            x1 = Integer.parseInt(input[1]);
            y1 = Integer.parseInt(input[2]);
            x2 = Integer.parseInt(input[3]);
            y2 = Integer.parseInt(input[4]);
        } catch (Exception ex) {
            return false;
        }

        return DrawingHelper.DrawRectangle(_drawingCanvas, new PointCoordinate(x1, y1), new PointCoordinate(x2, y2), 'x');
    }

    private static boolean FillBucketFillInCanvasMatrix(String[] input) {
        // validate number of params
        if (input == null || input.length != 4) {
            return false;
        }

        int x1, y1;

        try {
            x1 = Integer.parseInt(input[1]);
            y1 = Integer.parseInt(input[2]);
        } catch (Exception ex) {
            return false;
        }

        DrawingHelper.DrawBucketFill(_drawingCanvas, new PointCoordinate(x1, y1), input[3].charAt(0));

        return true;
    }

    private static String TakeInput() {
        Scanner scanner = new Scanner(System.in);
        while (true) {
            System.out.print("\nEnter Command: ");
            String command = scanner.nextLine();

            if (command != null) {
                command = command.trim().toUpperCase();

                if (command.length() > 0){
                    scanner.close();
                    return command;
                }
            }

            DrawingHelper.PrintError();
        }
    }
}
