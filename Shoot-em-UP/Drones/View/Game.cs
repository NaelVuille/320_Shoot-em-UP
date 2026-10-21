using shootEmUp.Model;
using shootEmUp.Helpers;

namespace shootEmUp
{
   
    // Il s'agit d'un formulaire (une fenêtre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient

    public partial class Game : Form
    {
        // Récupère la position de la souris relative à la fenêtre active
        Point mousePos = Form.ActiveForm != null ? Form.ActiveForm.PointToClient(Cursor.Position) : Cursor.Position;


        private Joueur _joueur;

        private int _score = 0;

        private List<Bullet> _bullets;

        private int _timer = 10;

        private static int _numberEnnemis = 1;

        private static int _enemiesSpawn = 0;

        private List<Ennemie> _enemies = new List<Ennemie>();

        private List<EnemyBullet> _enemiesbullets = new List<EnemyBullet>();

        private List<Protection> _protections = new List<Protection>();

        private int _x = 0;

        BufferedGraphicsContext currentContext;
        BufferedGraphics game;


        public Game(Joueur joueur,List<Bullet>bullets)
        {
            InitializeComponent();
            ClientSize = new Size(Helpers.Config.WIDTH, Helpers.Config.HEIGHT); 

            lblScore.Font = TextHelpers.MediumFont;
            lblScore.Text = "Score: \n" + _score;

            _numberEnnemis = 10;

            _x = (Helpers.Config.WIDTH - Ennemie.ENNEMIESIZE) / _numberEnnemis + 10;
            
            for (int i = 0; i < _numberEnnemis; i++)
            {
                _enemies.Add(new Ennemie(_x * i , Ennemie.ENNEMIESIZE, Config.ENEMIESMAXLIFE, bullets));
            }
            
            lblLife.Location = new Point(Helpers.Config.WIDTH - 20 - lblLife.Size.Width / 2, 5);

            _score = 0;

            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with this form, and with
            // dimensions the same size as the drawing surface of the form.
            game = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            
            _joueur = joueur;
            _bullets = bullets;
            

            const int _NOMBREPROTECTION = 5;
            for (int i = 0; i < _NOMBREPROTECTION; i++)
            {
                _protections.Add(new Protection(125 + Helpers.Config.WIDTH / _NOMBREPROTECTION * i, 450));
            }

        }

        // Affichage de la situation actuelle
        private void Render()
        {
            game.Graphics.Clear(Color.Black);

            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].Render(game);

            }

            foreach (Bullet bullet in _bullets)
            {
                bullet.Render(game);
            }

            foreach (EnemyBullet enemybullet in _enemiesbullets)
            {
                enemybullet.Render(game);
            }

            _joueur.Render(game);

            foreach (Protection protection in _protections)
            {
                protection.Render(game);
            }

            game.Render();

        }

        private void Update(int interval,Joueur joueur, List<Bullet> bullets)
        {
            lblScore.Text = "Score: " + _score;
            lblLife.Text = string.Concat(Enumerable.Repeat("♥", joueur.Vie));

            _timer++;
            _enemiesSpawn++;


            if (_enemiesSpawn >= 50)
            {
                _numberEnnemis = MathHelpers.alea.Next(2, 5);

                _x = (Helpers.Config.WIDTH - Ennemie.ENNEMIESIZE) / _numberEnnemis + 10;
                _x += (_x / 4);
                for (int i = 0; i < _numberEnnemis; i++)
                {
                    _enemies.Add(new Ennemie(_x * i, -Ennemie.ENNEMIESIZE, Config.ENEMIESMAXLIFE, bullets));
                }
                _enemiesSpawn = 0;
            }


            for (int i = _enemiesbullets.Count - 1; i >= 0; i--)
            {
                _enemiesbullets[i].Update(_enemiesbullets, _protections, _joueur, _enemies);
            }

            _joueur.Update(interval, mousePos, _score);


            for (int i = _bullets.Count - 1; i >= 0; i--)
            {
                _bullets[i].Update(_bullets, _protections, _enemies);
            }

            for (int i = _enemies.Count - 1; i >= 0; i--)
            {
                _score = _enemies[i].Update(interval, _enemies, _protections, _enemiesbullets, _score, joueur);
            }

        }

        // Méthode appelée à chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            if (_joueur.Vie <= 0)
            {

                this.Close();
            }
            else
            {
                mousePos = Form.ActiveForm != null ? Form.ActiveForm.PointToClient(Cursor.Position) : Cursor.Position;
                this.Update(ticker.Interval, _joueur,_bullets);
                this.Render();
            }


        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            _joueur.Action(sender, e, _bullets, ticker.Interval, _protections,_joueur, _timer);

        }
        private void Game_MouseDown(object sender, MouseEventArgs e)
        {

            if (_timer >= 10)
            {
                _timer = 0;
                _joueur.Shoot(_bullets, ticker.Interval,_joueur);
            }

        }
    }
}