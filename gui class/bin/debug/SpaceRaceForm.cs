using System;
//  Uncomment  this using statement after you have remove the large Block Comment below 
using System.Drawing;
using System.Windows.Forms;
using Game_Logic_Class;
//  Uncomment  this using statement when you declare any object from Object Classes, eg Board,Square etc.
using Object_Classes;

namespace GUI_Class
{
    public partial class SpaceRaceForm : Form
    {
        // The numbers of rows and columns on the screen.
        const int NUM_OF_ROWS = 7;
        const int NUM_OF_COLUMNS = 8;
        private static Die die1 = new Die(), die2 = new Die(); // add some dice
        // When we update what's on the screen, we show the movement of a player 
        // by removing them from their old square and adding them to their new square.
        // This enum makes it clear that we need to do both.
        enum TypeOfGuiUpdate { AddPlayer, RemovePlayer };
        bool step = false; // state for single step play
        int countPlay = -1; // player counter for single step play

        public SpaceRaceForm()
        {
            InitializeComponent();
            Board.SetUpBoard();
            ResizeGUIGameBoard();
            SetUpGUIGameBoard();
            SetupPlayersDataGridView();
            DetermineNumberOfPlayers();
            SpaceRaceGame.SetUpPlayers();
            PrepareToPlay();
        }


        /// <summary>
        /// Handle the Exit button being clicked.
        /// Pre:  the Exit button is clicked.
        /// Post: the game is terminated immediately
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }



        //  ******************* Uncomment - Remove Block Comment below
        //                         once you've added the TableLayoutPanel to your form.
        //
        //       You will have to replace "tableLayoutPanel" by whatever (Name) you used.
        //
        //        Likewise with "playerDataGridView" by your DataGridView (Name)
        //  ******************************************************************************************


        /// <summary>
        /// Resizes the entire form, so that the individual squares have their correct size, 
        /// as specified by SquareControl.SQUARE_SIZE.  
        /// This method allows us to set the entire form's size to approximately correct value 
        /// when using Visual Studio's Designer, rather than having to get its size correct to the last pixel.
        /// Pre:  none.
        /// Post: the board has the correct size.
        /// </summary>
        private void ResizeGUIGameBoard()
        {
            const int SQUARE_SIZE   = SquareControl.SQUARE_SIZE;
            int currentHeight       = tableLayoutPanel.Size.Height;
            int currentWidth        = tableLayoutPanel.Size.Width;
            int desiredHeight       = SQUARE_SIZE * NUM_OF_ROWS;
            int desiredWidth        = SQUARE_SIZE * NUM_OF_COLUMNS;
            int increaseInHeight    = desiredHeight - currentHeight;
            int increaseInWidth     = desiredWidth - currentWidth;
            this.Size               += new Size(increaseInWidth, increaseInHeight);
            tableLayoutPanel.Size   = new Size(desiredWidth, desiredHeight);

        }// ResizeGUIGameBoard


        /// <summary>
        /// Creates a SquareControl for each square and adds it to the appropriate square of the tableLayoutPanel.
        /// Pre:  none.
        /// Post: the tableLayoutPanel contains all the SquareControl objects for displaying the board.
        /// </summary>
        private void SetUpGUIGameBoard()
        {
            for (int squareNum = Board.START_SQUARE_NUMBER; squareNum <= Board.FINISH_SQUARE_NUMBER; squareNum++)
            {
                Square square = Board.Squares[squareNum];
                SquareControl squareControl = new SquareControl(square, SpaceRaceGame.Players);
                AddControlToTableLayoutPanel(squareControl, squareNum);
            }//endfor

        }// end SetupGameBoard

        private void AddControlToTableLayoutPanel(Control control, int squareNum)
        {
            int screenRow = 0;
            int screenCol = 0;
            MapSquareNumToScreenRowAndColumn(squareNum, out screenRow, out screenCol);
            tableLayoutPanel.Controls.Add(control, screenCol, screenRow);
        }// end Add Control


        /// <summary>
        /// For a given square number, tells you the corresponding row and column number
        /// on the TableLayoutPanel.
        /// Pre:  none.
        /// Post: returns the row and column numbers, via "out" parameters.
        /// </summary>
        /// <param name="squareNumber">The input square number.</param>
        /// <param name="rowNumber">The output row number.</param>
        /// <param name="columnNumber">The output column number.</param>
        private static void MapSquareNumToScreenRowAndColumn(int squareNum, out int screenRow, out int screenCol)
        {
            // initiliase the maximum board index
            int boardMax = Board.NUMBER_OF_SQUARES - 1;

            // Calculate screenRow number
            screenRow = Convert.ToInt32(Math.Floor((Convert.ToDouble(boardMax) - squareNum) / NUM_OF_COLUMNS));

            // Test if the row is either odd or even, and allocate the column, accordingly
            if(screenRow % 2 == 0)
            {
                screenCol = NUM_OF_ROWS - (boardMax - (screenRow * NUM_OF_COLUMNS) - squareNum);
            }
            else
            {
                screenCol = (boardMax - screenRow * NUM_OF_COLUMNS) - squareNum;
            }
               


        }//end MapSquareNumToScreenRowAndColumn


        private void SetupPlayersDataGridView()
        {
            // Stop the playersDataGridView from using all Player columns.
            playersDataGridView.AutoGenerateColumns = false;
            // Tell the playersDataGridView what its real source of data is.
            playersDataGridView.DataSource = SpaceRaceGame.Players;

        }// end SetUpPlayersDataGridView



        /// <summary>
        /// Obtains the current "selected item" from the ComboBox
        ///  and
        ///  sets the NumberOfPlayers in the SpaceRaceGame class.
        ///  Pre: none
        ///  Post: NumberOfPlayers in SpaceRaceGame class has been updated
        /// </summary>
        private void DetermineNumberOfPlayers()
        {

            // Store the SelectedItem property of the ComboBox in a string
            string numOfPlayers = numOfPlayersInput.SelectedItem.ToString();
            int value;

            // Parse string to a number
            int.TryParse(numOfPlayers, out value);
            SpaceRaceGame.NumberOfPlayers = value;

            // Set the NumberOfPlayers in the SpaceRaceGame class to that number

        }//end DetermineNumberOfPlayers

        /// <summary>
        /// The players' tokens are placed on the Start square
        /// </summary>
        private void PrepareToPlay()
        {
            // More code will be needed here to deal with restarting 
            // a game after the Reset button has been clicked. 
            //
            // Leave this method with the single statement 
            // until you can play a game through to the finish square
            // and you want to implement the Reset button event handler.
            //

            UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);

        }//end PrepareToPlay()


        /// <summary>
        /// Tells you which SquareControl object is associated with a given square number.
        /// Pre:  a valid squareNumber is specified; and
        ///       the tableLayoutPanel is properly constructed.
        /// Post: the SquareControl object associated with the square number is returned.
        /// </summary>
        /// <param name="squareNumber">The square number.</param>
        /// <returns>Returns the SquareControl object associated with the square number.</returns>
        private SquareControl SquareControlAt(int squareNum)
        {
            int screenRow;
            int screenCol;

            MapSquareNumToScreenRowAndColumn(squareNum, out screenRow, out screenCol);
            return (SquareControl)tableLayoutPanel.GetControlFromPosition(screenCol, screenRow);
        }


        /// <summary>
        /// Tells you the current square number of a given player.
        /// Pre:  a valid playerNumber is specified.
        /// Post: the square number of the player is returned.
        /// </summary>
        /// <param name="playerNumber">The player number.</param>
        /// <returns>Returns the square number of the player.</returns>
        private int GetSquareNumberOfPlayer(int playerNumber)
        {
            return SpaceRaceGame.Players[playerNumber].Position;
        }//end GetSquareNumberOfPlayer


        /// <summary>
        /// When the SquareControl objects are updated (when players move to a new square),
        /// the board's TableLayoutPanel is not updated immediately.  
        /// Each time that players move, this method must be called so that the board's TableLayoutPanel 
        /// is told to refresh what it is displaying.
        /// Pre:  none.
        /// Post: the board's TableLayoutPanel shows the latest information 
        ///       from the collection of SquareControl objects in the TableLayoutPanel.
        /// </summary>
        private void RefreshBoardTablePanelLayout()
        {
            // Uncomment the following line once you've added the tableLayoutPanel to your form.
                  tableLayoutPanel.Invalidate(true);
        }

        /// <summary>
        /// When the Player objects are updated (location, etc),
        /// the players DataGridView is not updated immediately.  
        /// Each time that those player objects are updated, this method must be called 
        /// so that the players DataGridView is told to refresh what it is displaying.
        /// Pre:  none.
        /// Post: the players DataGridView shows the latest information 
        ///       from the collection of Player objects in the SpaceRaceGame.
        /// </summary>
        private void UpdatesPlayersDataGridView()
        {
            SpaceRaceGame.Players.ResetBindings();
        }

        /// <summary>
        /// At several places in the program's code, it is necessary to update the GUI board,
        /// so that player's tokens are removed from their old squares
        /// or added to their new squares. E.g. at the end of a round of play or 
        /// when the Reset button has been clicked.
        /// 
        /// Moving all players from their old to their new squares requires this method to be called twice: 
        /// once with the parameter typeOfGuiUpdate set to RemovePlayer, and once with it set to AddPlayer.
        /// In between those two calls, the players locations must be changed. 
        /// Otherwise, you won't see any change on the screen.
        /// 
        /// Pre:  the Players objects in the SpaceRaceGame have each players' current locations
        /// Post: the GUI board is updated to match 
        /// </summary>
        private void UpdatePlayersGuiLocations(TypeOfGuiUpdate typeOfGuiUpdate)
        {
            // Code needs to be added here which does the following:
            //
            //   for each player
            //       determine the square number of the player
            //       retrieve the SquareControl object with that square number
            //       using the typeOfGuiUpdate, update the appropriate element of 
            //          the ContainsPlayers array of the SquareControl object.
            //          
            for (int i =0; i < SpaceRaceGame.NumberOfPlayers; i++)
            {
                
                // Change the state of the square based on the add or remove player argument. 
               if (typeOfGuiUpdate == 0) // add the player
               {
                    SquareControlAt(GetSquareNumberOfPlayer(i)).ContainsPlayers[i] = true; // Update SquareControl players binding list
               }
               else // remove the player
               {
                    SquareControlAt(GetSquareNumberOfPlayer(i)).ContainsPlayers[i] = false; // Update SquareControl players binding list
                }

            }


            RefreshBoardTablePanelLayout();//must be the last line in this method. Do not put inside above loop.
        } //end UpdatePlayersGuiLocations

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numOfPlayersInput_SelectedIndexChanged(object sender, EventArgs e)
        {

            UpdatePlayersGuiLocations(TypeOfGuiUpdate.RemovePlayer);
            DetermineNumberOfPlayers(); // set number of players
            numOfPlayersInput.Enabled = false; // disable comboBox
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);
            rollButton.Enabled = false;
            GroupBox.Enabled = true;
                        
        }

        private void resetButton_Click(object sender, EventArgs e)
        {

            numOfPlayersInput.SelectedIndex = 4; // Default combBox of "6 players"

            UpdatePlayersGuiLocations(TypeOfGuiUpdate.RemovePlayer); // reset gameboard

            // Reset Player Values to Default
            countPlay = -1; // reset single step player counter
            SetupPlayersDataGridView(); 
            DetermineNumberOfPlayers();
            SpaceRaceGame.SetUpPlayers();
            PrepareToPlay();

            // Allow play and player number selection
            rollButton.Enabled = false;
            GroupBox.Enabled = true;
            numOfPlayersInput.Enabled = true;
        }

        private void rollButton_Click(object sender, EventArgs e)
        {
            bool gameEnd = false, stepEnd = false;
            string endTxt = "The following player(s) finished the game\n";

            numOfPlayersInput.Enabled = false; // disable comboBox
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.RemovePlayer); // reset player locations

            // Play Single-step or One Round
            if (step)
            {
                countPlay++; // increment player to take a step

                // Reset player count if new round
                if (countPlay == SpaceRaceGame.NumberOfPlayers)
                {
                    countPlay = 0;
                }

                // Single-step for player
                SpaceRaceGame.StepPlayer(countPlay, die1, die2); 

                // Player End test - Step Play
                if (SpaceRaceGame.Players[countPlay].AtFinish)
                {
                    endTxt += String.Format("\t{0}", SpaceRaceGame.names[countPlay]);
                    stepEnd = true;
                }

                // Game End test - Step Play
                if ((countPlay == (SpaceRaceGame.NumberOfPlayers - 1) && stepEnd))
                {
                    gameEnd = true;
                }

                               
            }

            else
            {
                // Play One Round
                SpaceRaceGame.PlayOneRound(die1, die2);

                // Game End test - Play One Round
                for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)// for each player
                {
                    // Test if player is at Finish update endTxt and gameEnd
                    if (SpaceRaceGame.Players[i].AtFinish)
                    {
                        gameEnd = true;
                        endTxt += String.Format("\t{0}", SpaceRaceGame.names[i]);
                    }

                }
            }
            
            // Update player positions for StepPlay or PlayOneRound
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);
            // Update player data grid for StepPlay or PlayOneRound
            UpdatesPlayersDataGridView();
                       

            // Game End Message
            if (gameEnd) // Show player finished method if any player Finishes
            {   
                rollButton.Enabled = false;
                MessageBox.Show(endTxt);
            }

            resetButton.Enabled = true; // enable reset button at round start

        }// end rollButton_Click



        /// <summary>
        /// The CLICK event corresponds to player's choice between a turn
        /// based system that runs one player at a time, or runs all players
        /// per round.
        /// 
        /// If the yes button is clicked then the player wants to run each of
        /// the turns, for each of the players, one-by-one. 
        /// If the no button is clicked then the player wants to run the game
        /// by the round.
        /// 
        /// 
        /// 
        /// Pre:  the game board waits for the player to make a descision about how 
        /// to run the game.
        /// Post: the game starts, either running round-by-round or player-by-player.
        /// </summary>
        private void noButton_Click(object sender, EventArgs e)
        {
            step = false;
            GroupBox.Enabled = false;
            rollButton.Enabled = true;
        }


        private void yesButton_Click(object sender, EventArgs e)
        {
            step = true;            
            GroupBox.Enabled = false;
            rollButton.Enabled = true;
        }


    }// end class
}
