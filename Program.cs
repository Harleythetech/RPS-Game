﻿using System;
using System.ComponentModel;
using System.Runtime.Versioning;
using System.Threading;

class Program
{
    static bool gamestat = true;
    static string enter = "Press any key to continue...";
    static string cpuid = Convert.ToString(Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION\\SYSTEM\\CentralProcessor\\0", "ProcessorNameString", null)).Trim(); //Remove when using Other OS
    static string asciirps = "    _______               _______                     _______\r\n---'   ____)         ---'    ____)____            ---'   ____)____\r\n      (_____)                   ______)                     ______)\r\n      (_____)                  _______)                 __________)\r\n      (____)                  _______)                  (____)\r\n---.__(___)           ---.__________)             ---.__(___)\r\nROCK                  PAPER                       Scissors";
    static int PC = 0;
    static int P1 = 0;
    static int P2 = 0;
    static int CPU = 0;
    static int modesel = 0;
    static string err = "LOG: Error Occured, Invalid Input Detected..";
    static string RPS = "  _____            _      _____                         _____      _                        \r\n |  __ \\          | |    |  __ \\                       / ____|    (_)                       \r\n | |__) |___   ___| | __ | |__) |_ _ _ __   ___ _ __  | (___   ___ _ ___ ___  ___  _ __ ___ \r\n |  _  // _ \\ / __| |/ / |  ___/ _` | '_ \\ / _ \\ '__|  \\___ \\ / __| / __/ __|/ _ \\| '__/ __|\r\n | | \\ \\ (_) | (__|   <  | |  | (_| | |_) |  __/ |     ____) | (__| \\__ \\__ \\ (_) | |  \\__ \\\r\n |_|  \\_\\___/ \\___|_|\\_\\ |_|   \\__,_| .__/ \\___|_|    |_____/ \\___|_|___/___/\\___/|_|  |___/\r\n                                    | |                                                     \r\n                                    |_|                                                     ";

    static void Main()
    {
        try
        {
            Console.WriteLine("Initializing Rock Paper Scissors.... \nCreated by Group 9 - v2");
            Thread.Sleep(1000);
            do
            {
                Console.Clear();
                Console.WriteLine(RPS);
                Console.WriteLine($"\nPlayer VS CPU ({cpuid}) | SCORE: P1 - {PC} / CPU - {CPU}");
                Console.WriteLine($"Player VS Player | SCORE: P1 - {P1} / P2 - {P2}");
                Console.Write("\nSelect Game Mode:\n1. Player VS CPU \n2. Player VS Player \n3. Exit");
                Console.Write("\n\nEnter Value: ");
                if (!int.TryParse(Console.ReadLine(), out modesel) || modesel >= 4)
                {
                    Console.Clear();
                    Console.WriteLine($"{RPS}\n{err}");
                    continue;
                }
                else if (modesel == 1)
                {
                    // !! REMOVE "{cpuid}" when using other OS, This is a Windows specific thing only !!

                    //HEADER
                    Console.Clear();
                    Console.WriteLine($"{RPS}\nPlayer VS CPU ({cpuid}) | SCORE: P1 - {PC} / CPU - {CPU}");

                    //RANDOM UTIL - CPU SELECTION
                    string[] choices = { "Rock", "Paper", "Scissors" };
                    Random rnd = new Random();
                    int choicerndm = rnd.Next(choices.Length);
                    string answer = choices[choicerndm];
                    Console.Write($"\nPick your Hero: \n{asciirps}");
                    Console.Write("\n\nEnter a Value: ");
                    string Pl1 = Console.ReadLine().Trim(); //A Precautionary Action just incase the user puts space in the value
                                                            //Choice Indicator
                    Console.Clear();
                    Console.WriteLine($"{RPS}\nPlayer VS CPU ({cpuid}) | SCORE: P1 - {PC} / CPU - {CPU}");
                    Console.WriteLine($"\nPlayer Pick: {Pl1}\nCPU Pick: {answer}");//REMOVE AFTER DEBUGGING


                    //ERROR HANDLING + GAME CONDITIONS [GET CONFUSED] 
                    if ((!string.Equals(Pl1, "Rock", StringComparison.OrdinalIgnoreCase)) && (!string.Equals(Pl1, "Paper", StringComparison.OrdinalIgnoreCase)) && (!string.Equals(Pl1, "Scissors", StringComparison.OrdinalIgnoreCase)))
                    {

                        Console.Clear();
                        Console.WriteLine($"{RPS}\n{err}");
                        Console.Write($"\n{enter}");
                    }
                    else if (string.Equals(Pl1, answer, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("\nIt's a Tie!, Try Again!");
                        Console.Write($"\n{enter}");
                        continue;
                    }
                    else if ((string.Equals(Pl1, "Rock", StringComparison.OrdinalIgnoreCase) && answer == "Scissors") || (string.Equals(Pl1, "Paper", StringComparison.OrdinalIgnoreCase) && answer == "Rock") || (string.Equals(Pl1, "Scissors", StringComparison.OrdinalIgnoreCase) && answer == "Paper"))
                    {
                        Console.WriteLine("\nYou win!");
                        Thread.Sleep(1000);
                        Console.Write($"\nA point has been added to the player. {enter}");
                        PC++;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("\nCPU win!");
                        Console.Write($"\nA point has been added to CPU. {enter}");
                        CPU++;
                        continue;
                    }


                }
                else if (modesel == 2)
                {
                    Console.Clear();
                    Console.WriteLine($"{RPS}\nPlayer VS Player | SCORE: P1 - {P1} / P2 - {P2}");

                    //P1
                    Console.Write($"\nPick your Hero Player 1: \n{asciirps}");
                    Console.Write("\n\nEnter a Value: ");
                    string Pl1 = Console.ReadLine().Trim(); //A Precautionary Action just incase the user puts space in the value

                    //P2
                    Console.Clear();
                    Console.WriteLine($"{RPS}\nPlayer VS Player | SCORE: P1 - {P1} / P2 - {P2}");
                    Console.Write($"\nPick your Hero Player 2: \n{asciirps}");
                    Console.Write("\n\nEnter a Value: ");
                    string Pl2 = Console.ReadLine().Trim(); //A Precautionary Action just incase the user puts space in the value


                    //ERROR HANDLING + GAME CONDITIONS [GET CONFUSED] 
                    if ((!string.Equals(Pl1, "Rock", StringComparison.OrdinalIgnoreCase)) && (!string.Equals(Pl1, "Paper", StringComparison.OrdinalIgnoreCase)) && (!string.Equals(Pl1, "Scissors", StringComparison.OrdinalIgnoreCase)))
                    {

                        Console.Clear();
                        Console.WriteLine($"{RPS}\n{err}");
                        Console.Write($"\n{enter}");
                    }
                    else if((!string.Equals(Pl2, "Rock", StringComparison.OrdinalIgnoreCase)) && (!string.Equals(Pl2, "Paper", StringComparison.OrdinalIgnoreCase)) && (!string.Equals(Pl2, "Scissors", StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.Clear();
                        Console.WriteLine($"{RPS}\n{err}");
                        Console.Write($"\n{enter}");
                    }
                    else if (string.Equals(Pl1, Pl2, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("\nIt's a Tie!, Try Again!");
                        Console.Write($"\n{enter}");
                        continue;
                    }
                    else if ((string.Equals(Pl1, "Rock", StringComparison.OrdinalIgnoreCase) && (string.Equals(Pl2, "Scissors", StringComparison.OrdinalIgnoreCase)) || (string.Equals(Pl1, "Paper", StringComparison.OrdinalIgnoreCase) && (string.Equals(Pl2, "Rock", StringComparison.OrdinalIgnoreCase))) || (string.Equals(Pl1, "Scissors", StringComparison.OrdinalIgnoreCase) && (string.Equals(Pl1, "Paper", StringComparison.OrdinalIgnoreCase))) ))
                    {
                        Console.WriteLine("\nPlayer 1 win!");
                        Thread.Sleep(1000);
                        Console.Write($"\nA point has been added to the player. {enter}");
                        P1++;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("\nPlayer 2 win!");
                        Thread.Sleep(1000);
                        Console.Write($"\nA point has been added to CPU. {enter}");
                        P2++;
                        continue;
                    }

                }
                else if (modesel == 3)
                {
                    Console.Write("\nAre you Sure You want to Exit? Y/N ");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        //EXIT
                        Console.Clear();
                        Console.WriteLine($"{RPS} \nThank You for playing Rock Paper Scissors");
                        Console.WriteLine(enter);
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                    }
                    else
                    {
                        // Lets the user choose another operation
                        Console.Write($"\n{enter}");
                        continue;
                    }
                }



            } while (Console.ReadKey().Key != ConsoleKey.Y && modesel != 3);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"LOG:{ex.Message}");
        }
    }
}

