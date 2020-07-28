namespace Battleship
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.battleshipLabel = new System.Windows.Forms.Label();
            this.airecraftcarrierLabel = new System.Windows.Forms.Label();
            this.cruiserLabel = new System.Windows.Forms.Label();
            this.destroyerLabel = new System.Windows.Forms.Label();
            this.submarineLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.computersTurnLabel = new System.Windows.Forms.Label();
            this.playersTurnsLabel = new System.Windows.Forms.Label();
            this.computersTurnsCountLabel = new System.Windows.Forms.Label();
            this.playersTurnsCountLabel = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.debugModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundButton = new System.Windows.Forms.PictureBox();
            this.backwardButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundButton)).BeginInit();
            this.SuspendLayout();
            // 
            // battleshipLabel
            // 
            this.battleshipLabel.AutoSize = true;
            this.battleshipLabel.BackColor = System.Drawing.Color.Transparent;
            this.battleshipLabel.ForeColor = System.Drawing.Color.Transparent;
            this.battleshipLabel.Location = new System.Drawing.Point(327, 736);
            this.battleshipLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.battleshipLabel.Name = "battleshipLabel";
            this.battleshipLabel.Size = new System.Drawing.Size(70, 17);
            this.battleshipLabel.TabIndex = 5;
            this.battleshipLabel.Text = "Battleship";
            // 
            // airecraftcarrierLabel
            // 
            this.airecraftcarrierLabel.AutoSize = true;
            this.airecraftcarrierLabel.BackColor = System.Drawing.Color.Transparent;
            this.airecraftcarrierLabel.ForeColor = System.Drawing.Color.Transparent;
            this.airecraftcarrierLabel.Location = new System.Drawing.Point(73, 736);
            this.airecraftcarrierLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.airecraftcarrierLabel.Name = "airecraftcarrierLabel";
            this.airecraftcarrierLabel.Size = new System.Drawing.Size(100, 17);
            this.airecraftcarrierLabel.TabIndex = 6;
            this.airecraftcarrierLabel.Text = "Aircraft Carrier";
            // 
            // cruiserLabel
            // 
            this.cruiserLabel.AutoSize = true;
            this.cruiserLabel.BackColor = System.Drawing.Color.Transparent;
            this.cruiserLabel.ForeColor = System.Drawing.Color.Transparent;
            this.cruiserLabel.Location = new System.Drawing.Point(567, 736);
            this.cruiserLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cruiserLabel.Name = "cruiserLabel";
            this.cruiserLabel.Size = new System.Drawing.Size(53, 17);
            this.cruiserLabel.TabIndex = 7;
            this.cruiserLabel.Text = "Cruiser";
            // 
            // destroyerLabel
            // 
            this.destroyerLabel.AutoSize = true;
            this.destroyerLabel.BackColor = System.Drawing.Color.Transparent;
            this.destroyerLabel.ForeColor = System.Drawing.Color.Transparent;
            this.destroyerLabel.Location = new System.Drawing.Point(787, 736);
            this.destroyerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.destroyerLabel.Name = "destroyerLabel";
            this.destroyerLabel.Size = new System.Drawing.Size(70, 17);
            this.destroyerLabel.TabIndex = 8;
            this.destroyerLabel.Text = "Destroyer";
            // 
            // submarineLabel
            // 
            this.submarineLabel.AutoSize = true;
            this.submarineLabel.BackColor = System.Drawing.Color.Transparent;
            this.submarineLabel.ForeColor = System.Drawing.Color.Transparent;
            this.submarineLabel.Location = new System.Drawing.Point(1024, 736);
            this.submarineLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.submarineLabel.Name = "submarineLabel";
            this.submarineLabel.Size = new System.Drawing.Size(76, 17);
            this.submarineLabel.TabIndex = 9;
            this.submarineLabel.Text = "Submarine";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(1228, 763);
            this.startButton.Margin = new System.Windows.Forms.Padding(4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(136, 28);
            this.startButton.TabIndex = 10;
            this.startButton.Text = "Start Game";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // computersTurnLabel
            // 
            this.computersTurnLabel.AutoSize = true;
            this.computersTurnLabel.BackColor = System.Drawing.Color.Transparent;
            this.computersTurnLabel.ForeColor = System.Drawing.Color.Black;
            this.computersTurnLabel.Location = new System.Drawing.Point(1204, 69);
            this.computersTurnLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.computersTurnLabel.Name = "computersTurnLabel";
            this.computersTurnLabel.Size = new System.Drawing.Size(161, 17);
            this.computersTurnLabel.TabIndex = 12;
            this.computersTurnLabel.Text = "Turns Computer Played:";
            this.computersTurnLabel.Visible = false;
            // 
            // playersTurnsLabel
            // 
            this.playersTurnsLabel.AutoSize = true;
            this.playersTurnsLabel.BackColor = System.Drawing.Color.Transparent;
            this.playersTurnsLabel.Location = new System.Drawing.Point(13, 69);
            this.playersTurnsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playersTurnsLabel.Name = "playersTurnsLabel";
            this.playersTurnsLabel.Size = new System.Drawing.Size(125, 17);
            this.playersTurnsLabel.TabIndex = 13;
            this.playersTurnsLabel.Text = "Turns You Played:";
            this.playersTurnsLabel.Visible = false;
            // 
            // computersTurnsCountLabel
            // 
            this.computersTurnsCountLabel.AutoSize = true;
            this.computersTurnsCountLabel.BackColor = System.Drawing.Color.Transparent;
            this.computersTurnsCountLabel.ForeColor = System.Drawing.Color.SpringGreen;
            this.computersTurnsCountLabel.Location = new System.Drawing.Point(1363, 69);
            this.computersTurnsCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.computersTurnsCountLabel.Name = "computersTurnsCountLabel";
            this.computersTurnsCountLabel.Size = new System.Drawing.Size(16, 17);
            this.computersTurnsCountLabel.TabIndex = 14;
            this.computersTurnsCountLabel.Text = "0";
            this.computersTurnsCountLabel.Visible = false;
            // 
            // playersTurnsCountLabel
            // 
            this.playersTurnsCountLabel.AutoSize = true;
            this.playersTurnsCountLabel.BackColor = System.Drawing.Color.Transparent;
            this.playersTurnsCountLabel.ForeColor = System.Drawing.Color.SpringGreen;
            this.playersTurnsCountLabel.Location = new System.Drawing.Point(137, 69);
            this.playersTurnsCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playersTurnsCountLabel.Name = "playersTurnsCountLabel";
            this.playersTurnsCountLabel.Size = new System.Drawing.Size(16, 17);
            this.playersTurnsCountLabel.TabIndex = 15;
            this.playersTurnsCountLabel.Text = "0";
            this.playersTurnsCountLabel.Visible = false;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1399, 30);
            this.menuStrip.TabIndex = 16;
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(62, 26);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::Battleship.Properties.Resources.playIcon;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::Battleship.Properties.Resources.exitIcon;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.toolStripMenuItem1,
            this.debugModeToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 26);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::Battleship.Properties.Resources.aboutIcon;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(233, 6);
            // 
            // debugModeToolStripMenuItem
            // 
            this.debugModeToolStripMenuItem.Enabled = false;
            this.debugModeToolStripMenuItem.Image = global::Battleship.Properties.Resources.debugIcon;
            this.debugModeToolStripMenuItem.Name = "debugModeToolStripMenuItem";
            this.debugModeToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.debugModeToolStripMenuItem.Text = "Turn Debug Mode On";
            this.debugModeToolStripMenuItem.Click += new System.EventHandler(this.debugModeToolStripMenuItem_Click);
            // 
            // soundButton
            // 
            this.soundButton.BackColor = System.Drawing.Color.Transparent;
            this.soundButton.Image = global::Battleship.Properties.Resources.soundOffIcon;
            this.soundButton.Location = new System.Drawing.Point(325, 282);
            this.soundButton.Margin = new System.Windows.Forms.Padding(4);
            this.soundButton.Name = "soundButton";
            this.soundButton.Size = new System.Drawing.Size(32, 32);
            this.soundButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.soundButton.TabIndex = 17;
            this.soundButton.TabStop = false;
            this.soundButton.Visible = false;
            this.soundButton.Click += new System.EventHandler(this.soundButton_Click);
            // 
            // backwardButton
            // 
            this.backwardButton.Image = global::Battleship.Properties.Resources.backwardIcon;
            this.backwardButton.Location = new System.Drawing.Point(1185, 763);
            this.backwardButton.Margin = new System.Windows.Forms.Padding(4);
            this.backwardButton.Name = "backwardButton";
            this.backwardButton.Size = new System.Drawing.Size(33, 28);
            this.backwardButton.TabIndex = 18;
            this.backwardButton.UseVisualStyleBackColor = true;
            this.backwardButton.Click += new System.EventHandler(this.backwardButton_Click);
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.Transparent;
            this.playButton.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.ForeColor = System.Drawing.Color.Black;
            this.playButton.Location = new System.Drawing.Point(142, 268);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(109, 62);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "Start";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_MouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Battleship.Properties.Resources.background1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1399, 832);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.backwardButton);
            this.Controls.Add(this.soundButton);
            this.Controls.Add(this.playersTurnsCountLabel);
            this.Controls.Add(this.computersTurnsCountLabel);
            this.Controls.Add(this.playersTurnsLabel);
            this.Controls.Add(this.computersTurnLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.submarineLabel);
            this.Controls.Add(this.destroyerLabel);
            this.Controls.Add(this.cruiserLabel);
            this.Controls.Add(this.airecraftcarrierLabel);
            this.Controls.Add(this.battleshipLabel);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battleship";
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label battleshipLabel;
        private System.Windows.Forms.Label airecraftcarrierLabel;
        private System.Windows.Forms.Label cruiserLabel;
        private System.Windows.Forms.Label destroyerLabel;
        private System.Windows.Forms.Label submarineLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label computersTurnLabel;
        private System.Windows.Forms.Label playersTurnsLabel;
        private System.Windows.Forms.Label computersTurnsCountLabel;
        private System.Windows.Forms.Label playersTurnsCountLabel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem debugModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.PictureBox soundButton;
        private System.Windows.Forms.Button backwardButton;
        private System.Windows.Forms.Button playButton;
    }
}

