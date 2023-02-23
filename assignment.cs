using System;
using static System.Console;

namespace WeightedAverageCalc
{
    class WAC
    {
        static void Main(string[] args)
        {
            // constant weights are defined here
            const float ASSIGNMENTS_PERCENTAGE = 0.2f;
            const float MIDTERM_EXAM_PERCENTAGE = 0.3f;
            const float QUIZ_PERCENTAGE = 0.1f;
            const float FINAL_EXAM_PERCENTAGE = 0.3f;

            // variables for storing the grades of a student
            float assignments;
            float midtermExam;
            float quiz1;
            float quiz2;
            float finalExam;

            float weightedExams = 0;
            float totalWeightedAverage = 0;


            Title = "CSIS1175 - Assignment 3 - By [write your name here]";

            DisplayBanner("Total Weighted Average Calculator");

            // The user enters the grades, the program gets them and stores them in the corresponding variable
            bool isInputValid;

            isInputValid = GetUserInput("Assignments", 0, 100, out assignments);
            isInputValid = GetUserInput("Midterm Exam", 0, 100, out midtermExam);
            isInputValid = GetUserInput("Quiz1", 0, 100, out quiz1);
            isInputValid = GetUserInput("Quiz2", 0, 100, out quiz2);
            isInputValid = GetUserInput("Final Exam", 0, 100, out finalExam);

            WriteLine("\n");

            // Total Weighted Average is sum of products of grades and their weight
            if (isInputValid == true && assignments >= 0 && assignments <= 100 && midtermExam >= 0 && midtermExam <= 100
                && quiz1 >= 0 && quiz1 <= 100 && quiz2 >= 0 && quiz2 <= 100 && finalExam >= 0 && finalExam <= 100)
            {
                totalWeightedAverage += WeightedGrade(assignments, ASSIGNMENTS_PERCENTAGE);
                totalWeightedAverage += WeightedGrade(midtermExam, MIDTERM_EXAM_PERCENTAGE);
                totalWeightedAverage += WeightedGrade((quiz1 + quiz2), QUIZ_PERCENTAGE);
                totalWeightedAverage += WeightedGrade(finalExam, FINAL_EXAM_PERCENTAGE);

                DisplayTableRow("Assessment", "Percentage", "Your Grade");
                DisplayTableRow("--------------", " -----------", "----------");

                DisplayTableRow("Assignments", ASSIGNMENTS_PERCENTAGE, assignments, LetterGrade(assignments));
                DisplayTableRow("MidTerm Exam", MIDTERM_EXAM_PERCENTAGE, midtermExam, LetterGrade(midtermExam));
                DisplayTableRow("Quiz1", QUIZ_PERCENTAGE, quiz1, LetterGrade(quiz1));
                DisplayTableRow("Quiz2", QUIZ_PERCENTAGE, quiz2, LetterGrade(quiz2));
                DisplayTableRow("Final Exam", FINAL_EXAM_PERCENTAGE, finalExam, LetterGrade(finalExam));

                WriteLine("----------------------------------------");

                // change the following line of code such that the Floor value of totalWeightedAverage is displayed on Console
                DisplayTableRow("Weighted Total", 1, (float)Math.Floor(totalWeightedAverage), LetterGrade(totalWeightedAverage)); //** Change only this line **//

                WriteLine("\n");

                weightedExams += WeightedGrade(midtermExam, MIDTERM_EXAM_PERCENTAGE);
                weightedExams += WeightedGrade((quiz1 + quiz2), QUIZ_PERCENTAGE);
                weightedExams += WeightedGrade(finalExam, FINAL_EXAM_PERCENTAGE);
                weightedExams /= 0.8f;

            }
            else
                Write("\nPress a key to quit...");
            ReadKey();

            // change the following line of code such that the Ceiling value of weightedExams is displayed on Console
            WriteLine("The Weighted Average Total on Exams (Midterm, Quizzes, Final exam) is {0:F2}", Math.Ceiling(weightedExams)); //** Change only this line **//
            WriteLine("If WAT-on-Exams is less than 50, the student fails the course.");

            ReadKey();
        }

        static bool GetUserInput(string textMessage, byte min, byte max, out float userInputValue)
        {
            string userInput;
            bool isValidInput;

            Write("Enter your input for {0}: ", textMessage);
            userInput = ReadLine();
            isValidInput = float.TryParse(userInput, out userInputValue);
            if (isValidInput == false)
            {
                WriteLine("!!!!!\nThe value for {0} must be a number!\n!!!!!", textMessage);
                userInputValue = 0;
                return isValidInput;
            }
            else if (userInputValue < min || userInputValue > max)
            {
                WriteLine("!!!!!\nThe value input for {0} must be a number between 0 and 100 inclusive!\n!!!!!", textMessage);
                userInputValue = 0;
                return isValidInput;
            }
            else
                return isValidInput;
        }
        static void DisplayBanner(string textMessage)
        {
            Write("\\***************************************\\\n");
            Write("\\\t\t\t\t\t\\\n");
            Write("\\  \"{0}\"  \\\n", textMessage);
            Write("\\\t\t\t\t\t\\\n");
            Write("\\***************************************\\\n");
            WriteLine();
        }
        // this method displays a header row in a table with 3 columns
        static void DisplayTableRow(string column1, string column2, string column3)
        {
            WriteLine("{0,14}{1,13}   {2,-15}", column1, column2, column3);
        }

        // this method display a row in a table with 3 columns
        static void DisplayTableRow(string column1, float column2, float column3, string column4)
        {
            WriteLine("{0,14}{1,13:P0}   {2,-15:F2}", column1, column2, column3, column4);
        }

        // this method receives grade and weight and returns product of these two parameters as weightedGrade 
        static float WeightedGrade(float grade, float weight)
        {
            return grade * weight;
        }
       
      
        static string LetterGrade(float grade)
        {
            Write(grade);
            if (grade >= 95)
            {
                return "A+";
            }
            else if (grade <= 94 && grade >= 90)
            {
                return "A";
            }
            else if (grade <= 89 && grade >= 85)
            {
                return "A-";
            }
            else if (grade <= 84 && grade >= 80)
            {
                return "B+";
            }
            else if (grade <= 79 && grade >= 75)
            {
                return "B";
            }
            else if (grade <= 74 && grade >= 70)
            {
                return "B-";
            }
            else if (grade <= 69 && grade >= 65)
            {
                return "C+";
            }
            else if (grade <= 64 && grade >= 60)
            {
                return "C";
            }
            else if (grade <= 59 && grade >= 55)
            {
                return "C-";
            }
            else if (grade <= 54 && grade >= 50)
            {
                return "P";
            }
            else
                return "F";
        }
    }
}
