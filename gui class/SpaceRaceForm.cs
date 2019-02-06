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

        // Initialize variables
        bool stepState, stepEnd, roundEnd; 
        int countPlayer, fuelEmptyCount;
        string endTxt, fueloutTxt;

        // Run all initializing methods
        public SpaceRaceForm()
        {
            initializeGlobalVariables();
            InitializeComponent();
            Board.SetUpBoard();
            ResizeGUIGameBoard();
            SetUpGUIGameBoard();
            SetupPlayersDataGridView();
            DetermineNumberOfPlayers();
            SpaceRaceGame.SetUpPlayers();
            PrepareToPlay();
        }// end SpaceRaceForm


        /// <summary>
        /// Handle the Exit button being clicked.
        /// 
        /// Pre:  the Exit button is clicked.
        /// Post: the game is terminated immediately
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }// end exitButton_Click


        /// <summary>
        /// Resizes the entire form, so that the individual squares have their correct size, 
        /// as specified by SquareControl.SQUARE_SIZE.  
        /// This method allows us to set the entire form's size to approximately correct value 
        /// when using Visual Studio's Designer, rather than having to get its size correct to the last pixel.
        /// 
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

        }// end ResizeGUIGameBoard


        /// <summary>
        /// Creates a SquareControl for each square and adds it to the appropriate square of the tableLayoutPanel.
        /// 
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


        /// <summary>
        /// Controls the table layout resizing.
        /// </summary>
        private void AddControlToTableLayoutPanel(Control control, int squareNum)
        {
            int screenRow = 0;
            int screenCol = 0;
            MapSquareNumToScreenRowAndColumn(squareNum, out screenRow, out screenCol);
            tableLayoutPanel.Controls.Add(control, screenCol, screenRow);
        }// end AddControlToTableLayoutPanel


        /// <summary>
        /// For a given square number, tells you the corresponding row and column number
        /// on the TableLayoutPanel.
        /// 
        /// Pre:  none.
        /// Post: returns the row and column numbers, via "out" parameters.
        /// </summary>
        /// 
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


        /// <summary>
        /// Initializes the data grid with the player data.
        /// </summary>
        private void SetupPlayersDataGridView()
        {
            // Stop the playersDataGridView from using all Player columns.
            playersDataGridView.AutoGenerateColumns = false;
            // Tell the playersDataGridView what its real source of data is.
            playersDataGridView.DataSource = SpaceRaceGame.Players;

        }//end SetUpPlayersDataGridView


        /// <summary>
        /// Obtains the current "selected item" from the ComboBox
        ///  and
        ///  sets the NumberOfPlayers in the SpaceRaceGame class.
        ///  
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

        }//end PrepareToPlay


        /// <summary>
        /// Tells you which SquareControl object is associated with a given square number.
        /// 
        /// Pre:  a valid squareNumber is specified; and
        ///       the tableLayoutPanel is properly constructed.
        /// Post: the SquareControl object associated with the square number is returned.
        /// </summary>
        /// 
        /// <param name="squareNumber">The square number.</param>
        /// <returns>Returns the SquareControl object associated with the square number.</returns>
        private SquareControl SquareControlAt(int squareNum)
        {
            int screenRow;
            int screenCol;

            MapSquareNumToScreenRowAndColumn(squareNum, out screenRow, out screenCol);
            return (SquareControl)tableLayoutPanel.GetControlFromPosition(screenCol, screenRow);
        }//end SquareControlAt


        /// <summary>
        /// Tells you the current square number of a given player.
        /// 
        /// Pre:  a valid playerNumber is specified.
        /// Post: the square number of the player is returned.
        /// </summary>
        /// 
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
        /// 
        /// Pre:  none.
        /// Post: the board's TableLayoutPanel shows the latest information 
        ///       from the collection of SquareControl objects in the TableLayoutPanel.
        /// </summary>
        private void RefreshBoardTablePanelLayout()
        {
            // Uncomment the following line once you've added the tableLayoutPanel to your form.
                  tableLayoutPanel.Invalidate(true);
        }//end RefreshBoardTablePanelLayout


        /// <summary>
        /// When the Player objects are updated (location, etc),
        /// the players DataGridView is not updated immediately.  
        /// Each time that those player objects are updated, this method must be called 
        /// so that the players DataGridView is told to refresh what it is displaying.
        /// 
        /// Pre:  none.
        /// Post: the players DataGridView shows the latest information 
        ///       from the collection of Player objects in the SpaceRaceGame.
        /// </summary>
        private void UpdatesPlayersDataGridView()
        {
            SpaceRaceGame.Players.ResetBindings();
        }//end UpdatesPlayersDataGridView


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


        /// <summary>
        /// The event handler for the table.
        /// This was accidentally placed here, but then not 
        /// removed. This piece of code has no functionality.
        /// </summary>
        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }//end tableLayoutPanel_Paint


        /// <summary>
        /// This method selects the number of players from the combo box.
        /// The user can select between 2-6 players, based on the options in the 
        /// combo box. This will upate the list in the GUI and the number of 
        /// counters on the board.
        /// 
        /// Pre: Default number of players is selected as six. 
        /// Post: User selected numbed of player is selected.
        /// </summary>
        private void numOfPlayersInput_SelectedIndexChanged(object sender, EventArgs e)
        {

            UpdatePlayersGuiLocations(TypeOfGuiUpdate.RemovePlayer);
            DetermineNumberOfPlayers(); // set number of players
            numOfPlayersInput.Enabled = false; // disable comboBox
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);
            rollButton.Enabled = false;
            GroupBox.Enabled = true;

        }//end numOfPlayersInput_SelectedIndexChanged


        /// <summary>
        /// The event handler for the rest button.
        /// 
        /// The rest button can be used at any time when the game is not currently
        /// running, or at any interval between rounds. The reset button does
        /// a full board reset, returning the user to the radio button selection,
        /// and setitng the number of players to six.
        /// 
        /// Pre:  The user must either be between rounds or outside of the running game.
        /// Post: Full board reset.
        /// </summary>
        private void resetButton_Click(object sender, EventArgs e)
        {

            numOfPlayersInput.SelectedIndex = 4; // Default combBox of "6 players"

            UpdatePlayersGuiLocations(TypeOfGuiUpdate.RemovePlayer); // reset gameboard

            // Reset Player Values to Default
            countPlayer = 0; // reset single step player counter
            SetupPlayersDataGridView(); 
            DetermineNumberOfPlayers();
            SpaceRaceGame.SetUpPlayers();
            PrepareToPlay();
            initializeGlobalVariables();

            // Allow play and player number selection
            rollButton.Enabled = false;
            GroupBox.Enabled = true;
            numOfPlayersInput.Enabled = true;
            yesButton.Checked = false;
            noButton.Checked = false;
            resetButton.Enabled = false;

        }//end resetButton_Click


        /// <summary>
        /// The event handler for the roll button. 
        /// 
        /// The roll button is the primary button responsible for playing the space
        /// race game. Each press of the roll button rolls two die, which are 
        /// then used to update the locations of each of the player. Once the players
        /// finish the game the roll button is switched off.
        /// 
        /// Pre:  Once the user selects either "yes" or "no" the user can begin the game
        /// by pressing the roll button.
        /// Post: Once the roll button is pushed the user sees the counters' location being updated.
        /// </summary>
        private void rollButton_Click(object sender, EventArgs e)
        {
            bool gameEnd = false;
            

            numOfPlayersInput.Enabled = false; // disable comboBox
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.RemovePlayer); // reset player locations

            // Play Single-step or One Round
            if (stepState) // if the stepstate is true i.e. per player play.
            {
                gameEnd = GameEndReturn_PerPlayer(ref gameEnd);
            }

            else // if the stepstate is false i.e. per round play.
            {
                gameEnd = GameEndReturn_PerRound(ref gameEnd);
            }
            
            // Update player positions for StepPlay or PlayOneRound
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);
            // Update player data grid for StepPlay or PlayOneRound
            UpdatesPlayersDataGridView();
                        
            if (roundEnd)
            {
                resetButton.Enabled = true; // enable reset button at round start
                exitButton.Enabled = true; // enable exit button at round start
            }
            else
            {
                resetButton.Enabled = false; // disable reset button at round start
                exitButton.Enabled = false; // disable exit button at round start
            }

            // Display a message if the player has either run out of fuel
            // or finished the game.
            DisplayMessage(gameEnd, fuelEmptyCount);

        }//end rollButton_Click


        /// <summary>
        /// The event handler for the "no" option for the radio buttons.
        /// 
        /// Pre: Before either "no" or "yes" is selected the game waits 
        /// for the user to select an option.
        /// Post: After selecting "no" the user starts the "by round" game option,
        /// where each press of the roll button moves all players.
        /// </summary>
        private void noButton_Click(object sender, EventArgs e)
        {
            stepState = false;
            numOfPlayersInput.Enabled = false;
            GroupBox.Enabled = false;
            rollButton.Enabled = true;
        } //end noButton_Click


        /// <summary>
        /// The event handler for "yes" option for the radio buttons.
        /// 
        /// Pre: Before either "no" or "yes" is selected the game waits 
        /// for the user to select an option.
        /// Post: After selecting "yes" the user starts the "by player game" option,
        /// where each press of the roll button moves a single player.
        /// </summary>
        private void yesButton_Click(object sender, EventArgs e)
        {
            stepState = true;
            numOfPlayersInput.Enabled = false;
            GroupBox.Enabled = false;
            rollButton.Enabled = true;
        } //end yesButton_Click


        /// <summary>
        /// This method initializes all global variables with
        /// appropriate intial state values.
        /// 
        /// Pre:  All variables are declared, but do not have values.
        /// Post: All variables have initial state values.
        /// </summary>
        public void initializeGlobalVariables()
        {
            stepState = false; // states for single step play and gameEnd
            stepEnd = false;
            countPlayer = 0; // player counter for single step play
            endTxt = "The following player(s) finished the game\n";
            fueloutTxt = "All players are out of fuel. Game over!";
            fuelEmptyCount = 0;
            roundEnd = false;
        } //end initializeGlobalVariables


        /// <summary>
        ///  This method employs the per player gameplay, selected
        ///  from the radio button option "yes". Each click 
        ///  of the roll button acts on an individual player.
        ///  
        /// Pre:  Player selects "uyes" for the radio button option.
        /// Post: Game is evolved, per player, each time the roll button is pressed.
        /// </summary>
        /// 
        /// <param name="gameEnd">The end game state.</param>
        /// <returns>Returns the game state.</returns>
        private bool GameEndReturn_PerPlayer(ref bool gameEnd)
        {
            // Reset player count if new round
            if (countPlayer == SpaceRaceGame.NumberOfPlayers)
            {
                countPlayer = 0;
                fuelEmptyCount = 0;

            }
            
            // test if the round has ended, to pass to the reset button
            if (countPlayer == SpaceRaceGame.NumberOfPlayers-1)
            {
                roundEnd = true;

            }
            else
            {
                roundEnd = false;
            }


            // Single-step for player "CountPlayer"
            SpaceRaceGame.StepPlayer(countPlayer, die1, die2);


            // Player End test - Step Play
            if (SpaceRaceGame.Players[countPlayer].AtFinish)
            {
                endTxt += String.Format("\t{0}", SpaceRaceGame.names[countPlayer]);
                stepEnd = true;
            }


            // Game End test - Step Play
            if ((countPlayer == (SpaceRaceGame.NumberOfPlayers - 1) && stepEnd))
            {
                gameEnd = true;
            }

            //
            if (SpaceRaceGame.Players[countPlayer].RocketFuel == 0)
            {
                fuelEmptyCount++;
            }

            countPlayer++; // increment player to take a step   

            return gameEnd;
        } //end GameEndReturn_PerPlayer


        /// <summary>
        /// This method lets the player play the game on a per round basis.
        /// One click of the roll button now acts upon every player, and each
        /// click is a new roudn.
        /// 
        /// Pre:  Player selects "no" for the radio button option.
        /// Post: Game is evolved, per round, as the roll button is pushed
        /// </summary>
        /// 
        /// <param name="gameEnd">The end game state.</param>
        /// <returns>Returns the game state.</returns>
        private bool GameEndReturn_PerRound(ref bool gameEnd)
        {
            // Play One Round
            roundEnd = true;
            SpaceRaceGame.PlayOneRound(die1, die2);
            fuelEmptyCount = 0;

            // Game End test - Play One Round
            for (int i = 0; i < SpaceRaceGame.NumberOfPlayers; i++)// for each player
            {
                // Test if player is at Finish update endTxt and gameEnd
                if (SpaceRaceGame.Players[i].AtFinish)
                {
                    gameEnd = true;
                    endTxt += String.Format("\t{0}", SpaceRaceGame.names[i]);
                }

                if (SpaceRaceGame.Players[i].RocketFuel == 0)
                {
                    fuelEmptyCount++;
                }

            }

            return gameEnd;
        } //end GameEndReturn_PerRound


        /// <summary>
        /// This method constructs the message box that is presented at the end
        /// of the game, and declares which player (if any) have won.
        /// 
        /// Pre: players finish a game.
        /// Post: player are presented with a message box that tells
        /// them who, if anyone, has won the game.
        /// </summary>
        private void DisplayMessage(bool gameEnd, int fuelEmptyCount)
        {
            // Game End Message: Players win the game
            if (gameEnd) // Show player finished method if any player Finishes
            {
                rollButton.Enabled = false;
                MessageBox.Show(endTxt);

            }

            // Game End Message: Run out of fuel.
            if (fuelEmptyCount == SpaceRaceGame.NumberOfPlayers)
            {
                rollButton.Enabled = false;
                MessageBox.Show(fueloutTxt);
            }
        } //end DisplayMessage

    }//end SpaceRaceForm class
}
