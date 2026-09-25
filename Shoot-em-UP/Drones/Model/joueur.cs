using Joueurs.Helpers;
using Shoot_em_up.Model;
using Shoot_em_up.Properties;
using System.Runtime.InteropServices;
using System.Security.Policy;

namespace Joueurs
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public class Joueur
    {
        public int charge;                            // La charge actuelle de la batterie
        public int x;                                 // Position en X depuis la gauche de l'espace aérien
        public int y;                                 // Position en Y depuis le haut de l'espace aérien
        public int speed_x;                           // Déplacement horizontal
        public int speed_y;                           // Déplacement vertical

        private int angle = 0;                     // Variable pour stocker l'angle


        // Constructeur
        public Joueur(int x, int y)
        {
            this.x = x;
            this.y = y;
            
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
            angle = (int)(Math.Atan2(dy, dx) * 180.0 / Math.PI);
        }

        public void Shoot(List<Bullet> bullets)
        {
            for(int i = 0; i < 3; i++)
            {
                bullets.Add(new Bullet(x, y, angle - 1 + i));
            }
        }

        // déplacement
        public void Action(object sender, KeyEventArgs e,List<Bullet> bullet)
        {
            int barrierrd = 210;
            int barrierlu = 0;
            
                switch (e.KeyCode)
                {
                    case Keys.D:
                    case Keys.Right:
                        if (x >= Helpers.Config.WIDTH - barrierrd) break;
                        x += Helpers.Config.SPEED; 
                        break;

                    case Keys.A:
                    case Keys.Left:
                        if (x <= barrierlu) break;
                        x -= Helpers.Config.SPEED;
                        break;

                    case Keys.W:
                    case Keys.Up:
                        if (y <= barrierlu) break;
                        y -= Helpers.Config.SPEED;
                        break;

                    case Keys.S:
                    case Keys.Down:
                        if (y >= Helpers.Config.HEIGHT - barrierrd) break;
                        y += Helpers.Config.SPEED;
                        break;

                    case Keys.Space:
                    case Keys.LButton:
                        Shoot(bullet);
                    break;
            }
            
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
            

            //rotation
            
            var state = drawingSpace.Graphics.Save();

            // 1. Déplace le pivot au centre du joueur
            drawingSpace.Graphics.TranslateTransform(x + 100, y + 100);

            // 2. Vérifie si la souris pointe vers la gauche
            bool flipHorizontal = Math.Abs(angle) > 90;

            if (flipHorizontal)
            {
                // Inverse l'axe X (effet miroir)
                drawingSpace.Graphics.ScaleTransform(-1, 1);

                // Ajuste l'angle pour compenser le miroir (évite d'avoir la tête en bas)
                float mirroredAngle = angle > 0 ? 180 - angle : -180 - angle;
                drawingSpace.Graphics.RotateTransform(mirroredAngle);
            }
            else
            {
                // Rotation normale vers la droite
                drawingSpace.Graphics.RotateTransform(angle);
            }

            // 3. Dessin centré
            drawingSpace.Graphics.DrawImage(Resources.joueur, -100, -100, 200, 200);

            // 4. Restaure le repère
            drawingSpace.Graphics.Restore(state);
        }

        


    }
}
