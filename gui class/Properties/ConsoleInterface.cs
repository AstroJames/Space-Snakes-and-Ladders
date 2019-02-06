using System;
//DO NOT DELETE the two following using statements *********************************
using Game_Logic_Class;
using Object_Classes;
using System.Collections.Generic;


namespace Space_Race
{
    class Console_Class
    {
        /// <summary>
        /// Algorithm below currently plays only one game
        /// 
        /// when have this working correctly, add the abilty for the user to 
        /// play more than 1 game if they choose to do so.
        /// </summary>
        /// <param name="args"></param>
        /// 
        // Fuel list for all zero fuel end of game
        // private List<bool> fuelList = new List<bool>();


        static void Main(string[] args)
        {
            DisplayIntroductionMessage();

            /*                    
             Set up the board in Board class (Board.SetUpBoard)
             Determine number of players - initally play with 2 for testing purposes 
             Create the required players in Game Logic class
              and initialize players for start of a game             
             loop  until game is finished           
                call PlayGame in Game Logic class to play one round
                Output each player's details at end of round
             end loop
             Determine if anyone has won
             Output each player's details at end of the game
           */

            // Play First game
            PlayGame();

            // Display game end stats
            GameEnd();
            
            // Option to play a new game OR exit
            NewGame();

            
            
        }//end Main


        /// <summary>
        /// Display a welcome message to the console
        /// Pre:    none.
        /// Post:   A welcome message is displayed to the console.
        /// </summary>
        static void DisplayIntroductionMessage()
        {
            Console.WriteLine("Welcome to Space Race.");
        } //end DisplayIntroductionMessage

        /// <summary>
        /// Displays a prompt and waits for a keypress.
        /// Pre:  none
        /// Post: a key has been pressed.
        /// </summary>
        static void PressEnter()
        {
            Console.Write("\nPress Enter to terminate program ...");
            Console.ReadLine();
        } // end PressAny


        // get number of players for this Game
        static void GetPlayers()
        {
            bool state = false;
            int numPlayers = 0;

            Console.WriteLine("\nThis game is for 2 to 6 players.");
            Console.Write("How many players (2-6): ");

            state = int.TryParse(Console.ReadLine(), out numPlayers);

            // Test for integer and 2 to 6 players
            if (state && numPlayers >= SpaceRaceGame.MIN_PLAYERS && numPlayers <= SpaceRaceGame.MAX_PLAYERS)
            {
                SpaceRaceGame.NumberOfPlayers = numPlayers; // update NumPlayers
            }
            else
            {
                Console.WriteLine("Error: Invalid number of players entered.\n");
                GetPlayers(); // loop again of false
            }
        }

        // Display player details for round
        static void DisplayGame(Player player)
        {
            Console.WriteLine("\t{0} on square {1} with {2} yottaWatts of power remaining.",
                GetName(player), GetPosition(player), GetFuel(player));
        }

        // Return player name
        static string GetName(Player player)
        {
            return player.Name;
        }

        //Return player fuel
        static int GetFuel(Player player)
        {
            return player.RocketFuel;
        }

        // Return player position
        static int GetPosition(Player player)
        {
            return player.Position;
        }

        // Play Game
        static void PlayGame()
        {
            // Setup Board and Dice
            Board.SetUpBoard();
            Die d1 = new Die();
            Die d2 = new Die();

            // Get number of players for 1st round
            GetPlayers();

            SpaceRaceGame.SetUpPlayers();

            bool finishedGame = false;
            int roundCount = 1, fuelEmptyCount = 0;

            while (!finishedGame)
            {
                fuelEmptyCount = 0; // track players with zero fuel each round

                Console.WriteLine("\nPress Enter to play a round  ...");
                Console.ReadLine();

                if (roundCount == 1)
                {
                    Console.WriteLine("First Round\n");
                }
                else
                {
                    Console.WriteLine("Next Round\n");
                }


                SpaceRaceGame.PlayOneRound(d1, d2);

                for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
                {
                    DisplayGame(SpaceRaceGame.Players[i]);

                    // Test if ANY player is at Finish and update finishedGame to true.
                    if (SpaceRaceGame.Players[i].AtFinish == true)
                    {
                        finishedGame = true;
                    }
                    
                    // Test if ANY player has zero fuel
                    if(SpaceRaceGame.Players[i].RocketFuel == 0)
                    {
                        fuelEmptyCount++;
                    }
                }

                // Print statement and End game if ALL players fuel zero
                if(fuelEmptyCount == SpaceRaceGame.NumberOfPlayers)
                {
                    Console.WriteLine("\nAll players are out of fuel: GAME OVER!");
                    finishedGame = true;
                }

                roundCount++;

            }
        }

        static void NewGame()
        {
            string option;

            Console.Write("\nPlay Again? (Y or N): ");
            option = Console.ReadLine();


            if (option == "Y" || option == "y")
            {
                PlayGame();
                GameEnd();
                NewGame();
            }
            else if (option == "N" || option == "n")
            {
                PressEnter();
            }
            else
            {
                Console.WriteLine("\n Error: Invalid option");
                NewGame();
            }

            
        }

        static void GameEnd()
        {
            // List of players that finished the game
            List<string> endList = new List<string>();
                        
            // Update list with names of players who've finished
            for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
            {
                if (SpaceRaceGame.Players[i].AtFinish)
                {
                    endList.Add(SpaceRaceGame.Players[i].Name);
                }
            }

            Console.WriteLine("\nThe following player(s) finished the game\n");
            if (endList.Count == 0)
            {
                Console.WriteLine("\tNo players finished.\n");
            }
            else
            {
                
                for (int i = 0; i < endList.Count; i++)
                {
                    Console.Write("\t{0}", endList[i]);
                }
            }
            Console.WriteLine("\n\nIndividual players finished at the locations specified.");

            // for loop of player stats
            for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)
            {
                Console.WriteLine("\n\t{0} with {1} yottaWatts of power at square {2}",
                GetName(SpaceRaceGame.Players[i]),
                GetFuel(SpaceRaceGame.Players[i]),
                GetPosition(SpaceRaceGame.Players[i]));
            }
        }

    }//end Console class
}
