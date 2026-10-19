using Joueurs;
using Joueurs.Helpers;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using Shoot_em_up.Properties;
using Shoot_em_up.Helpers;
using System.IO;
using System.Threading.Tasks;

namespace Drones.View
{
    public partial class Accueil : Form
    {
        public static readonly int WIDTH = Joueurs.Helpers.Config.WIDTH;        // Dimensions
        public static readonly int HEIGHT = Joueurs.Helpers.Config.HEIGHT;

        string bestPlayerName = File.ReadAllText(@"..\..\..\Resources\BestName.txt");
        string bestScore = File.ReadAllText(@"..\..\..\Resources\BestScore.txt");

        public Accueil()
        {
            InitializeComponent();
            TextHelpers.Init();
            lblTitle.Font = TextHelpers.BigFont;
            lblHighScore.Font = TextHelpers.MediumFont;
            ButtonHelper.Configure(btnPlay);
            ButtonHelper.Configure(btnQuit);
            ClientSize = new Size(WIDTH, HEIGHT);
            lblTitle.Location = new Point(Config.WIDTH / 2 - lblTitle.Size.Width / 2, 50);
            lblHighScore.Location = new Point(Config.WIDTH / 2 - lblHighScore.Size.Width / 2, 170);
            btnPlay.Location = new Point(Config.WIDTH / 2 - btnPlay.Size.Width / 2, 450);
            btnQuit.Location = new Point(Config.WIDTH / 2 - btnPlay.Size.Width / 2, 560);
            lblHighScore.Text = "Best Score\n"+bestPlayerName+"\nScore : "+bestScore;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Joueur joueur = new Joueur(Game.WIDTH / 2, Game.HEIGHT / 2);
            using (Game gameForm = new Game(joueur))
            {
                gameForm.ShowDialog();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Accueil_Load(object sender, EventArgs e)
        {

        }
    }
}
