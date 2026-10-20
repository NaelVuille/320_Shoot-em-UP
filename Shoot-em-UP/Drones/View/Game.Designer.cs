namespace Joueurs
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
            lblScore.Image = Shoot_em_up.Properties.Resources.contour_bouton;
            lblScore.Location = new Point(20, 20);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(48, 15);
            lblScore.TabIndex = 0;
            lblScore.Text = "Score: 0";
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(284, 261);
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
    }
}