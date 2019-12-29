Thanks for providing this opportunity to take this coding challenge. I am summarizing the solution in this ReadMe file.

Solution consist of 4 Java files (present in "src\com\dadhichabhishek" folder):
1. Main.java: This file contains the "Main" class that has the public static void main method which is the entry point to run this program.
2. DrawingCanvas.java: This contains DrawingCanvas class that contains the methods and properties specific to the Canvas object.
3. DrawingHelper.java: This is a utility class that contains the methods that populates the Canvas matrix as per the instructions.
4. PointCoordinate.java: This is a simple class that holds co-ordinates of a point. This is to make the code more readable.

Flow and Algorithm:

In a Nutshell:
All commands execution simply updates a 2-Dimensional char array named as "DrawingCanvasMatrix". This is the actual Canvas on which all operations are carried out.
At the end of each command's execution this array is drawn on console using DrawingHelper class' utility methods.

Details:
- The main method calls DoWork() method
	- DoWork() runs an infinite loop within which it takes user commands using TakeInput() method, validates them and executes them using ValidateAndFillCanvasMatrix() method
	- DoWork() also ensures that Canvas gets created first and then only other commands are entertained
	- TakeInput() has a single responsibility to read input from console. It makes sure that if blank/null inputs are provided it doesn't let the execution progress.
	- Once input is received, it is validated using ValidateAndFillCanvasMatrix() method. This method simply calls four specific methods on the basis of first letter of the input command.
	- Each of the above mentioned four methods simply validates if right number and types of parameters are provided with the command or not. In case of validation errors, further progress can't be made.
	- If everything is OK with the validation then the DrawingCanvas class' "DrawingCanvasMatrix" (which is a char 2D array) is updated at appropriate coordinates.
	- Post updation of Canvas, for actual drawing on screen DrawingHelper class' appropriate utility method is called.
	- DrawingHelper class also has error printing mechanism (in Red color)

To run the code, all four classes should be compiled and if manifest is used then Main class' main method should be appointed as entry point. 

Sample Runs output is attached in TestRuns.png file which shows successful execution of all tests carried out. More tests were done to ensure error messages are correctly printed.
