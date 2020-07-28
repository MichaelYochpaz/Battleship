using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Battleship
{
    public class Player
    {
        public enum PlayerType {Player, Computer}
        public Square[,] board;
        public readonly PlayerType Type;
        protected BattleshipGame gameManager;
        protected int shipsIndex, shipsDestroyedCount;

        public Player(BattleshipGame bsg)
        {
            this.gameManager = bsg;
            this.Type = PlayerType.Player;
            board = new Square[GameSettings.Default.BoardSize, GameSettings.Default.BoardSize];

            for (int i = 0; i < GameSettings.Default.BoardSize; i++)
                for (int j = 0; j < GameSettings.Default.BoardSize; j++)
                    board[i, j] = new Square(i, j);

            shipsIndex = 0;
            shipsDestroyedCount = 0;
        }

        public Player(BattleshipGame bsg, PlayerType type) // for ComputerAI class
        {
            this.gameManager = bsg;
            this.Type = type;
            board = new Square[GameSettings.Default.BoardSize, GameSettings.Default.BoardSize];

            for (int i = 0; i < GameSettings.Default.BoardSize; i++)
                for (int j = 0; j < GameSettings.Default.BoardSize; j++)
                    board[i, j] = new Square(i, j);

            shipsIndex = 0;
        }

        public Square GetSquare(int x, int y)
        {
            return board[x, y];
        }

        public bool IsHit(Square s)
        {
            return (board[s.I, s.J].GetShip() != null);
        }

        public bool AllShipsSet()
        {
            return (shipsIndex == GameSettings.Default.AmountOfShips);
        }

        public bool HasLost()
        {
            return (shipsDestroyedCount == GameSettings.Default.AmountOfShips);
        }

        public void AddShip(Ship ship)
        {
            if (shipsIndex < (GameSettings.Default.AmountOfShips))
            {
                shipsIndex++;

                Square[] s = ship.Squares;
                for (int i = 0; i < s.Length; i++)
                    s[i].SetShip(ship);
            }
        }

        public void ShipRemoved()
        {
            shipsIndex--;
        }

        public void ShipDestroyed()
        {
            shipsDestroyedCount++;
        }

        public virtual void Reset()
        {
            for (int i = 0; i < GameSettings.Default.BoardSize; i++)
                for (int j = 0; j < GameSettings.Default.BoardSize; j++)
                    board[i, j].Reset();

            shipsIndex = 0;
            shipsDestroyedCount = 0;
        }
    }
}
