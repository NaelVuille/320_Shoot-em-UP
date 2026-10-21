namespace shootEmUp
{
    partial class Game
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ticker = new System.Windows.Forms.Timer(components);
            lblScore = new Label();
            lblLife = new Label();
            SuspendLayout();
            // 
            // ticker
            // 
            ticker.Enabled = true;
            ticker.Tick += NewFrame;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.Transparent;
            lblScore.FlatStyle = FlatStyle.Flat;
            lblScore.ForeColor = Color.White;
            lblScore.Image = shootEmUp.Properties.Resources.contour_bouton;
            lblScore.Location = new Point(20, 20);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(48, 15);
            lblScore.TabIndex = 0;
            lblScore.Text = "Score: 0";
            // 
            // lblLife
            // 
            lblLife.AutoSize = true;
            lblLife.Font = new Font("Segoe UI", 60F);
            lblLife.ForeColor = Color.Maroon;
            lblLife.Location = new Point(219, 141);
            lblLife.Name = "lblLife";
            lblLife.Size = new Size(375, 106);
            lblLife.TabIndex = 1;
            lblLife.Text = "❤️❤️❤️";
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(284, 261);
            Controls.Add(lblLife);
            Controls.Add(lblScore);
            Name = "Game";
            Text = "Game";
            KeyDown += Game_KeyDown;
            MouseDown += Game_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer ticker;
        private Label lblScore;
        private Label lblLife;
    }
}