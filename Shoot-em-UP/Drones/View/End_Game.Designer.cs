namespace Shoot_em_up.View
{
    partial class End_Game
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
            lblFinalScore = new Label();
            btnReplay = new Button();
            btnQuit = new Button();
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
            // 
            // lblFinalScore
            // 
            lblFinalScore.Anchor = AnchorStyles.Top;
            lblFinalScore.AutoSize = true;
            lblFinalScore.Font = new Font("Segoe UI", 30F);
            lblFinalScore.ForeColor = Color.White;
            lblFinalScore.Location = new Point(109, 225);
            lblFinalScore.Margin = new Padding(0);
            lblFinalScore.Name = "lblFinalScore";
            lblFinalScore.Size = new Size(214, 54);
            lblFinalScore.TabIndex = 6;
            lblFinalScore.Text = "Final Score";
            lblFinalScore.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnReplay
            // 
            btnReplay.Anchor = AnchorStyles.Top;
            btnReplay.BackColor = SystemColors.ActiveCaptionText;
            btnReplay.BackgroundImage = Properties.Resources.contour_bouton;
            btnReplay.BackgroundImageLayout = ImageLayout.Zoom;
            btnReplay.FlatStyle = FlatStyle.Popup;
            btnReplay.ForeColor = SystemColors.ControlLightLight;
            btnReplay.Location = new Point(164, 224);
            btnReplay.Margin = new Padding(10);
            btnReplay.Name = "btnReplay";
            btnReplay.Size = new Size(400, 100);
            btnReplay.TabIndex = 4;
            btnReplay.Text = "REPLAY";
            btnReplay.UseMnemonic = false;
            btnReplay.UseVisualStyleBackColor = false;
            btnReplay.Click += btnReplay_Click;
            // 
            // btnQuit
            // 
            btnQuit.Anchor = AnchorStyles.Top;
            btnQuit.BackgroundImage = Properties.Resources.contour_bouton;
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
            btnQuit.Click += btnQuit_Click;
            // 
            // End_Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(btnQuit);
            Controls.Add(btnReplay);
            Controls.Add(lblFinalScore);
            Controls.Add(lblTitle);
            Name = "End_Game";
            Text = "End_Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblFinalScore;
        private Button btnReplay;
        private Button btnQuit;
    }
}