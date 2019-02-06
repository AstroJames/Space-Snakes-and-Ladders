using System;
using System.Drawing;
using System.Diagnostics;

namespace Object_Classes {
    /// <summary>
    /// A player who is currently located  on a particular square 
    ///   with a certain amount of rocket fuel remaining
    /// </summary>
    public class Player {
        public const int INITIAL_FUEL_AMOUNT = 60;


        /// <summary>
        /// Public property for name of the player
        /// </summary>
        private string name;
        public string Name {
            get {
                return name;
            }
            set {
                name = value;
            }
        }//end Name


        /// <summary>
        /// Public property for player position on board
        /// </summary>
        private int position;
        public int Position {
            get {
                return position;
            }

            set {
                position = value;
            }
        }//end Position

        /// <summary>
        /// Public property for current square that player is on
        /// </summary>
        private Square location;
        public Square Location {
            get {
                return location;
            }
            set {
                location = value;
            }
        }//end Location


        /// <summary>
        /// Public property for amount of rocket fuel remaining for this player
        /// </summary>
        private int fuelLeft;
        public int RocketFuel {
            get {
                return fuelLeft;
            }
            set {
                fuelLeft = value;
            }
        }//end RocketFuel


        /// <summary>
        /// Public property for player having power
        /// true if fuelLeft > 0
        /// otherwise false
        /// </summary>
        private bool hasPower;
        public bool HasPower {
            get {
                return hasPower;
            }
            set {
                hasPower = value;
            }
        }//end HasPower


        /// <summary>
        /// Public property checks if the player is at the finish
        /// </summary>
        private bool atFinish;
        public bool AtFinish {
            get {
                return atFinish;
            }
            set {
                atFinish = value;
            }
        }//end AtFinish


        /// <summary>
        /// Public property for player token colour
        /// Gets player token colour
        /// Sets player token image
        /// </summary>
        private Brush playerTokenColour;
        public Brush PlayerTokenColour {
            get {
                return playerTokenColour;
            }
            set {
                playerTokenColour = value;
                playerTokenImage = new Bitmap(1, 1);
                using (Graphics g = Graphics.FromImage(PlayerTokenImage))
                {
                    g.FillRectangle(playerTokenColour, 0, 0, 1, 1);
                }
            }
        }//end PlayerTokenColour


        /// <summary>
        /// Public property for player token image
        /// Gets player token image
        /// </summary>
        private Image playerTokenImage;
        public Image PlayerTokenImage {
            get {
                return playerTokenImage;
            }
        }//end PlayerTokenIMage

        
        /// <summary>
        /// Constructor with initialising parameters.
        /// 
        /// Pre:  name to be used for this player.
        /// Post: player object has name
        /// </summary>
        /// <param name="name">Name for this player</param>
        public Player(String name)//, Square initialLocation)
        {
            Name = name;
        } // end Player 


        /// <summary>
        /// Rolls the two dice to determine 
        ///     the number of squares to move forward;
        ///     moves the player position on the board; 
        ///     updates the player's location to new position; and
        ///     determines the outcome of landing on this square.
        ///     
        /// Pre: the dice are initialised
        /// Post: the player is moved along the board and the effect
        ///     of the location the player landed on is applied.
        /// </summary>
        /// 
        /// <param name="d1">first die</param>
        /// <param name="d2">second die</param>
        public void Play(Die d1, Die d2) {
            int rollSum = 0;

            //  1) Roll the die x 2 and add together the rolls
            d1.Roll();
            d2.Roll();
            rollSum = d2.FaceValue + d1.FaceValue;

            // 2) update the position with the sum of the  rolls
            Position += rollSum;

            // 3) Test if the player has finished
            atFinish = ReachedFinalSquare();

            if (!atFinish)
            {
                // 4) If not finished update to new Location

                if (Board.Squares[Position] != null)
                {
                    Location = Board.Squares[Position];
                }

                // 5) check what the location does and update the location, 
                // position and fuel.
                Location.LandOn(this);
            }
            else
            {
                // 6) If at finish update to Finish Square
                Location.LandOn(this);
                Position = Board.FINISH_SQUARE_NUMBER;
                Location = Board.Squares[Position];
            }

        } //end Play


        // <summary>
        /// Consumes specified amount of fuel.        
        /// if insufficent fuel remains, fuel set to zero
        /// </summary>
        /// 
        /// <param name="amount">amount of fuel used</param>
        public void ConsumeFuel(int amount) {
            Debug.Assert(amount > 0, "amount > 0");
            if (fuelLeft > amount) {
                fuelLeft -= amount;
            } else {
                fuelLeft = 0;
                HasPower = false;
            }
        } //end ConsmeFuel


        /// <summary>
        ///  Checks if this player has reached the end of the game
        /// </summary>
        /// 
        /// <returns>true if reached the Final Square</returns>
        private bool ReachedFinalSquare() {

            if (Position >= Board.FINISH_SQUARE_NUMBER)
            {
                return true;
                
            }
            else
            {
                return false;
            }
        } //end ReachedFinalSquare             


    } //end class Player

}
