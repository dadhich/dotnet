using System;

class MainClass
{

    public static string QuestionsMarks(string str)
    {

        // code goes here

        int qmCount = 0;
        int firstNum = 0, secondNum = 0;
        string result = "false";
        bool marker = false;
        for (int i = 0; i < str.Length; i++)
        {
            if (marker == true && str[i] == '?')
            {
                qmCount++;
                continue;
            }

            if (char.IsDigit(str[i]) && marker == false)
            {
                firstNum = (int)str[i];
                marker = true;
                continue;
            }

            if (char.IsDigit(str[i]) && marker == true)
            {
                secondNum = (int)str[i];



                if ((firstNum + secondNum) == 10 && qmCount == 3)
                    result = "true";
                else
                {
                    result = "false";
                    break;
                }

                qmCount = firstNum = secondNum = 0;
                marker = false;
            }
        }

        return result;

    }

    static void Main()
    {
        // keep this function call here
        Console.WriteLine(QuestionsMarks(Console.ReadLine()));
    }

}