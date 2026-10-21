using shootEmUp.Helpers;

namespace shootEmUp.View
{
    public partial class Accueil : Form
    {
        public static readonly int WIDTH = shootEmUp.Helpers.Config.WIDTH;        // Dimensions
        public static readonly int HEIGHT = shootEmUp.Helpers.Config.HEIGHT;

        string bestScore = File.ReadAllText(@"..\..\..\Resources\BestScore.txt");

        public Accueil()
        {
            Config.play = false;

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
            btnQuit.Location = new Point(Config.WIDTH / 2 - btnQuit.Size.Width / 2, 560);
            lblHighScore.Text = "Best Score\n" + bestScore;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Config.play = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Accueil_Load(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
