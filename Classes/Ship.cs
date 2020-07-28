using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Ship
    {
        public enum Type { None, AircraftCarrier, Battleship, Cruiser, Destroyer, Submarine }

        private bool isDown;
        private Type t;
        private Square[] s;

        public Ship(Square[] s, Type t)
        {
            this.s = s;
            this.t = t;
            isDown = false;

            for (int i = 0; i < s.Length; i++)
                s[i].SetShip(this);
        }

        public Type ShipType
        { get { return t; } set { t = value; } }

        public Square[] Squares
        { get { return s; } }


        public bool IsDown()
        {
            if (isDown)
                return true;

            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (!s[i].WasBombed)
                        return false;
                }
            }

            isDown = true;
            return true;
        }
    }
}