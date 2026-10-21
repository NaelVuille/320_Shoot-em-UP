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


        private Player _player;

        private int _score = 0;

        private List<Bullet> _bullets;

        private int _timer = 10;

        private static int _numberOfEnemies = 1;

        private static int _enemySpawnTimer = 0;

        private List<Enemy> _enemies = new List<Enemy>();

        private List<EnemyBullet> _enemyBullets = new List<EnemyBullet>();

        private List<Protection> _protections = new List<Protection>();

        private int _x = 0;

        BufferedGraphicsContext currentContext;
        BufferedGraphics game;


        public Game(Player player,List<Bullet>bullets)
        {
            InitializeComponent();
            ClientSize = new Size(Helpers.Config.WIDTH, Helpers.Config.HEIGHT); 

            lblScore.Font = TextHelpers.MediumFont;
            lblScore.Text = "Score: \n" + _score;

            _numberOfEnemies = 10;

            _x = (Helpers.Config.WIDTH - Enemy.ENEMYSIZE) / _numberOfEnemies + 10;
            
            for (int i = 0; i < _numberOfEnemies; i++)
            {
                _enemies.Add(new Enemy(_x * i , Enemy.ENEMYSIZE, Config.ENEMIESMAXLIFE, bullets));
            }
            
            lblLife.Location = new Point(Helpers.Config.WIDTH - 20 - lblLife.Size.Width / 2, 5);

            _score = 0;

            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with this form, and with
            // dimensions the same size as the drawing surface of the form.
            game = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            
            _player = player;
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

            foreach (EnemyBullet enemybullet in _enemyBullets)
            {
                enemybullet.Render(game);
            }

            _player.Render(game);

            foreach (Protection protection in _protections)
            {
                protection.Render(game);
            }

            game.Render();

        }

        private void Update(int interval,Player player, List<Bullet> bullets)
        {
            lblScore.Text = "Score: " + _score;
            lblLife.Text = string.Concat(Enumerable.Repeat("♥", player.Vie));

            _timer++;
            _enemySpawnTimer++;


            if (_enemySpawnTimer >= 50)
            {
                _numberOfEnemies = MathHelpers.alea.Next(2, 5);

                _x = (Helpers.Config.WIDTH - Enemy.ENEMYSIZE) / _numberOfEnemies + 10;
                _x += (_x / 4);
                for (int i = 0; i < _numberOfEnemies; i++)
                {
                    _enemies.Add(new Enemy(_x * i, -Enemy.ENEMYSIZE, Config.ENEMIESMAXLIFE, bullets));
                }
                _enemySpawnTimer = 0;
            }


            for (int i = _enemyBullets.Count - 1; i >= 0; i--)
            {
                _enemyBullets[i].Update(_enemyBullets, _protections, _player, _enemies);
            }

            _player.Update(interval, mousePos, _score);


            for (int i = _bullets.Count - 1; i >= 0; i--)
            {
                _bullets[i].Update(_bullets, _protections, _enemies);
            }

            for (int i = _enemies.Count - 1; i >= 0; i--)
            {
                _score = _enemies[i].Update(interval, _enemies, _protections, _enemyBullets, _score, player);
            }

        }

        // Méthode appelée à chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            if (_player.Vie <= 0)
            {

                this.Close();
            }
            else
            {
                mousePos = Form.ActiveForm != null ? Form.ActiveForm.PointToClient(Cursor.Position) : Cursor.Position;
                this.Update(ticker.Interval, _player,_bullets);
                this.Render();
            }


        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            _player.HandleInput(sender, e, _bullets, ticker.Interval, _protections,_player, _timer);

        }
        private void Game_MouseDown(object sender, MouseEventArgs e)
        {

            if (_timer >= 10)
            {
                _timer = 0;
                _player.Shoot(_bullets, ticker.Interval,_player);
            }

        }
    }
}