using System;
using System.Collections.Generic;

namespace CSDrawingProgram
{
    class Program
    {
        private static List<IDrawingObjectCommand> _commandHistory = new List<IDrawingObjectCommand>();

        static void Main()
        {
            //DoWork();

            // take input from keyboard
            string command = TakeInput();

        }

        private static void DoWork()
        {
            while (true)
            {
                // take input from keyboard
                string command = TakeInput();

                // validate input and get relevant object created from factory
                IDrawingObjectCommand commandObject = ValidateAndCreateCommand(command);

                // if created object is null it means data entered was invalid
                if (commandObject == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input. Exiting...");
                    Console.ResetColor();
                    return;
                }

                _commandHistory.Add(commandObject);

                Console.Clear();

                foreach (var drawingObjectCommand in _commandHistory)
                {
                    drawingObjectCommand.DrawMe();
                }
            }
        }

        private static IDrawingObjectCommand ValidateAndCreateCommand(string command)
        {
            IDrawingObjectCommand drawingObjectCommand = null;
            string[] commandParts = command.Split();

            if (commandParts.Length <= 0)
                return null;

            switch (commandParts[0])
            {
                case "C":
                    drawingObjectCommand = CanvasCommand.ValidateInputReturnObject(commandParts);
                    break;
                case "L":
                    drawingObjectCommand = LineCommand.ValidateInputReturnObject(commandParts);
                    break;
                case "R":
                    drawingObjectCommand = RectangleCommand.ValidateInputReturnObject(commandParts);
                    break;
                case "Q":
                    Environment.Exit(0);
                    break;
            }

            return drawingObjectCommand;
        }

        private static string TakeInput()
        {
            while (true)
            {
                //Console.SetCursorPosition(0, 0);


                Console.Write("\nEnter Command: ");
                string command = Console.ReadLine()?.Trim();
                if (command?.Length > 0)
                    return command;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input. Please try again...");
                Console.ResetColor();
            }
        }
    }
}
