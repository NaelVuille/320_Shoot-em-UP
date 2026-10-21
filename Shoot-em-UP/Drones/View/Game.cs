using Ennemie_name;
using Joueurs.Helpers;
using Shoot_em_up.Helpers;
using Shoot_em_up.Model;
using Shoot_em_up.View;
using System.Windows.Forms;

namespace Joueurs
{
    // La classe AirSpace représente le territoire au dessus duquel les drones peuvent voler
    // Il s'agit d'un formulaire (une fenêtre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient

    public partial class Game : Form
    {
        // Récupère la position de la souris relative à la fenêtre active
        Point mousePos = Form.ActiveForm != null ? Form.ActiveForm.PointToClient(Cursor.Position) : Cursor.Position;

        public static readonly int WIDTH = Helpers.Config.WIDTH;        // Dimensions
        public static readonly int HEIGHT = Helpers.Config.HEIGHT;

        // La flotte est l'ensemble des drones qui évoluent dans notre espace aérien
        private Joueur _joueur;

        private static int _score = 0;

        private static List<Bullet> _bullets = new List<Bullet>();

        private static int _timer = 10;

        private static int _numberEnnemis = 1;

        private static int _ennemiesSpawn = 30;

        private List<Ennemie> _ennemies = new List<Ennemie>();

        private List<Protection> _protections = new List<Protection>();

        BufferedGraphicsContext currentContext;
        BufferedGraphics game;

        public static int Timer { get => _timer; set => _timer = value; }
        public static List<Bullet> bullets { get => _bullets; set => _bullets = value; }
        public static int Score { get => _score; set => _score = value; }



        // Initialisation de l'espace aérien avec un certain nombre de drones
        public Game(Joueur joueur)
        {
            InitializeComponent();
            ClientSize = new Size(WIDTH, HEIGHT);

            lblScore.Font = TextHelpers.MediumFont;
            lblScore.Text = "Score: \n" + _score;

            lblLife.Location = new Point(WIDTH-20-lblLife.Size.Width/2, 5);

            _score = 0;

            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with this form, and with
            // dimensions the same size as the drawing surface of the form.
            game = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            _joueur = new Joueur(WIDTH / 2, HEIGHT - 30 - Joueur.PLAYERSIZE);

            const int _NOMBREPROTECTION = 5;
            for (int i = 0;i < _NOMBREPROTECTION; i++)
            {
                _protections.Add(new Protection(125 +WIDTH/_NOMBREPROTECTION*i, 450));
            }
            
        }

        // Affichage de la situation actuelle
        private void Render()
        {
            game.Graphics.Clear(Color.Black);

            for (int i = 0; i < _ennemies.Count; i++)
            {
                _ennemies[i].Render(game);
                if (_ennemies[i].Vie <= 0)
                {
                    _ennemies.RemoveAt(i);
                    _score += 125;
                }
            }

            foreach (Bullet bullet in _bullets)
            {
                bullet.Render(game);
            }

            _joueur.Render(game);

            foreach (Protection protection in _protections)
            {
                protection.Render(game);
            }

            game.Render();

        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        private void Update(int interval)
        {
            lblScore.Text = "Score: " + _score;
            lblLife.Text = string.Concat(Enumerable.Repeat("♥", Joueur.Vie));

            _timer++;
            _ennemiesSpawn++;

           
            if(_ennemiesSpawn >= 50)
            {
                _numberEnnemis = MathHelpers.alea.Next(1, 3);
                for (int i = 1; i <=_numberEnnemis; i++)
                    _ennemies.Add(new Ennemie(MathHelpers.alea.Next(-Ennemie.ENNEMIESIZE, WIDTH)/_numberEnnemis * i, -Ennemie.ENNEMIESIZE, 2));
                _ennemiesSpawn = 0;
            }

            for (int i = 0; i < _ennemies.Count; i++)
            {
                _ennemies[i].Update(interval, _ennemies,_protections);
            }

            _joueur.Update(interval, mousePos);


            for (int i = 0;i < _bullets.Count;i++)
            {
                _bullets[i].Update(_bullets,_protections);
            }

        }

        // Méthode appelée à chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            if (Joueur.Vie <= 0)
            {
                this.Close();
            }
            else
            {
                mousePos = Form.ActiveForm != null ? Form.ActiveForm.PointToClient(Cursor.Position) : Cursor.Position;
                this.Update(ticker.Interval);
                this.Render();
            }
            

        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            _joueur.Action(sender, e, _bullets, mousePos, ticker.Interval,_protections);

        }
        private void Game_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (_timer >= 10)
            {
                _timer = 0;
                _joueur.Shoot(_bullets, mousePos, ticker.Interval);
            }

        }
    }
}