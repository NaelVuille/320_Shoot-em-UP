using shootEmUp.Helpers;

namespace shootEmUp.View
{
    public partial class MainMenu : Form
    {

        int highScore = 0;

        private readonly Keys[] _konamiCode = new Keys[]
        {
            Keys.W, Keys.W,
            Keys.S, Keys.S,
            Keys.A, Keys.D,
            Keys.A, Keys.D,
            Keys.B, Keys.A
        };

        private int _konamiIndex = 0;

        public MainMenu()
        {
            Config.play = false;

            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += Accueil_KeyDown;

            TextHelper.Init();
            lblTitle.Font = TextHelper.BigFont;
            lblHighScore.Font = TextHelper.MediumFont;
            ButtonHelper.Configure(btnPlay);
            ButtonHelper.Configure(btnQuit);
            ButtonHelper.Configure(btnSizeWindows);
            btnSizeWindows.Font = TextHelper.SmallFont;
            ClientSize = new Size(Helpers.Config.width, Helpers.Config.height);
            lblTitle.Location = new Point(Config.width / 2 - lblTitle.Size.Width / 2, 50);
            lblHighScore.Location = new Point(Config.width / 2 - lblHighScore.Size.Width / 2, 170);
            btnPlay.Location = new Point(Config.width / 2 - btnPlay.Size.Width / 2, 450);
            btnQuit.Location = new Point(Config.width / 2 - btnQuit.Size.Width / 2, 560);
            btnSizeWindows.Location = new Point(10,Config.height - btnSizeWindows.Size.Height);

            RefreshHighScore();
        }

        private void Accueil_KeyDown(object? sender, KeyEventArgs e)
        {
            Keys currentKey = e.KeyCode;
            if (currentKey == Keys.Up) currentKey = Keys.W;
            if (currentKey == Keys.Down) currentKey = Keys.S;
            if (currentKey == Keys.Left) currentKey = Keys.A;
            if (currentKey == Keys.Right) currentKey = Keys.D;

            if (currentKey == _konamiCode[_konamiIndex])
            {
                _konamiIndex++;

                if (_konamiIndex == _konamiCode.Length)
                {
                    Reset();
                    _konamiIndex = 0;
                }
            }
            else
            {
                _konamiIndex = (e.KeyCode == _konamiCode[0]) ? 1 : 0;
            }
        }

        private void Reset()
        {
            DialogResult result = MessageBox.Show("Reset high score?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                Properties.Settings.Default.HighScore = 0;
                Properties.Settings.Default.Save();
                RefreshHighScore();
            }
        }

        private void RefreshHighScore()
        {
            highScore = Config.HIGHSCORE;
            lblHighScore.Text = "Best Score\n" + highScore;
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

        private void btnSizeWindows_Click(object sender, EventArgs e)
        {
            if (Config.isBig)
            {
                Config.isBig = false;
                Config.height = 720;
                Config.width = 1280;
                btnSizeWindows.Text = "Big";
            }
            else
            {
                Config.isBig = true;
                Config.height = 1080;
                Config.width = 1920;
                btnSizeWindows.Text = "Small";
            }
        }
    }
}
