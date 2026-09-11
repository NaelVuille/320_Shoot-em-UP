using Drones.Helpers;
using Drones.Properties;
using System.Windows.Forms;

namespace Drones
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public class joueur
    {
        public int charge;                            // La charge actuelle de la batterie
        public string name;                           // Un nom
        public int x;                                 // Position en X depuis la gauche de l'espace aérien
        public int y;                                 // Position en Y depuis le haut de l'espace aérien
        public int speed_x;                           // Déplacement horizontal
        public int speed_y;                           // Déplacement vertical
        private float angle = 0f;                     // Variable pour stocker l'angle

        private Random _alea = new Random();

        // Constructeur
        public joueur(int x, int y, string name)
        {
            Random alea = new Random();
            this.x = x;
            this.y = y;
            this.name = name;
            charge = alea.Next(1000); // La charge initiale de la batterie est choisie aléatoirement
            ChangeDirection();
        }

        // Cette méthode calcule le nouvel état dans lequel le joueur se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {
            // Récupère la position de la souris relative à la fenêtre active
            Point mousePos = Form.ActiveForm != null ? Form.ActiveForm.PointToClient(Cursor.Position) : Cursor.Position;

            // Vecteur entre le centre du joueur (x + 100, y + 100) et la souris
            float dx = mousePos.X - (x + 100);
            float dy = mousePos.Y - (y + 100);

            // Calcul de l'angle en degrés
            angle = (float)(Math.Atan2(dy, dx) * 180.0 / Math.PI);
        }

        // Choisit une nouvelle vitesse aléatoirement
        public void ChangeDirection()
        {
            speed_x = _alea.Next(-3, 4);
            speed_y = _alea.Next(-3, 4);
        }

        /// //////////////////////////////////////////////////////////////////////////////
        //  
        //  Ce qui suit appartient à la vue, pas au modèle.
        //  Il aurait été préférable de séparer la déclaration de la classe Drone en deux,
        //  Nous regroupons tout ici pour simplifier
        //  
        /// //////////////////////////////////////////////////////////////////////////////

        private Pen droneBrush = new Pen(new SolidBrush(Color.Purple), 3);

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            Graphics g = drawingSpace.Graphics;
            var state = g.Save();

            // 1. Déplace le pivot au centre du joueur
            g.TranslateTransform(x + 100, y + 100);

            // 2. Vérifie si la souris pointe vers la gauche
            bool flipHorizontal = Math.Abs(angle) > 90;

            if (flipHorizontal)
            {
                // Inverse l'axe X (effet miroir)
                g.ScaleTransform(-1, 1);

                // Ajuste l'angle pour compenser le miroir (évite d'avoir la tête en bas)
                float mirroredAngle = angle > 0 ? 180 - angle : -180 - angle;
                g.RotateTransform(mirroredAngle);
            }
            else
            {
                // Rotation normale vers la droite
                g.RotateTransform(angle);
            }

            // 3. Dessin centré
            g.DrawImage(Resources.joueur, -100, -100, 200, 200);

            // 4. Restaure le repère
            g.Restore(state);
        }

        // De manière textuelle
        public override string ToString()
        {
            return $"{name} ({((int)((double)charge / 1000 * 100)).ToString()}%)";
        }


    }
}
