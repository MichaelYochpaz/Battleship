using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public class ComputerAI : Player
    {
        private enum Direction
        {
            Unknown,
            Up,
            Down,
            Left,
            Right
        }

        private Random r = new Random();
        private Stack<Direction> directionsStack;
        private Square lastHit, firstHit;
        private Result lastResult;
        private Direction direction;
        const int shipsAmount = 5, minimumShipLength = 2, maximumShipLength = 5;


        public ComputerAI(BattleshipGame bsg) : base(bsg, PlayerType.Computer)
        {
            
            lastResult = Result.None;
            direction = Direction.Unknown;
            PlaceShips();


        }

        public void PlaceShips()
        {
            PlaceShip(Ship.Type.AircraftCarrier, 5);
            PlaceShip(Ship.Type.Battleship, 4);
            PlaceShip(Ship.Type.Cruiser, 3);
            PlaceShip(Ship.Type.Destroyer, 3);
            PlaceShip(Ship.Type.Submarine, 2);
        }

        private void PlaceShip(Ship.Type type, int length)
        {
            Square[] squares = new Square[length];
            int indexI, indexJ;
            int rotate; // 0 = Horizontal, 1 = Vertical
            bool isPossible;

            do
            {
                rotate = r.Next(2);

                if (rotate == 0) // Horizontal
                {
                    indexI = r.Next(0, (GameSettings.Default.BoardSize - length));
                    indexJ = r.Next(0, (GameSettings.Default.BoardSize));
                    isPossible = ((indexI == 0) || (this.board[(indexI - 1), indexJ].GetShip() == null)) && (((indexI + length) == GameSettings.Default.BoardSize) || this.board[(indexI + length), indexJ].GetShip() == null);

                    for (int i = 0; isPossible && i < length; i++)
                    {
                        squares[i] = this.board[indexI + i, indexJ];
                        if ((this.board[indexI + i, indexJ].GetShip() != null) || ((indexJ != 0) && (this.board[indexI + i, (indexJ - 1)].GetShip() != null)) || (((indexJ + 1) != GameSettings.Default.BoardSize) && (this.board[indexI + i, (indexJ + 1)].GetShip() != null)))
                            isPossible = false;
                    }
                }

                else // Vertical
                {
                    indexI = r.Next(0, (GameSettings.Default.BoardSize - 1));
                    indexJ = r.Next(0, (GameSettings.Default.BoardSize - length - 1));
                    isPossible = ((indexJ == 0) || (this.board[indexI, (indexJ - 1)].GetShip() == null)) && (((indexJ + length) == GameSettings.Default.BoardSize) || (this.board[indexI, (indexJ + length)].GetShip() == null));

                    for (int i = 0; isPossible && i < length; i++)
                    {
                        squares[i] = this.board[indexI, indexJ + i];
                        if ((this.board[indexI, indexJ + i].GetShip() != null) || ((indexI != 0) && (this.board[(indexI - 1), indexJ + i].GetShip() != null)) || (((indexI + 1) != GameSettings.Default.BoardSize) && (this.board[(indexI + 1), indexJ + i].GetShip() != null)))
                            isPossible = false;
                    }
                }

            } while (!isPossible);

            AddShip(new Ship(squares, type));
        }

        private void RandomizeStack()
        {
            Direction[] d = { Direction.Down, Direction.Left, Direction.Right, Direction.Up };
            for (int i = d.Length - 1; i > 0; i--)
            {
                int rand = r.Next(i + 1);
                Direction temp = d[i];
                d[i] = d[rand];
                d[rand] = temp;
            }
            directionsStack = new Stack<Direction>(d);
        }

        private bool inTheMiddleOfShip = false;

        static Direction GetOppositeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    return Direction.Up;

                case Direction.Left:
                    return Direction.Right;

                case Direction.Right:
                    return Direction.Left;

                case Direction.Up:
                    return Direction.Down;

                default:
                    throw new Exception();
            }
        }

        Square target;

        public KeyValuePair<Square, Result> Attack()
        {
            if (inTheMiddleOfShip)
            {
                target = null;

                while (target == null)
                {
                    if (direction == Direction.Unknown)
                        direction = directionsStack.Pop();

                    do // Avoid board edges
                    {
                        try
                        {
                            switch (direction)
                            {
                                case Direction.Down:
                                    target = gameManager.GetPlayer().board[lastHit.I + 1, lastHit.J];
                                    break;

                                case Direction.Left:
                                    target = gameManager.GetPlayer().board[lastHit.I, lastHit.J - 1];
                                    break;

                                case Direction.Right:
                                    target = gameManager.GetPlayer().board[lastHit.I, lastHit.J + 1];
                                    break;

                                case Direction.Up:
                                    target = gameManager.GetPlayer().board[lastHit.I - 1, lastHit.J];
                                    break;
                            }

                            break;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            // Looping again with next direction
                            if (directionsStack.Contains(GetOppositeDirection(direction)))
                                direction = GetOppositeDirection(direction);
                            else
                                direction = directionsStack.Pop();
                        }
                    } while (true);

                    // Target is now somewhere in the board

                    if (target.WasBombed && target.GetShip() == null)
                    {
                        if (directionsStack.Contains(GetOppositeDirection(direction)))
                            direction = GetOppositeDirection(direction);
                        else
                            direction = Direction.Unknown;

                        target = null;
                    }
                    else if (target.WasBombed && target.GetShip() != null && !target.GetShip().IsDown())
                    {
                        while (target.WasBombed)
                        {
                            lastHit = target;
                            switch (direction)
                            {
                                case Direction.Down:
                                    target = gameManager.GetPlayer().board[lastHit.I + 1, lastHit.J];
                                    break;

                                case Direction.Left:
                                    target = gameManager.GetPlayer().board[lastHit.I, lastHit.J - 1];
                                    break;

                                case Direction.Right:
                                    target = gameManager.GetPlayer().board[lastHit.I, lastHit.J + 1];
                                    break;

                                case Direction.Up:
                                    target = gameManager.GetPlayer().board[lastHit.I - 1, lastHit.J];
                                    break;
                            }
                        }
                        // Now targets points at the next not bombed square
                    }
                }

                lastResult = gameManager.Attack(this, target);

                if (lastResult == Result.Hit)
                {
                    lastHit = target;
                }
                else if (lastResult == Result.Miss)
                {
                    if (directionsStack.Contains(GetOppositeDirection(direction)))
                        direction = GetOppositeDirection(direction);
                    else
                        direction = Direction.Unknown;
                }
                else if (lastResult == Result.ShipDestroyed)
                {
                    lastHit = null;
                    inTheMiddleOfShip = false;
                    direction = Direction.Unknown;
                }
                else if (lastResult == Result.Victory)
                {

                }
                else if (lastResult == Result.None)
                {
                    throw new Exception();
                }
            }

            else
            {
                int i, j;

                do
                {
                    i = r.Next(0, board.GetLength(0));
                    j = r.Next(0, board.GetLength(1));

                    target = gameManager.GetPlayer().board[i, j];
                }
                while (target.WasBombed);

                direction = Direction.Unknown;
                lastResult = gameManager.Attack(this, target);

                if (lastResult == Result.Hit)
                {
                    RandomizeStack();
                    firstHit = target;
                    lastHit = target;
                    inTheMiddleOfShip = true;
                }
            }

            return new KeyValuePair<Square, Result>(target, lastResult);
        }

        public override void Reset()
        {
            base.Reset();
            lastResult = Result.None;
            direction = Direction.Unknown;
            PlaceShips();
            inTheMiddleOfShip = false;
        }
    }
}
