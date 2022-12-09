using System;
using System.Collections;
using System.Diagnostics;

/* Xing zhao */
namespace Exercise4
{
    class Program
    {

        static void Main()
        {

            while (true)
            {
                Console.WriteLine("\n\nPlease navigate through the menu by inputting the number \n(1, 2, 3, 4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' ';
                try
                {
                    input = Console.ReadLine()![0];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;

                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }


        static void ExamineList()
        {

            bool running = true;
            List<string> theList = new List<string>();
            while (running)
            {
                Console.WriteLine($"\n\n0 to quit.\n+(value) to add.\n-(value) to remove.\nThe list({theList.Count}, {theList.Capacity}):");

                foreach (var item in theList)
                {
                    Console.WriteLine(item);
                }
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);
                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        break;
                    case '-':
                        theList.Remove(value);
                        break;
                    case '0':
                        running = false;
                        break;
                }
            }


        }

        static void ExamineQueue()
        {

            bool running = true;
            Queue theQueue = new Queue();
            while (running)
            {
                Console.WriteLine($"\n\n0 to quit.\n+(value) to add.\n- to remove.\nThe queue({theQueue.Count}):");

                foreach (var item in theQueue)
                {
                    Console.WriteLine(item);
                }
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);
                switch (nav)
                {
                    case '+':
                        theQueue.Enqueue(value);
                        break;
                    case '-':
                        theQueue.Dequeue();
                        break;
                    case '0':
                        running = false;
                        break;
                }
            }
        }

        static void ExamineStack()
        {

            bool running = true;
            Stack theStack = new Stack();
            while (running)
            {
                Console.WriteLine($"\n\n0 to quit.\n+(value) to add.\n- to remove.\nThe stack({theStack.Count}):");
                foreach (var item in theStack)
                {
                    Console.WriteLine(item);
                }
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);
                switch (nav)
                {
                    case '+':
                        string reversedValue = ReverseText(value);
                        theStack.Push(reversedValue);
                        break;
                    case '-':
                        theStack.Pop();
                        break;
                    case '0':
                        running = false;
                        break;
                }
            }
        }

        static void CheckParanthesis()
        {

            Stack<char> stack = new Stack<char>();
            Console.WriteLine($"0 to quit.\nEnter parathensises: ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    return;
            }
            for (int i = 0; i < input.Length; i++)
            {
                char character = input[i];
                if (character == '(' || character == '{' || character == '[')
                {
                    stack.Push(character);
                }

                else if (character == ')' || character == '}' || character == ']')
                {
                    if (stack.Any() == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Paranthesis is incorrect");
                        Console.ForegroundColor = ConsoleColor.White;
                        return;
                    }

                    else
                    {
                        switch (character)
                        {

                            case ')':
                                if (stack.Pop() != '(')
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Paranthesis is incorrect");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    return;
                                }
                                break;
                            case '}':
                                if (stack.Pop() != '{')
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Paranthesis is incorrect");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    return;
                                }
                                break;
                            case ']':
                                if (stack.Pop() != '[')
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Paranthesis is incorrect");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    return;
                                }
                                break;
                        }
                    }
                }
            }

            if (!stack.Any())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Paranthesis is correct");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            else if (stack.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Paranthesis is incorrect");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Console.WriteLine("Invalid input. Please enter paranthesis");

        }
        static string ReverseText(string value)
        {
            Stack stack = new Stack();
            string reversed = "";

            for (int i = 0; i < value.Length; i++)
            {
                stack.Push(value[i]);
            }
            while (stack.Count > 0)
            {
                reversed += stack.Pop().ToString();
            }
            return reversed;
        }

    }
}