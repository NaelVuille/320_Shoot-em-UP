namespace Drones.View
{
    public partial class Accueil : Form
    {
        public static readonly int WIDTH = Joueurs.Helpers.Config.WIDTH;        // Dimensions
        public static readonly int HEIGHT = Joueurs.Helpers.Config.HEIGHT;

        public Accueil()
        {
            InitializeComponent();
            ClientSize = new Size(WIDTH, HEIGHT);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
