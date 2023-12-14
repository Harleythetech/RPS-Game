using System;
using System.ComponentModel;

class Program
{

    static void Main()
    {
        //DYNAMIC GAME DISPLAY + VARIABLES
        string keys = "Press any Key to Continue...";
        string rock = "    _______\r\n---'   ____)\r\n      (_____)\r\n      (_____)\r\n      (____)\r\n---.__(___)";
        string paper = "     _______\r\n---'    ____)____\r\n           ______)\r\n          _______)\r\n         _______)\r\n---.__________)";
        string scissors = "    _______\r\n---'   ____)____\r\n          ______)\r\n       __________)\r\n      (____)\r\n---.__(___)";
        string intro = "Rock Paper Scissors - A C# Console Based Game Created by Group 9 \nInitializing.....";

        string RPS = "  _____            _      _____                         _____      _                        \r\n |  __ \\          | |    |  __ \\                       / ____|    (_)                       \r\n | |__) |___   ___| | __ | |__) |_ _ _ __   ___ _ __  | (___   ___ _ ___ ___  ___  _ __ ___ \r\n |  _  // _ \\ / __| |/ / |  ___/ _` | '_ \\ / _ \\ '__|  \\___ \\ / __| / __/ __|/ _ \\| '__/ __|\r\n | | \\ \\ (_) | (__|   <  | |  | (_| | |_) |  __/ |     ____) | (__| \\__ \\__ \\ (_) | |  \\__ \\\r\n |_|  \\_\\___/ \\___|_|\\_\\ |_|   \\__,_| .__/ \\___|_|    |_____/ \\___|_|___/___/\\___/|_|  |___/\r\n                                    | |                                                     \r\n                                    |_|                                                     ";

        //INPUT VARIABLES
        int mode = 0;
        try
        {

            do
            {
                //GAME INSTANCE
                Console.WriteLine(intro);
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine($"{RPS} \nWelcome to RPS, Please Select your Game Mode.");
                Console.WriteLine("\n1. Player vs Computer \n2. Player vs Player \n3. Exit Game");

                Console.Write("\nInput: ");
                if (!int.TryParse(Console.ReadLine(), out mode))
                {
                    Console.Clear();
                    Console.WriteLine($"{RPS} \nInvalid Input, Please Try Again.");
                    Thread.Sleep(1000);
                    Console.WriteLine("Press Any Key to Continue (EXCEPT THE POWER BUTTON AND RESTART BUTTON)");
                    Console.ReadKey();
                    continue;
                }






                // EXIT HANDLING + MODE SELECTION HANDLING
                if (mode == 3)
                {
                    Console.Write("\nAre you Sure You want to Exit? Y/N ");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        //EXIT
                        Console.Clear();
                        Console.WriteLine($"{RPS} \nThank You for playing Rock Paper Scissors");
                        Console.WriteLine(keys);
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        // Lets the user choose another operation
                        Console.Write($"\n{keys}");
                        continue;
                    }
                }
                else if (mode > 3)
                {
                    //Error Handling for Invalid Input
                    Console.Clear();
                    Console.WriteLine($"{RPS} \nERROR: Number Entered is Invalid, Try Again.");
                    Thread.Sleep(1000);
                    Console.WriteLine(keys);
                    Console.ReadKey();
                    continue;
                }

            // IF BOTH CONDITIONS ARE MET, THE GAME WILL CLOSE
            } while (Console.ReadKey().Key == ConsoleKey.Y && mode != 3);
                    Console.Clear();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}