using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public enum Result { None, Miss, Hit, ShipDestroyed, Victory}

    public class BattleshipGame
    {
        private Player player, turn;
        private ComputerAI computer;
        public BattleshipGame()
        {
            player = new Player(this);
            computer = new ComputerAI(this);
            turn = player;
        }

        public Player Turn
        {
            get { return turn; }
        }


        public Player GetPlayer()
        {
            return player;
        }

        public ComputerAI GetComputer()
        {
            return (ComputerAI)computer;
        }

        public void SwitchTurns()
       {
          if (turn == player)
              turn = computer;

            else if (turn == computer)
                turn = player;
        }

        public Player OtherPlayer(Player player)
        {
            if (player == this.player)
                return computer;

            else if (player == this.computer)
                return player;

            return null;
        }


        public Result Attack(Player attacker, Square s)
        {
            if (!s.WasBombed && turn == attacker)
            {
                Result r = s.Bomb();

                if(r == Result.Miss)
                 SwitchTurns();

                else if (r == Result.ShipDestroyed)
                {
                    turn.ShipDestroyed();

                    if (turn.HasLost())
                    {
                            return Result.Victory;
                    }
                }

                return r;
            }
            return Result.None;
        }

        public void Reset()
        {
            player.Reset();
            computer.Reset();
            turn = player;
        }
    }
}
