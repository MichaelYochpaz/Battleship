using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{

    public class GraphicSquare : PictureBox
    {
        private enum SquareImage { None, Empty, Bombed };
        readonly Square s;
        readonly int i, j;
        private bool clickable, clicked, debug, cursorVisible;

        public GraphicSquare(int i, int j, Square s, bool clickable = true)
        {
            this.i = i;
            this.j = j;
            this.s = s;
            this.clickable = clickable;
            this.clicked = false;
            this.debug = false;
            this.cursorVisible = true;
            this.Size = new System.Drawing.Size(GameSettings.Default.ButtonSize, GameSettings.Default.ButtonSize);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackgroundImage = Properties.Resources.water;
            this.MouseEnter += new EventHandler(MouseEnterEvent);
            this.MouseLeave += new EventHandler(MouseLeaveEvent);
        }

        public bool Clickable { get { return clickable; } set { clickable = value; } }

        public bool Clicked { get { return clicked; } }

        public void DebugMode()
        {
            if (!debug && !clicked)
            {
                debug = true;
                this.DebugUpdate();
            }
        }

        public void NormalMode()
        {
            if (debug)
            {
                debug = false;
                this.BackgroundImage = Properties.Resources.water;

                if (!clicked)
                    this.Image = null;
            }
        }

        private void DebugUpdate()
        {
            if (!clicked)
            {
                if (s.GetShip() != null)
                    this.Image = Properties.Resources.bombed;
            }
        }

        public void Attack()
        {
            clicked = true;
            s.Bomb();

            if (this.s.GetShip() == null)
                this.Image = Properties.Resources.empty;

            else
                this.Image = Properties.Resources.bombed;
        }

        public void ShipDestroyed()
        {
            this.Image = Properties.Resources.shipDestroyed;
        }

        public void Mark(bool blocked)
        {
            if (blocked)
                this.BackgroundImage = Properties.Resources.waterBlocked;
            else
                this.BackgroundImage = Properties.Resources.waterNotBlocked;
        }

        private void MouseEnterEvent(Object sender, EventArgs e)
        {
            if (clickable)
            {
                if (!clicked)
                {
                    this.Image = Properties.Resources.water_bomb;
                    if (cursorVisible)
                    {
                        Cursor.Hide();
                        cursorVisible = false;
                    }
                }
            }
        }

        private void MouseLeaveEvent(Object sender, EventArgs e)
        {
            if (clickable)
            {
                if (!clicked)
                {
                    if (debug && s.GetShip() != null)
                        this.Image = Properties.Resources.bombed;

                    else
                        this.Image = null;
                }

                if (!cursorVisible)
                {
                    Cursor.Show();
                    cursorVisible = true;
                }
            }
        }

        public void Reset(bool justImage = false)
        {
            this.BackgroundImage = Properties.Resources.water;

            if (!justImage)
            {
                this.debug = false;
                this.clicked = false;
                this.Image = null;
            }
        }

        public Square GetSquare()
        { return this.s; }

        public int GetI()
        { return this.i; }

        public int GetJ()
        { return this.j; }
    }
}
