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
        } //end PressAny


        /// <summary>
        /// Prompts user for number of players for this Game and updates number of players.
        /// Pre:  none
        /// Post: Updates SpaceRaceGame.NumberOfPlayers with number of players
        /// </summary>        
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

        }//end GetPlayers


        /// <summary>
        /// Display player Name, Positon and fuel.
        /// Pre:  none
        /// Post: Updates SpaceRaceGame.NumberOfPlayers with number of players
        /// </summary>
        /// 
        /// <param name="player">Player whose details to display</param>
        static void DisplayGame(Player player)
        {
            Console.WriteLine("\t{0} on square {1} with {2} yottaWatts of power remaining.",
                GetName(player), GetPosition(player), GetFuel(player));
        }//end DisplayGame


        /// <summary>
        /// Returns player name.
        /// Pre:  none
        /// Post: Returns player name
        /// </summary>
        /// 
        /// <param name="player">Player whose name to return</param>
        static string GetName(Player player)
        {
            return player.Name;
        }//end GetName


        /// <summary>
        /// Returns player fuel.
        /// Pre:  none
        /// Post: Returns player fuel amount.
        /// </summary>
        /// 
        /// <param name="player">Player whose fuel amount to return</param>
        static int GetFuel(Player player)
        {
            return player.RocketFuel;
        }//end GetFuel


        /// <summary>
        /// Return player position
        /// Pre:  none
        /// Post: Returns player position.
        /// </summary>
        /// 
        /// <param name="player">Player whose position to return</param>
        static int GetPosition(Player player)
        {
            return player.Position;
        }//end GetPosition


        /// <summary>
        /// This method encapsulates all of the initialisations for the console game.
        /// The board is setup, the die instance are crated, then the game is run via the console. 
        /// 
        /// The amount of players are selected using the GetPlayers() method.
        /// 
        /// The game continues to run until the players have run out of fuel or if players
        /// are able to finsh the game.
        /// </summary>
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


                // Update if players have Finished or are out of Fuel
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

        }//end PlayGame


        /// <summary>
        /// This method handles the interfacing with a new game, after a game has been run.
        /// 
        /// Players are either able to quit the game, or repeat the game, depending on their
        /// console input.
        /// 
        /// Pre:  Game has finished.
        /// Post: Players select if they want to play again.
        /// </summary>
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
            else //if (option == "N" || option == "n")
            {
                PressEnter();
            }
            // NOT REQUIRED by CRA and Part A Specification
            //else
            //{
            //    Console.WriteLine("\n Error: Invalid option");
            //    NewGame();
            //}

            
        }//end NewGame


        /// <summary>
        /// This method handles the events at the end of a game. 
        /// 
        /// This method checks which players have finished the game and
        /// presents a message box telling the user who has fnished, i.e.
        /// which players have won the game.
        /// 
        /// This method also gets the location and fuel quantities of each
        /// player and writes it to the console at the end of the game. 
        /// 
        /// Pre:  none
        /// Post: 
        /// </summary>
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
        }//end GameEnd


    }//end Console class
}
