using System;
using System.Data;

namespace Outguess {
    internal class Program {
        static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--- OUTGUESS ---\n\n");

            Play();
            Console.Write("\nKORAKU says: Press any key to close this application. . .");
            Console.ReadKey();
        }//end main

        static string Input(string prompt) {
            Console.Write(prompt);
            return Console.ReadLine();
        }
        static string InputLine(string prompt) {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
        static void Play() {
            Random rand = new Random(); //declare variables
            int randNum = rand.Next(1, 101);
            byte guessTotal;
            byte guessCount;
            byte pGuess = 0;
            double earnings = 0;
            bool play;
            double bank;
            double wager;
            bool replay = true;
            double initial;
            string post = "";
            int gameCount = 1;
            double win = 0;
            double lose = 0;
            double percentage;
            bool parsed;
            string console;
            do {
                console = (Input("How much cash you layin' down, pardner?\n$")); // set initial bank amount
                parsed = double.TryParse(console, out initial);
            } while (initial <= 0);
            bank = initial; // initial will be recalled at end stats

            while (replay) { // game/next rounds start

                do {
                    console = Input("\nAnd how much would you like to wager? \n$"); // set wager
                    parsed = double.TryParse(console, out wager);
                } while (parsed == false);

                while (wager > bank) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou cannot place a wager larger than your bank!");
                    Console.ForegroundColor = ConsoleColor.White;
                    do {
                        console = Input("And how much would you like to wager? \n$");
                        parsed = double.TryParse(console, out wager);
                    }
                    while (parsed == false);
                }

                while (wager <= 0) { 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou must place at least 0.01!");
                    Console.ForegroundColor = ConsoleColor.White;
                    do {
                        console = Input("And how much would you like to wager? \n$");
                        parsed = double.TryParse(console, out wager);
                    } while (parsed == false);
                }
                Console.WriteLine("\n1 guess = 10x wager\n2 guesses = 9x wager\n3 guesses = 8x wager\n4 guesses = 7x wager\n5 guesses = 6x wager\n6 guesses = 5x wager \n7 guesses = 4x wager\n8 guesses = 3x wager\n9 guesses = 2x wager\n10 guesses = 1x wager");
                do {
                    console = InputLine("\nHow many guesses do you wish to use? (max 10)"); //set guess count
                    parsed = byte.TryParse(console, out guessTotal);
                } while (parsed == false);
                
                while (guessTotal > 10) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nMaximum 10!");
                Console.ForegroundColor = ConsoleColor.White;
                do {
                    console = InputLine("\nHow many guesses do you wish to use? (max 10)");
                    parsed = byte.TryParse(console, out guessTotal);
                } while (parsed == false);                   
                }

                while (guessTotal <= 0) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nMinimum 1!");
                    Console.ForegroundColor = ConsoleColor.White;
                    do {
                        console = InputLine("\nHow many guesses do you wish to use? (max 10)");
                        parsed = byte.TryParse(console, out guessTotal);
                    } while (parsed == false);
                }
                guessCount = guessTotal; 
                Console.WriteLine("");

                play = true; // begin round
                randNum = rand.Next(1, 101);
                while (play) {
                    
                    console = InputLine($"Guess the secret number!");
                    parsed = byte.TryParse(console, out pGuess);

                    if (pGuess > 100 || pGuess < 1) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The range is between 1 and 100!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (pGuess > randNum && pGuess <= 100) {
                        Console.WriteLine("Too high!");
                        guessCount--;
                        Console.WriteLine($"{guessCount} guesses left.\n");
                    }
                    if (pGuess < randNum && pGuess >= 1) {
                        Console.WriteLine("Too low!");
                        guessCount--;
                        Console.WriteLine($"{guessCount} guesses left.\n");
                    }
                    if (pGuess == randNum) {                // if you win / win conditions
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("That's correct!\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        int i = 0;
                        for (int j = 10; j > 0; j--) {
                            i++;
                            if (guessTotal == j) {
                                earnings = wager * i;
                            }
                            if (guessTotal == j) {
                                break;
                            }
                        }
                        //if (guessTotal == 10) {
                        //    earnings = wager * 1;
                        //}
                        //if (guessTotal == 9) {
                        //    earnings = wager * 2;
                        //}
                        //if (guessTotal == 8) {
                        //    earnings = wager * 3;
                        //}
                        //if (guessTotal == 7) {
                        //    earnings = wager * 4;
                        //}
                        //if (guessTotal == 6) {
                        //    earnings = wager * 5;
                        //}
                        //if (guessTotal == 5) {
                        //    earnings = wager * 6;
                        //}
                        //if (guessTotal == 4) {
                        //    earnings = wager * 7;
                        //}
                        //if (guessTotal == 3) {
                        //    earnings = wager * 8;
                        //}
                        //if (guessTotal == 2) {
                        //    earnings = wager * 9;
                        //}
                        //if (guessTotal == 1) {
                        //    earnings = wager * 10;
                        //}
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"You earned ${earnings}!"); 
                        Console.ForegroundColor = ConsoleColor.White;
                        bank = bank - wager;
                        bank = bank + earnings;
                        Console.WriteLine($"You now have ${bank}");
                        win++;
                        break;
                    }
                    if (guessCount == 0) {               // if you lose
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"The solution was {randNum}.\n"); 
                        Console.ForegroundColor = ConsoleColor.White;
                        bank = bank - wager;
                        Console.WriteLine($"You now have ${bank}");
                        lose++;
                        break;
                    }
                }

                play = false;

                if (bank == 0) {                        // game over
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You're out of money!");
                    Console.ForegroundColor = ConsoleColor.White;
                    replay = false;                 
                }
                if (bank > 0) {                         // postmenu
                    post = InputLine("Continue playing? (y/n)");

                    while (post != "y" && post != "n") {
                        post = InputLine("Continue playing? (y/n)");    
                    }
                    if (post == "y") {
                        gameCount++;
                        replay = true;
                    }

                }
                
                if ((bank == 0) || (post == "n")) { // display stats / end of game
                    percentage = win / gameCount;
                    Console.WriteLine($"\nYou played {gameCount} games.");
                    Console.WriteLine($"You won {percentage:p} of games.");
                    Console.WriteLine($"You won {win} games and lost {lose} games.");

                    if (bank > initial) {
                        Console.ForegroundColor= ConsoleColor.Green;
                    }
                    if (bank < initial) {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.WriteLine($"You came in with ${initial}, and you're going home with ${bank}!"); // show earnings / losses
                    Console.ForegroundColor = ConsoleColor.White;
                    replay = false; // do not play again
                    
                }
                
            }
            
        }
     
    }
}