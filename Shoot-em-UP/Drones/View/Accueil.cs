using Joueurs;
using Joueurs.Helpers;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using Shoot_em_up.Properties;
using Shoot_em_up.Helpers;

namespace Drones.View
{
    public partial class Accueil : Form
    {
        public static readonly int WIDTH = Joueurs.Helpers.Config.WIDTH;        // Dimensions
        public static readonly int HEIGHT = Joueurs.Helpers.Config.HEIGHT;

        public Accueil()
        {
            InitializeComponent();
            TextHelpers.Init();
            lblTitle.Font = TextHelpers.BigFont;
            ButtonHelper.Configure(btnPlay);
            ButtonHelper.Configure(btnQuit);
            ClientSize = new Size(WIDTH, HEIGHT);
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
