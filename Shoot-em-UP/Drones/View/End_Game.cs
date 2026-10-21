using shootEmUp.Helpers;


namespace shootEmUp.View
{
    public partial class End_Game : Form
    {
        int highScore;

        public End_Game(int score)
        {
            if (!int.TryParse(File.ReadAllText(Config.HIGHSCOREPATH), out highScore)) highScore = 0;

            Config.play = false;

            InitializeComponent();
            TextHelpers.Init();
            lblTitle.Font = TextHelpers.BigFont;
            lblFinalScore.Font = TextHelpers.MediumFont;
            ButtonHelper.Configure(btnReplay);
            ButtonHelper.Configure(btnQuit);
            ClientSize = new Size(Helpers.Config.WIDTH, Helpers.Config.HEIGHT);
            lblTitle.Location = new Point(Config.WIDTH / 2 - lblTitle.Size.Width / 2, 50);
            lblFinalScore.Location = new Point(Config.WIDTH / 2 - btnReplay.Width / 2 , 170);
            btnReplay.Location = new Point(Config.WIDTH / 2 - btnReplay.Width / 2, 450);
            btnQuit.Location = new Point(Config.WIDTH / 2 - btnQuit.Width / 2, 560);

            if (score > highScore)
            {
                lblFinalScore.Text = "NEW HIGH SCORE!\n" + score;
                File.WriteAllText(Config.HIGHSCOREPATH, $"{score}");
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
