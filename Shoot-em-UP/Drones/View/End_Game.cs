using shootEmUp.Helpers;


namespace shootEmUp.View
{
    public partial class End_Game : Form
    {
        public static readonly int WIDTH = shootEmUp.Helpers.Config.WIDTH;        // Dimensions
        public static readonly int HEIGHT = shootEmUp.Helpers.Config.HEIGHT;

        string BestScorePath = @"..\..\..\Resources\BestScore.txt";
        int BestScore;

        public End_Game(int score)
        {
            if (!int.TryParse(File.ReadAllText(BestScorePath), out BestScore)) BestScore = 0;

            Config.play = false;

            InitializeComponent();
            TextHelpers.Init();
            lblTitle.Font = TextHelpers.BigFont;
            lblFinalScore.Font = TextHelpers.MediumFont;
            ButtonHelper.Configure(btnReplay);
            ButtonHelper.Configure(btnQuit);
            ClientSize = new Size(WIDTH, HEIGHT);
            lblTitle.Location = new Point(Config.WIDTH / 2 - lblTitle.Size.Width / 2, 50);
            lblFinalScore.Location = new Point(Config.WIDTH / 2 - btnReplay.Width / 2 , 170);
            btnReplay.Location = new Point(Config.WIDTH / 2 - btnReplay.Width / 2, 450);
            btnQuit.Location = new Point(Config.WIDTH / 2 - btnQuit.Width / 2, 560);

            if (score > BestScore)
            {
                lblFinalScore.Text = "NEW HIGH SCORE!\n" + score;
                File.WriteAllText(BestScorePath, $"{score}");
            }
            else { lblFinalScore.Text = "FINAL SCORE!\n" + score; }
        }

        private void btnReplay_Click(object sender, EventArgs e)
        {
            Config.play = true;
            this.Close();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
