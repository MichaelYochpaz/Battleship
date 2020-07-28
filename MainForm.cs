using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Battleship
{
    public partial class MainForm : Form
    {
        public BattleshipGame gameManager;
        private Player player;
        private ComputerAI computer;
        private GraphicSquare[,] playerGraphicBoard, computerGraphicBoard;
        private GraphicSquare[] markedGraphicSquares;
        private GraphicSquare gs;
        private ShipBox[] shipsBoxes;
        private Stack<GraphicSquare[]> placedShips;
        private Stack<ShipBox> placedShipsBoxes;
        private Square[] markedSquares;
        private Square computersAttackSquare;
        private Result playersResult, computersResult;
        private SoundPlayer backgroundTheme, shipHorn, hitWater, hitShip, shipExplosion, win, lose;
        private ShipBox selectedShip;
        private Random r = new Random();
        private int playerTurnsCount, computerTurnsCount;
        private bool gameStarted, possibleToPlaceShip, debugMode, sound;

        public MainForm()
        {
            InitializeComponent();
            this.Size = new Size(308, 315);
            this.BackgroundImageLayout = ImageLayout.Center;
            backgroundTheme = new SoundPlayer(Properties.Resources.BackgroundTheme);
            backgroundTheme.PlayLooping();

            placedShips = new Stack<GraphicSquare[]>();
            placedShipsBoxes = new Stack<ShipBox>();
            selectedShip = null;
            shipHorn = new SoundPlayer(Properties.Resources.ShipHorn);
            hitWater = new SoundPlayer(Properties.Resources.HitWater);
            hitShip = new SoundPlayer(Properties.Resources.HitShip);
            shipExplosion = new SoundPlayer(Properties.Resources.ShipExplosion);
            win = new SoundPlayer(Properties.Resources.Win);
            lose = new SoundPlayer(Properties.Resources.Lose);
            playerTurnsCount = 0;
            computerTurnsCount = 0;
            gameStarted = false;
            possibleToPlaceShip = false;
            debugMode = false;
            sound = true;
        }

        async Task Delay()
        {
            await Task.Delay(r.Next(200, 1000));
        }

        public void StartGame(bool firstTime = false)
        {
            if (firstTime)
            {
                playButton.Hide();
                this.BackgroundImage = Properties.Resources.background2;
                soundButton.Location = new Point(1012, 0);
                soundButton.Show();
                this.Update();
                this.BackColor = SystemColors.Control;
                gameManager = new BattleshipGame();
                this.player = gameManager.GetPlayer();
                this.computer = gameManager.GetComputer();
                DrawBoard();
            }

            else
            {
                placedShips.Clear();
                placedShipsBoxes.Clear();
                computerTurnsCount = 0;
                computersTurnsCountLabel.Text = computerTurnsCount.ToString();
                computersTurnsCountLabel.Hide();
                playerTurnsCount = 0;
                playersTurnsCountLabel.Text = playerTurnsCount.ToString();
                playersTurnsCountLabel.Hide();
                possibleToPlaceShip = false;
                debugModeToolStripMenuItem.Enabled = false;
                backwardButton.Enabled = true;

                gameStarted = false;

                foreach (GraphicSquare gs in computerGraphicBoard)
                    gs.Clickable = false;

                gameManager.Reset();

                foreach (GraphicSquare temp in computerGraphicBoard)
                    temp.Reset();

                foreach (GraphicSquare temp in playerGraphicBoard)
                    temp.Reset();

                for (int i = 0; i < shipsBoxes.Length; i++)
                {
                    shipsBoxes[i].Reset();
                    shipsBoxes[i].Enabled = true;
                }

                startButton.Enabled = true;
            }
        }

        private void StartGame2() // Called when all shipsBoxes are placed and game can be started.
        {
            gameStarted = true;
            startButton.Enabled = false;
            backwardButton.Enabled = false;
            computersTurnLabel.Show();
            computersTurnsCountLabel.Show();
            playersTurnsLabel.Show();
            playersTurnsCountLabel.Show();

            for (int i = 0; i < shipsBoxes.Length; i++)
                shipsBoxes[i].Enabled = false;

            if (sound)
                shipHorn.Play();

            debugModeToolStripMenuItem.Enabled = true;

            foreach (GraphicSquare gs in computerGraphicBoard)
                gs.Clickable = true;
        }

        private void DrawBoard()
        {
            this.Width = GameSettings.Default.BoardSize * (GameSettings.Default.ButtonSize + GameSettings.Default.SpaceBetweenButtons) + (GameSettings.Default.SpaceBetweenButtons + GameSettings.Default.ButtonSize) * GameSettings.Default.BoardSize + GameSettings.Default.SpaceBetweenBoards + GameSettings.Default.LeftSpacing + GameSettings.Default.RightSpacing + 15;
            this.Height = GameSettings.Default.BoardSize * (GameSettings.Default.ButtonSize + GameSettings.Default.SpaceBetweenButtons) + GameSettings.Default.TopSpacing + GameSettings.Default.ButtomSpacing + 40;
            playerGraphicBoard = new GraphicSquare[GameSettings.Default.BoardSize, GameSettings.Default.BoardSize];
            computerGraphicBoard = new GraphicSquare[GameSettings.Default.BoardSize, GameSettings.Default.BoardSize];
            this.CenterToScreen();

            for (int i = 0; i < GameSettings.Default.BoardSize; i++)
                for (int j = 0; j < GameSettings.Default.BoardSize; j++)
                {
                    computerGraphicBoard[i, j] = new GraphicSquare(i, j, computer.GetSquare(i, j), false);
                    computerGraphicBoard[i, j].Click += new EventHandler(computerBoard_Click);
                    computerGraphicBoard[i, j].Left = GameSettings.Default.LeftSpacing + j * (GameSettings.Default.ButtonSize + GameSettings.Default.SpaceBetweenButtons);
                    computerGraphicBoard[i, j].Top = GameSettings.Default.TopSpacing + i * (GameSettings.Default.ButtonSize + GameSettings.Default.SpaceBetweenButtons);
                    playerGraphicBoard[i, j] = new GraphicSquare(i, j, player.GetSquare(i, j), false);
                    playerGraphicBoard[i, j].Click += new EventHandler(playerBoard_Click);
                    playerGraphicBoard[i, j].MouseEnter += new EventHandler(playerBoard_MouseEnter);
                    playerGraphicBoard[i, j].MouseLeave += new EventHandler(playerBoard_MouseLeave);
                    playerGraphicBoard[i, j].Left = GameSettings.Default.LeftSpacing + j * (GameSettings.Default.ButtonSize + GameSettings.Default.SpaceBetweenButtons) + (GameSettings.Default.SpaceBetweenButtons + GameSettings.Default.ButtonSize) * GameSettings.Default.BoardSize + GameSettings.Default.SpaceBetweenBoards;
                    playerGraphicBoard[i, j].Top = GameSettings.Default.TopSpacing + i * (GameSettings.Default.ButtonSize + GameSettings.Default.SpaceBetweenButtons);
                    Controls.Add(playerGraphicBoard[i, j]);
                    Controls.Add(computerGraphicBoard[i, j]);
                }

            DrawShipButtons();
        }

        private void DrawShipButtons()
        {
            shipsBoxes = new ShipBox[5];
            shipsBoxes[0] = new ShipBox(Ship.Type.AircraftCarrier);
            shipsBoxes[0].Location = new System.Drawing.Point(32, 619);
            shipsBoxes[1] = new ShipBox(Ship.Type.Battleship);
            shipsBoxes[1].Location = new System.Drawing.Point(209, 619);
            shipsBoxes[2] = new ShipBox(Ship.Type.Cruiser);
            shipsBoxes[2].Location = new System.Drawing.Point(385, 619);
            shipsBoxes[3] = new ShipBox(Ship.Type.Destroyer);
            shipsBoxes[3].Location = new System.Drawing.Point(559, 619);
            shipsBoxes[4] = new ShipBox(Ship.Type.Submarine);
            shipsBoxes[4].Location = new System.Drawing.Point(738, 619);

            for (int i = 0; i < shipsBoxes.Length; i++)
            {
                shipsBoxes[i].Click += new System.EventHandler(this.shipPictureBox_Click);
                this.Controls.Add(shipsBoxes[i]);
            }
        }

        public void PlaySound(Result r)
        {
            if (sound)
                switch (r)
                {
                    case Result.Miss:
                        hitWater.Play();
                        break;

                    case Result.Hit:
                        hitShip.Play();
                        break;

                    case Result.ShipDestroyed:
                    case Result.Victory:
                        shipExplosion.Play();
                        break;
                }
        }

        public void DebugMode(bool on)
        {
            if (on && !debugMode)
            {
                for (int i = 0; i < computerGraphicBoard.GetLength(0); i++)
                    for (int j = 0; j < computerGraphicBoard.GetLength(1); j++)
                        computerGraphicBoard[i, j].DebugMode();

                debugModeToolStripMenuItem.Text = "Turn Debug Mode Off";
                debugMode = true;
            }

            else if (!on && debugMode)
            {
                for (int i = 0; i < computerGraphicBoard.GetLength(0); i++)
                    for (int j = 0; j < computerGraphicBoard.GetLength(1); j++)
                        computerGraphicBoard[i, j].NormalMode();

                debugMode = false;
                debugModeToolStripMenuItem.Text = "Turn Debug Mode On";
            }
        }

        private bool PossibleToPlaceShip(GraphicSquare[] squares, bool horizontal)
        {
            for (int i = 0; i < squares.Length; i++)
                if ((squares[i] == null) || (squares[i].GetSquare().GetShip() != null) || !checkSurroundingSquares(squares, horizontal))
                    return false;

            return true;
        }

        private bool checkSurroundingSquares(GraphicSquare[] squares, bool horizontal)
        {
            if (horizontal)
            {
                // Left Square
                if (squares[0] != null && squares[0].GetJ() - 1 >= 0 && player.board[squares[0].GetI(), squares[0].GetJ() - 1].GetShip() != null)
                    return false;
                // Right Square
                if (squares[squares.Length - 1] != null && squares[squares.Length - 1].GetJ() + 1 < GameSettings.Default.BoardSize && player.board[squares[squares.Length - 1].GetI(), squares[squares.Length - 1].GetJ() + 1].GetShip() != null)
                    return false;

                for (int i = 0; i < squares.Length; i++)
                {
                    if (squares[i] == null)
                        return false;

                    // Lower Squares
                    if (squares[i].GetI() - 1 >= 0 && player.board[squares[i].GetI() - 1, squares[i].GetJ()].GetShip() != null)
                        return false;

                    // Upper Squares
                    if (squares[i].GetI() + 1 < GameSettings.Default.BoardSize && player.board[squares[i].GetI() + 1, squares[i].GetJ()].GetShip() != null)
                        return false;
                }
            }
            else
            {
                // Top Square
                if (squares[0] != null && squares[0].GetI() - 1 >= 0 && player.board[squares[0].GetI() - 1, squares[0].GetJ()].GetShip() != null)
                    return false;

                // Bottom Square
                if (squares[squares.Length - 1] != null && squares[squares.Length - 1].GetI() + 1 < GameSettings.Default.BoardSize && player.board[squares[squares.Length - 1].GetI() + 1, squares[squares.Length - 1].GetJ()].GetShip() != null)
                    return false;

                for (int i = 0; i < squares.Length; i++)
                {
                    if (squares[i] == null)
                        return false;

                    // Left Squares
                    if (squares[i].GetJ() - 1 >= 0 && player.board[squares[i].GetI(), squares[i].GetJ() - 1].GetShip() != null)
                        return false;

                    // Right Squares
                    if (squares[i].GetJ() + 1 < GameSettings.Default.BoardSize && player.board[squares[i].GetI(), squares[i].GetJ() + 1].GetShip() != null)
                        return false;
                }
            }
            return true;
        }

        private ShipBox GetShipsBoxByShip(Ship s)
        {
            switch (s.ShipType)
            {
                case Ship.Type.AircraftCarrier:
                    return shipsBoxes[0];

                case Ship.Type.Battleship:
                    return shipsBoxes[1];

                case Ship.Type.Cruiser:
                    return shipsBoxes[2];

                case Ship.Type.Destroyer:
                    return shipsBoxes[3];

                case Ship.Type.Submarine:
                    return shipsBoxes[4];
            }
            return null;
        }

        public void UpdateShipDestroyed(Player.PlayerType type, Ship s)
        {
            Square[] squares = s.Squares;

            for (int i = 0; i < squares.Length; i++)
            {
                switch (type)
                {
                    case Player.PlayerType.Player:
                        computerGraphicBoard[squares[i].I, squares[i].J].ShipDestroyed();
                        break;

                    case Player.PlayerType.Computer:
                        playerGraphicBoard[squares[i].I, squares[i].J].ShipDestroyed();
                        GetShipsBoxByShip(s).Lock();
                        break;
                }
            }
        }

        private void DeselectOtherShipBoxes(ShipBox sb)
        {
            for (int i = 0; i < shipsBoxes.Length; i++)
                if (shipsBoxes[i] != sb)
                    shipsBoxes[i].Reset(true);
        }

        public void GameEnded(Player winner)
        {
            ResultMessageForm rmf = null;
            Cursor.Show();

            if (winner == player)
                rmf = new ResultMessageForm(this, Player.PlayerType.Player);

            else if (winner == computer)
                rmf = new ResultMessageForm(this, Player.PlayerType.Computer);

            rmf.Show();
        }



        private void MainForm_Click(object sender, EventArgs e)
        {
            if (selectedShip != null)
            {
                MouseEventArgs temp = (MouseEventArgs)e;

                if (temp.Button == MouseButtons.Right)
                    selectedShip.Rotate();
            }
        }

        private void playButton_MouseClick(object sender, EventArgs e)
        {
            StartGame(true);
        }

        private void soundButton_Click(object sender, EventArgs e)
        {
            if (sound)
            {
                sound = false;
                backgroundTheme.Stop();
                soundButton.Image = Properties.Resources.soundOnIcon;
            }

            else
            {
                sound = true;
                soundButton.Image = Properties.Resources.soundOffIcon;
            }
        }

        private void shipPictureBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs temp = (MouseEventArgs)e;
            ShipBox shipBox = (ShipBox)sender;

            if (temp.Button == MouseButtons.Left && selectedShip != shipBox)
            {
                shipBox.BorderStyle = BorderStyle.FixedSingle;
                DeselectOtherShipBoxes(shipBox);
                this.selectedShip = shipBox;
            }

            else if (temp.Button == MouseButtons.Right && selectedShip != null && selectedShip.Type == shipBox.Type)
                shipBox.Rotate();
        }

        private void backwardButton_Click(object sender, EventArgs e)
        {
            if (placedShips.Count > 0)
            {
                GraphicSquare[] gs = placedShips.Pop();
                for (int i = 0; i < gs.Length; i++)
                {
                    gs[i].Reset();
                    gs[i].GetSquare().SetShip(null);
                }
                player.ShipRemoved();
                placedShipsBoxes.Pop().Reset();
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (player.AllShipsSet())
            {
                for (int i = 0; i < shipsBoxes.Length; i++)
                    shipsBoxes[i].Reset();

                StartGame2();
            }

            else
                MessageBox.Show("You have to place all ships on your board first.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void computerBoard_Click(Object sender, EventArgs e)
        {
            gs = (GraphicSquare)sender;
            MouseEventArgs temp = (MouseEventArgs)e;

            if (!gameStarted && temp.Button == MouseButtons.Right && selectedShip != null)
            {
                selectedShip.Rotate();
            }


            else if (gameStarted && gs.Clickable && !gs.Clicked)
            {
                playersResult = gameManager.Attack(player, gs.GetSquare());

                if (playersResult != Result.None)
                {
                    playerTurnsCount++;
                    playersTurnsCountLabel.Text = playerTurnsCount.ToString();

                    gs.Attack();

                    if (playersResult == Result.ShipDestroyed || playersResult == Result.Victory)
                    {
                        UpdateShipDestroyed(Player.PlayerType.Player, gs.GetSquare().GetShip());

                        if (playersResult == Result.Victory)
                        {
                            foreach (GraphicSquare temp2 in computerGraphicBoard)
                                temp2.Clickable = false;

                            if (sound)
                                win.Play();

                            GameEnded(player);
                        }
                    }

                    PlaySound(playersResult);

                    #region Computer's Play
                    if (playersResult == Result.Miss)
                    {
                        do
                        {
                            await Delay();
                            KeyValuePair<Square, Result> values = computer.Attack();
                            computersAttackSquare = values.Key;
                            computersResult = values.Value;
                            playerGraphicBoard[computersAttackSquare.I, computersAttackSquare.J].Attack();

                            if (computersResult == Result.ShipDestroyed)
                                UpdateShipDestroyed(Player.PlayerType.Computer, computersAttackSquare.GetShip());

                            PlaySound(computersResult);
                            this.Update(); //?

                            computerTurnsCount++;
                            computersTurnsCountLabel.Text = computerTurnsCount.ToString();

                        } while (computersResult != Result.Miss && computersResult != Result.Victory);

                        if (computersResult == Result.Victory)
                        {
                            UpdateShipDestroyed(Player.PlayerType.Computer, computersAttackSquare.GetShip());
                            this.Update();

                            if (sound)
                                lose.Play();

                            GameEnded(computer);
                        }
                    }
                    #endregion

                }
            }
        }

        private void playerBoard_Click(Object sender, EventArgs e)
        {
            gs = (GraphicSquare)sender;
            MouseEventArgs temp = (MouseEventArgs)e;

            if (!gameStarted && temp.Button == MouseButtons.Right && selectedShip != null)
                selectedShip.Rotate();

            else if (!gameStarted && temp.Button == MouseButtons.Left && selectedShip != null)
            {
                if (possibleToPlaceShip)
                {
                    markedSquares = new Square[markedGraphicSquares.Length];

                    for (int i = 0; i < markedGraphicSquares.Length; i++)
                    {
                        markedSquares[i] = markedGraphicSquares[i].GetSquare();
                        markedGraphicSquares[i].Image = Properties.Resources.shipMark;
                    }

                    // A clone is needed because Stack pushes a pointer and not a value.
                    placedShips.Push((GraphicSquare[])markedGraphicSquares);
                    placedShipsBoxes.Push(selectedShip);
                    player.AddShip(new Ship(markedSquares, selectedShip.Type));
                    selectedShip.Lock();
                    selectedShip = null;
                }

                else
                {
                    MessageBox.Show("You can't place the ship here.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void playerBoard_MouseEnter(Object sender, EventArgs e)
        {
            if (!gameStarted && selectedShip != null)
            {
                gs = (GraphicSquare)sender;
                markedGraphicSquares = new GraphicSquare[selectedShip.Length()];

                if (selectedShip.Rotated)
                {
                    for (int i = 0; i < selectedShip.Length(); i++)
                        try
                        {
                            markedGraphicSquares[i] = playerGraphicBoard[gs.GetI() - (selectedShip.Length() / 2) + i, gs.GetJ()];
                        }

                        catch
                        {
                            markedGraphicSquares[i] = null;
                        }
                }

                else
                {
                    for (int i = 0; i < selectedShip.Length(); i++)
                        try
                        {
                            markedGraphicSquares[i] = playerGraphicBoard[gs.GetI(), gs.GetJ() - (selectedShip.Length() / 2) + i];
                        }
                        catch
                        {
                            markedGraphicSquares[i] = null;
                        }
                }

                if (PossibleToPlaceShip(markedGraphicSquares, !selectedShip.Rotated))
                {
                    for (int i = 0; i < markedGraphicSquares.Length; i++)
                        markedGraphicSquares[i].Mark(false);

                    possibleToPlaceShip = true;
                }

                else
                {
                    for (int i = 0; i < markedGraphicSquares.Length; i++)
                        if (markedGraphicSquares[i] != null)
                            markedGraphicSquares[i].Mark(true);
                }
            }
        }

        private void playerBoard_MouseLeave(Object sender, EventArgs e)
        {
            if (markedGraphicSquares != null)
                for (int i = 0; i < markedGraphicSquares.Length; i++)
                    if (markedGraphicSquares[i] != null)
                        markedGraphicSquares[i].Reset(true);

            possibleToPlaceShip = false;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugMode(false);
            selectedShip = null;
            StartGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm frm = new AboutForm();
            frm.Show();
        }

        private void debugModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                if (debugModeToolStripMenuItem.Text == ("Turn Debug Mode On"))
                    DebugMode(true);

                else
                    DebugMode(false);
            }
        }
    }
}
