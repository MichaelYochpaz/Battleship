using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Battleship
{

    public class ShipBox : PictureBox
    {
        readonly Ship.Type type;
        private bool rotated; // Rotated = Vertical

        public ShipBox(Ship.Type type)
        {
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = ImageLayout.Center;
            this.Size = new System.Drawing.Size(120, 45);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.rotated = false;
            this.type = type;

            switch(type)
            {
                case Ship.Type.AircraftCarrier:
                    this.BackgroundImage = Properties.Resources.aircraftCarrier;
                    break;

                case Ship.Type.Battleship:
                    this.BackgroundImage = Properties.Resources.battleship;
                    break;

                case Ship.Type.Cruiser:
                    this.BackgroundImage = Properties.Resources.cruiser;
                    break;

                case Ship.Type.Destroyer:
                    this.BackgroundImage = Properties.Resources.destroyer;
                    break;

                case Ship.Type.Submarine:
                    this.BackgroundImage = Properties.Resources.submarine;
                    break;
            }
        }

        public Ship.Type Type { get { return type; } }

        public bool Rotated { get { return rotated; } set { rotated = value; } }

        public int Length()
        {
            switch (type)
            {
                case Ship.Type.AircraftCarrier:
                    return 5;

                case Ship.Type.Battleship:
                    return 4;

                case Ship.Type.Cruiser:
                case Ship.Type.Destroyer:
                    return 3;

                case Ship.Type.Submarine:
                    return 2;
            }

            return 0;
        }

        public void Rotate()
        {
            if (!rotated)
                this.Image = Properties.Resources.rotate;

            else
                this.Image = null;

            rotated = !rotated;
        }

        public void Lock()
        {
            this.BorderStyle = BorderStyle.None;
            this.Image = null;
            this.Enabled = false;

            switch (this.type)
            {
                case Ship.Type.AircraftCarrier:
                    this.BackgroundImage = Properties.Resources.aircraftCarrierBlackWhite;
                    break;

                case Ship.Type.Battleship:
                    this.BackgroundImage = Properties.Resources.battleshipBlackWhite;
                    break;

                case Ship.Type.Cruiser:
                    this.BackgroundImage = Properties.Resources.cruiserBlackWhite;
                    break;

                case Ship.Type.Destroyer:
                    this.BackgroundImage = Properties.Resources.destroyerBlackWhite;
                    break;

                case Ship.Type.Submarine:
                    this.BackgroundImage = Properties.Resources.submarineBlackWhite;
                    break;
            }
        }

        public void Reset(bool smallReset = false)
        {
            this.BorderStyle = BorderStyle.None;
            this.Image = null;
            this.rotated = false;

            if (!smallReset)
            {
                this.Enabled = true;

                switch (type)
                {
                    case Ship.Type.AircraftCarrier:
                        this.BackgroundImage = Properties.Resources.aircraftCarrier;
                        break;

                    case Ship.Type.Battleship:
                        this.BackgroundImage = Properties.Resources.battleship;
                        break;

                    case Ship.Type.Cruiser:
                        this.BackgroundImage = Properties.Resources.cruiser;
                        break;

                    case Ship.Type.Destroyer:
                        this.BackgroundImage = Properties.Resources.destroyer;
                        break;

                    case Ship.Type.Submarine:
                        this.BackgroundImage = Properties.Resources.submarine;
                        break;
                }
            }
        }
    }
}
