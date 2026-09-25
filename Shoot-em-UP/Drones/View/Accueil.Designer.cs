using System.Drawing.Text;

namespace Drones.View
{
    partial class Accueil
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
            SuspendLayout();
            // 
            // label1
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 30F);
            lblTitle.ForeColor = Color.Aqua;
            lblTitle.Location = new Point(-167, 9);
            lblTitle.Margin = new Padding(0);
            lblTitle.Name = "label1";
            lblTitle.Size = new Size(467, 54);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "MR. MEESEEKS SHOOTER";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // button1
            // 
            btnPlay.Anchor = AnchorStyles.Top;
            btnPlay.BackgroundImage = Shoot_em_up.Properties.Resources.contour_bouton;
            btnPlay.BackgroundImageLayout = ImageLayout.Zoom;
            btnPlay.FlatStyle = FlatStyle.Popup;
            btnPlay.ForeColor = SystemColors.ControlLightLight;
            btnPlay.Location = new Point(164, 224);
            btnPlay.Margin = new Padding(10);
            btnPlay.Name = "button1";
            btnPlay.Size = new Size(384, 109);
            btnPlay.TabIndex = 4;
            btnPlay.Text = "PLAY";
            btnPlay.UseMnemonic = false;
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += button1_Click;
            // 
            // button2
            // 
            btnQuit.Anchor = AnchorStyles.Top;
            btnQuit.BackgroundImage = Shoot_em_up.Properties.Resources.contour_bouton;
            btnQuit.BackgroundImageLayout = ImageLayout.Zoom;
            btnQuit.FlatStyle = FlatStyle.Popup;
            btnQuit.ForeColor = SystemColors.ControlLightLight;
            btnQuit.Location = new Point(164, 353);
            btnQuit.Margin = new Padding(10);
            btnQuit.Name = "button2";
            btnQuit.Size = new Size(384, 109);
            btnQuit.TabIndex = 5;
            btnQuit.Text = "QUIT";
            btnQuit.UseMnemonic = false;
            btnQuit.UseVisualStyleBackColor = false;
            btnQuit.Click += button2_Click;
            // 
            // Accueil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(684, 504);
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
    }
}