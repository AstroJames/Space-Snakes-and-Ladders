using System.Diagnostics;

namespace Object_Classes {
    /// <summary>
    /// Models a game board for Space Race consisting of three different types of squares
    /// 
    /// Ordinary squares, Wormhole squares and Blackhole squares.
    /// 
    /// landing on a Wormhole or Blackhole square at the end of a player's move 
    /// results in the player moving to another square
    /// 
    /// </summary>
    public static class Board {
        /// <summary>
        /// Models a game board for Space Race consisting of three different types of squares
        /// 
        /// Ordinary squares, Wormhole squares and Blackhole squares.
        /// 
        /// landing on a Wormhole or Blackhole square at the end of a player's move 
        /// results in the player moving to another square
        /// 
        /// 
        /// </summary>

        public const int NUMBER_OF_SQUARES = 56;
        public const int START_SQUARE_NUMBER = 0;
        public const int FINISH_SQUARE_NUMBER = NUMBER_OF_SQUARES - 1;
        public const int WORM_HOLES_LENGTH = 8;
        public const int BLACK_HOLES_LENGTH = 8;

        private static Square[] squares = new Square[NUMBER_OF_SQUARES];

        // Public accessor of the board squares
        public static Square[] Squares {
            get {
                Debug.Assert(squares != null, "squares != null",
                   "The game board has not been instantiated");
                return squares;
            }
        }

        public static Square StartSquare {
            get {
                return squares[START_SQUARE_NUMBER];
            }
        }


        /// <summary>
        ///  Eight Wormhole squares.
        ///  
        /// Each row represents a Wormhole square number, the square to jump forward to and the amount of fuel consumed in that jump.
        /// 
        /// For example {2, 22, 10} is a Wormhole on square 2, jumping to square 22 and using 10 units of fuel
        /// 
        /// </summary>
        private static int[,] wormHoles =
        {
            {2, 22, 10},
            {3, 9, 3},
            {5, 17, 6},
            {12, 24, 6},
            {16, 47, 15},
            {29, 38, 4},
            {40, 51, 5},
            {45, 54, 4}
        };

        /// <summary>
        ///  Eight Blackhole squares.
        ///  
        /// Each row represents a Blackhole square number, the square to jump back to and the amount of fuel consumed in that jump.
        /// 
        /// For example {10, 4, 6} is a Blackhole on square 10, jumping to square 4 and using 6 units of fuel
        /// 
        /// </summary>
        private static int[,] blackHoles =
        {
            {10, 4, 6},
            {26, 8, 18},
            {30, 19, 11},
            {35,11, 24},
            {36, 34, 2},
            {49, 13, 36},
            {52, 41, 11},
            {53, 42, 11}
        };


        /// <summary>
        /// Parameterless Constructor
        /// Initialises a board consisting of a mix of Ordinary Squares,
        ///     Wormhole Squares and Blackhole Squares.
        /// 
        /// Pre:  none
        /// Post: board is constructed
        /// </summary>
        public static void SetUpBoard() {
            bool foundState = false;

            // Create the 'start' square where all players will start.
            squares[START_SQUARE_NUMBER] = new Square("Start", START_SQUARE_NUMBER);

            // Create the main part of the board, squares 1 .. 54
            //  CODE NEEDS TO BE ADDED HERE
            //
            //   Need to call the appropriate constructor for each square
            //       either new Square(...),  new WormholeSquare(...) or new BlackholeSquare(...)

            for (int i = START_SQUARE_NUMBER + 1; i <= FINISH_SQUARE_NUMBER - 1; i ++) // board iteration 
            {
                foundState = false; // intialise foundState to be false for each new board iteration

                for (int j = 0; j <= WORM_HOLES_LENGTH -1; j++) // b.hole and w.hole iteration
                {
                    if (i == wormHoles[j, 0]) // match the board coord with the w.hole coord
                    {
                        squares[i] = new WormholeSquare(i.ToString(), i, wormHoles[j, 1], wormHoles[j, 2]);
                        foundState = true; // set Foundstate to be true
                        break;
                    }
                    else if (i == blackHoles[j, 0]) // match the board coord with the b.hole coord
                    {
                        squares[i] = new BlackholeSquare(i.ToString(), i, blackHoles[j, 1], blackHoles[j, 2]);
                        foundState = true; // set foundState to be true
                        break;
                    }
                }
            
                if (foundState == false)
                {
                    squares[i] = new Square(i.ToString(), i);
                }
            }

            //

            // Create the 'finish' square.
            squares[FINISH_SQUARE_NUMBER] = new Square("Finish", FINISH_SQUARE_NUMBER);
        } // end SetUpBoard

        /// <summary>
        /// Finds the destination square and the amount of fuel used for either a 
        /// Wormhole or Blackhole Square.
        /// 
        /// pre: squareNum is either a Wormhole or Blackhole square number
        /// post: destNum and amount are assigned correct values.
        /// </summary>
        /// <param name="holes">a 2D array representing either the Wormholes or Blackholes squares information</param>
        /// <param name="squareNum"> a square number of either a Wormhole or Blackhole square</param>
        /// <param name="destNum"> destination square's number</param>
        /// <param name="amount"> amont of fuel used to jump to the deestination square</param>
        private static void FindDestSquare(int[,] holes, int squareNum, out int destNum, out int amount) {
            const int start = 0, exit = 1, fuel = 2;
            destNum = 0; amount = 0;

            for (int i = 0; i < WORM_HOLES_LENGTH; i ++)
            {
                if (holes[i,0] == squareNum)
                {
                    destNum = holes[i, 1];
                    amount  =  holes[i, 2];
                }
            }

        } //end FindDestSquare

    } //end class Board
}