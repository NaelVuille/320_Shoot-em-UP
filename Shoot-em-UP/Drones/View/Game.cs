using Shoot_em_up.Model;

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

        public List<Bullet> bullets = new List<Bullet>();

        BufferedGraphicsContext currentContext;
        BufferedGraphics game;

        // Initialisation de l'espace aérien avec un certain nombre de drones
        public Game(Joueur joueur)
        {
            InitializeComponent();
            ClientSize = new Size(WIDTH, HEIGHT);

            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with this form, and with
            // dimensions the same size as the drawing surface of the form.
            game = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            _joueur = new Joueur(WIDTH/2,HEIGHT/10*7);
        }

        // Affichage de la situation actuelle
        private void Render()
        {
            game.Graphics.Clear(Color.Black);

            _joueur.Render(game);

            game.Render();
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        private void Update(int interval)
        {
            _joueur.Update(interval,mousePos);
        }

        // Méthode appelée à chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            this.Update(ticker.Interval);
            this.Render();
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            _joueur.Action(sender, e,bullets);
            
        }
    }
}