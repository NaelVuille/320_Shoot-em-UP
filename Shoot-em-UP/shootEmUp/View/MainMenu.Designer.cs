using System.Drawing.Text;

namespace shootEmUp.View
{
    partial class MainMenu
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
            lblTitle = new Label();
            btnPlay = new Button();
            btnQuit = new Button();
            lblHighScore = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 30F);
            lblTitle.ForeColor = Color.Aqua;
            lblTitle.Location = new Point(-167, 50);
            lblTitle.Margin = new Padding(0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(467, 54);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "MR. MEESEEKS SHOOTER";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            lblTitle.Click += lblTitle_Click;
            // 
            // btnPlay
            // 
            btnPlay.Anchor = AnchorStyles.Top;
            btnPlay.BackColor = SystemColors.ActiveCaptionText;
            btnPlay.BackgroundImage = shootEmUp.Properties.Resources.buttonFrame;
            btnPlay.BackgroundImageLayout = ImageLayout.Zoom;
            btnPlay.FlatStyle = FlatStyle.Popup;
            btnPlay.ForeColor = SystemColors.ControlLightLight;
            btnPlay.Location = new Point(164, 224);
            btnPlay.Margin = new Padding(10);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(400, 100);
            btnPlay.TabIndex = 4;
            btnPlay.Text = "PLAY";
            btnPlay.UseMnemonic = false;
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += button1_Click;
            // 
            // btnQuit
            // 
            btnQuit.Anchor = AnchorStyles.Top;
            btnQuit.BackgroundImage = shootEmUp.Properties.Resources.buttonFrame;
            btnQuit.BackgroundImageLayout = ImageLayout.Zoom;
            btnQuit.FlatStyle = FlatStyle.Popup;
            btnQuit.ForeColor = SystemColors.ControlLightLight;
            btnQuit.Location = new Point(164, 353);
            btnQuit.Margin = new Padding(10);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(400, 100);
            btnQuit.TabIndex = 5;
            btnQuit.Text = "QUIT";
            btnQuit.UseMnemonic = false;
            btnQuit.UseVisualStyleBackColor = false;
            btnQuit.Click += button2_Click;
            // 
            // lblHighScore
            // 
            lblHighScore.Anchor = AnchorStyles.Top;
            lblHighScore.AutoSize = true;
            lblHighScore.Font = new Font("Segoe UI", 30F);
            lblHighScore.ForeColor = Color.White;
            lblHighScore.Location = new Point(109, 225);
            lblHighScore.Margin = new Padding(0);
            lblHighScore.Name = "lblHighScore";
            lblHighScore.Size = new Size(217, 162);
            lblHighScore.TabIndex = 6;
            lblHighScore.Text = "Best Score\nPlayer1\nScore : 000";
            lblHighScore.TextAlign = ContentAlignment.TopCenter;
            // 
            // Accueil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(684, 504);
            Controls.Add(lblHighScore);
            Controls.Add(btnQuit);
            Controls.Add(btnPlay);
            Controls.Add(lblTitle);
            Name = "Accueil";
            Text = "Accueil";
            Load += Accueil_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTitle;
        private Button btnPlay;
        private Button btnQuit;
        private Label lblHighScore;
    }
}