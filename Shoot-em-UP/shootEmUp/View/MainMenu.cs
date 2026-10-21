using shootEmUp.Helpers;

namespace shootEmUp.View
{
    public partial class MainMenu : Form
    {
        
        string highScore = "0";

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

            TextHelpers.Init();
            lblTitle.Font = TextHelpers.BigFont;
            lblHighScore.Font = TextHelpers.MediumFont;
            ButtonHelper.Configure(btnPlay);
            ButtonHelper.Configure(btnQuit);
            ClientSize = new Size(Helpers.Config.WIDTH, Helpers.Config.HEIGHT);
            lblTitle.Location = new Point(Config.WIDTH / 2 - lblTitle.Size.Width / 2, 50);
            lblHighScore.Location = new Point(Config.WIDTH / 2 - lblHighScore.Size.Width / 2, 170);
            btnPlay.Location = new Point(Config.WIDTH / 2 - btnPlay.Size.Width / 2, 450);
            btnQuit.Location = new Point(Config.WIDTH / 2 - btnQuit.Size.Width / 2, 560);

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
                File.WriteAllText(Config.HIGHSCOREPATH, "0");
                RefreshHighScore();
            }
        }

        private void RefreshHighScore()
        {
            highScore = File.ReadAllText(Config.HIGHSCOREPATH);
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
    }
}
