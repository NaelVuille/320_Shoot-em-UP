using Joueurs;
using Joueurs.Helpers;
using Shoot_em_up.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shoot_em_up.View
{
    public partial class End_Game : Form
    {
        public static readonly int WIDTH = Joueurs.Helpers.Config.WIDTH;        // Dimensions
        public static readonly int HEIGHT = Joueurs.Helpers.Config.HEIGHT;

        string BestScorePath = @"..\..\..\Resources\BestScore.txt";
        int BestScore;

        public End_Game(int score)
        {
            if (!int.TryParse(File.ReadAllText(BestScorePath), out BestScore)) BestScore = 0;

            InitializeComponent();
            TextHelpers.Init();
            lblTitle.Font = TextHelpers.BigFont;
            lblFinalScore.Font = TextHelpers.MediumFont;
            ButtonHelper.Configure(btnReplay);
            ButtonHelper.Configure(btnQuit);
            ClientSize = new Size(WIDTH, HEIGHT);
            lblTitle.Location = new Point(Config.WIDTH / 2 - lblTitle.Size.Width / 2, 50);
            lblFinalScore.Location = new Point(Config.WIDTH / 2 - lblFinalScore.Size.Width / 2, 170);
            btnReplay.Location = new Point(Config.WIDTH / 2 - btnReplay.Size.Width / 2, 450);
            btnQuit.Location = new Point(Config.WIDTH / 2 - btnQuit.Size.Width / 2, 560);

            if (score > BestScore)
            {
                lblFinalScore.Text = "NEW HIGH SCORE!\n" + score;
                File.WriteAllText(BestScorePath, $"{score}");
            }
            else { lblFinalScore.Text = "FINAL SCORE!\n" + score; }
        }

        private void btnReplay_Click(object sender, EventArgs e)
        {
            this.Hide();
            Joueur joueur = new Joueur(Game.WIDTH / 2, Game.HEIGHT / 2);
            using (Game gameForm = new Game(joueur))
            {
                gameForm.ShowDialog();
            }
            this.Close();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
