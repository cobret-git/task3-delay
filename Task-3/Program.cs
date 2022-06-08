using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace Task_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TASK#3");
            ChooseOperation();
        }
        static void ChooseOperation()
        {
            Console.WriteLine();

            Dictionary<string, Action> dictionary = new Dictionary<string, Action>()
            {
                {"Reverse string",  ReverseString},
                {"Capitilize string",  CapitilizeString},
                {"Split string",  SplitString},
            };
            for (int i = 0; i < dictionary.Count; i++)
                Console.WriteLine($"{i}. {dictionary.ElementAt(i).Key}");

            Console.Write($"\nType index of operation ({0} - {dictionary.Count - 1}): ");
            string userAnswer = Console.ReadLine();
            int indexOfOperation = 0;

            if (string.IsNullOrWhiteSpace(userAnswer) 
                || !int.TryParse(userAnswer, out indexOfOperation)
                || (indexOfOperation >= dictionary.Count || indexOfOperation < 0))
            {
                Console.WriteLine("\nERROR");
                ChooseOperation();
            }

            dictionary.ElementAt(indexOfOperation).Value.Invoke();
        }

        static void ReverseString()
        {
            Console.Write("\n\nType a string for reverse: ");
            string userAnswer = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userAnswer))
            {
                Console.WriteLine("\nERROR");
                ReverseString();
            }

            server = new DelayServer();
            server.Answer += DisplayAnswer;
            server.ReverseString(userAnswer);
            EnableLoading();
        }
        static void CapitilizeString()
        {
            Console.Write("\n\nType a string for capitilize: ");
            string userAnswer = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userAnswer))
            {
                Console.WriteLine("\nERROR");
                CapitilizeString();
            }

            server = new DelayServer();
            server.Answer += DisplayAnswer;
            server.CapitilizeString(userAnswer);
            EnableLoading();
        }
        static void SplitString()
        {
            Console.Write("\n\nType a string for split: ");
            string userAnswer = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userAnswer))
            {
                Console.WriteLine("\nERROR");
                SplitString();
            }

            server = new DelayServer();
            server.Answer += DisplayAnswer;
            server.SplitString(userAnswer);
            EnableLoading();
        }
        static void DisplayAnswer(string text)
        {
            Console.Write($" {text}");
            LoadingTimer.Stop();
            Console.ReadLine();
        }
        static Timer LoadingTimer;
        static DelayServer server;
        static void EnableLoading()
        {
            LoadingTimer = new Timer(500);
            LoadingTimer.AutoReset = true;
            LoadingTimer.Enabled = true;
            LoadingTimer.Elapsed += ShowLoadDots;
            PauseConsole();
        }
        static void PauseConsole()
        {
            while (Console.ReadKey(true).Key == ConsoleKey.Q) StopConsole();
        }
        static void ShowLoadDots(object sender, ElapsedEventArgs e)
        {
            Console.Write(" .");
        }
        static void StopConsole()
        {
            LoadingTimer.Stop();
            server.Answer -= DisplayAnswer;
            Console.WriteLine("\nSTOP");
        }
    }
}
