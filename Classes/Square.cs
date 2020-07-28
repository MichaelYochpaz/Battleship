using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Square
    {
        readonly int i, j;
        private Ship ship; 
        private bool wasBombed;

        public Square(int i, int j, Ship ship = null)
        {
            this.ship = null;
            this.i = i;
            this.j = j;
            wasBombed = false;
        }

        public void SetShip(Ship ship)
        {
            this.ship = ship;
        }

        public Result Bomb()
        {
            this.wasBombed = true;

            if(this.ship != null)
            {
                if (this.ship.IsDown())
                    return Result.ShipDestroyed;

                return Result.Hit;
            }

            return Result.Miss;
        }

        public Ship GetShip()
        {
            return this.ship;
        }

        public bool WasBombed
        {
            get { return this.wasBombed; }
        }

        public void Reset()
        {
            this.ship = null;
            wasBombed = false;
        }

        public int I
        { get { return this.i; } }
      
        public int J
        { get { return this.j; } }
    }
}
