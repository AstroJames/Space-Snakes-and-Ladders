using System.Drawing;
using System.ComponentModel;
using Object_Classes;


namespace Game_Logic_Class
{
    public static class SpaceRaceGame
    {
        // Minimum and maximum number of players.
        public const int MIN_PLAYERS = 2;
        public const int MAX_PLAYERS = 6;
   
        private static int numberOfPlayers = 2;  //default value for test purposes only 
        public static int NumberOfPlayers
        {
            get
            {
                return numberOfPlayers;
            }
            set
            {
                numberOfPlayers = value;
            }
        }

        public static string[] names = { "One", "Two", "Three", "Four", "Five", "Six" };  // default values
        
        // Only used in Part B - GUI Implementation, the colours of each player's token
        private static Brush[] playerTokenColours = new Brush[MAX_PLAYERS] { Brushes.Yellow, Brushes.Red,
                                                                       Brushes.Orange, Brushes.White,
                                                                      Brushes.Green, Brushes.DarkViolet};
        /// <summary>
        /// A BindingList is like an array which grows as elements are added to it.
        /// </summary>
        private static BindingList<Player> players = new BindingList<Player>();
        public static BindingList<Player> Players
        {
            get
            {
                return players;
            }
        }

        // The pair of die
        private static Die die1 = new Die(), die2 = new Die();


        /// <summary>
        /// Set up the conditions for this game as well as
        ///   creating the required number of players, adding each player 
        ///   to the Binding List and initialize the player's instance variables
        ///   except for playerTokenColour and playerTokenImage in Console implementation.
        ///   
        ///     
        /// Pre:  none
        /// Post:  required number of players have been initialsed for start of a game.
        /// </summary>
        public static void SetUpPlayers() 
        {
            // for number of players
            //      create a new player object
            //      initialize player's instance variables for start of a game
            //      add player to the binding list

            players.Clear();
            
            for (int i = 0; i < numberOfPlayers; i++)
            {
                players.Add( new Player(names[i]));                      // Add new Player to players(BindingList)

                players[i].Position = 0;                                // Player position at square 0
                players[i].RocketFuel = Player.INITIAL_FUEL_AMOUNT;     // Default fuel of 60
                players[i].Location = Board.Squares[0];                 // Player on Starting Square
                players[i].HasPower = true;                             // Player can move
                players[i].AtFinish = false;                            // Player has not finished
                players[i].PlayerTokenColour = playerTokenColours[i];   // playerTokenColour not yet implemented
                // playerTokenImage not yet implemented
            }

        }

            /// <summary>
            ///  Plays one round of a game
            /// </summary>
        public static void PlayOneRound(Die die1, Die die2) 
        {
            for (int i = 0; i <numberOfPlayers; i++)
            {
                // test if player Has Power, if not continue;

                if (players[i].HasPower)
                {
                    players[i].Play(die1, die2);
                }
                else
                {
                    continue;
                }
            }


        }

        ///<summary>
        /// Step for a single player
        ///</summary>summary>
        public static void StepPlayer(int count, Die die1, Die die2)
        {
            if (players[count].HasPower)
            {
                players[count].Play(die1, die2);
            }
            
        }


    }//end SnakesAndLadders
}