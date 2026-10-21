using Joueurs.Helpers;
using Shoot_em_up.Helpers;
using Shoot_em_up.Model;
using Shoot_em_up.Properties;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Threading;

namespace Joueurs
{
    public class Joueur
    {
        private const int _PLAYERSIZE = 125;

        private static int _x;                                 // Position en X depuis la gauche de l'affichage
        private static int _y;                                 // Position en Y depuis le haut de l'affichage
        private float _angle = 0;                     // Variable pour stocker l'angle
        private static int _vie = 3;

        public static int X { get => _x; set => _x = value; }
        public static int Y { get => _y; set => _y = value; }

        public static int PLAYERSIZE => _PLAYERSIZE;

        public static int Vie { get => _vie; set => _vie = value; }

        // Constructeur
        public Joueur(int x, int y)
        {
            _x = x;
            _y = y;
            _vie = 3;

        }


        // Cette méthode calcule le nouvel état dans lequel le joueur se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval, Point mousePos)
        {
            // Vecteur entre le centre du joueur et la souris
            float dx = mousePos.X - (_x + _PLAYERSIZE/2);
            float dy = mousePos.Y - (_y + _PLAYERSIZE / 2);

            
            _angle = (float)(Math.Atan2(dy, dx) * 180.0 / Math.PI);
        }

        public void Shoot(List<Bullet> bullets, int interval)
        { 
            float distanceDuCanon = 45.0f;

            float[] angleOffsets = { -5f, -0f, 5f };

            for (int i = 0; i < 3; i++)
            {
                float bulletAngle = _angle + angleOffsets[i];
                double angleRadians = bulletAngle * Math.PI / 180.0;

                double offsetX = Math.Cos(angleRadians) * distanceDuCanon;
                double offsetY = Math.Sin(angleRadians) * distanceDuCanon;

                int pointDepartX = (int)(_x + Joueur.PLAYERSIZE /2 + offsetX);
                int pointDepartY = (int)(_y  + Joueur.PLAYERSIZE/2 + offsetY);

                bullets.Add(new Bullet(pointDepartX, pointDepartY, bulletAngle, interval));
                
            }
            
        }

        // déplacement
        public void Action(object sender, KeyEventArgs e, List<Bullet> bullet, int interval, List<Protection> protections)
        {
 
            switch (e.KeyCode)
            {
                case Keys.D:
                case Keys.Right:
                    MovePlayer(Helpers.Config.SPEED, 0, protections);
                    break;

                case Keys.A:
                case Keys.Left:
                    MovePlayer(-Helpers.Config.SPEED, 0,protections);
                    break;

                case Keys.W:
                case Keys.Up:
                    MovePlayer(0, -Helpers.Config.SPEED, protections);
                    break;

                case Keys.S:
                case Keys.Down:
                    MovePlayer(0, Helpers.Config.SPEED, protections);
                    break;

                case Keys.Space:
                    if (Game.Timer >= 10)
                    {
                        Game.Timer = 0;
                        Shoot(bullet, interval);
                    }
                    break;
            }

        }
        private void MovePlayer(int deltaX, int deltaY, List<Protection> protections)
        {
            int barrierrd = 0;
            int barrierlu = 0;

            int nextX = _x + deltaX;
            int nextY = _y + deltaY;

            if (nextX < barrierlu || nextX + _PLAYERSIZE > Helpers.Config.WIDTH - barrierrd) return;
            if (nextY < barrierlu || nextY + _PLAYERSIZE > Helpers.Config.HEIGHT - barrierrd) return;

            (_x,_y)= CollisionHelpers.JoueurMove(_x, _y, deltaX, deltaY, protections, _PLAYERSIZE, nextX, nextY);
        }

        /// //////////////////////////////////////////////////////////////////////////////
        //  
        //  Ce qui suit appartient à la vue, pas au modèle.
        //  Il aurait été préférable de séparer la déclaration de la classe Drone en deux,
        //  Nous regroupons tout ici pour simplifier
        //  
        /// //////////////////////////////////////////////////////////////////////////////



        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {


            //rotation

            var state = drawingSpace.Graphics.Save();

            // 1. Déplace le pivot au centre du joueur
            drawingSpace.Graphics.TranslateTransform(_x + _PLAYERSIZE/2, _y + _PLAYERSIZE/2);

            // 2. Vérifie si la souris pointe vers la gauche
            bool flipHorizontal = Math.Abs(_angle) > 90;

            if (flipHorizontal)
            {
                // Inverse l'axe X (effet miroir)
                drawingSpace.Graphics.ScaleTransform(-1, 1);

                // Ajuste l'angle pour compenser le miroir (évite d'avoir la tête en bas)
                float mirroredAngle = (_angle > 0 ? 180 - _angle : -180 - _angle);
                drawingSpace.Graphics.RotateTransform(mirroredAngle);
            }
            else
            {
                // Rotation normale vers la droite
                drawingSpace.Graphics.RotateTransform(_angle);
            }

            // 3. Dessin centré
            drawingSpace.Graphics.DrawImage(Resources.joueur, -_PLAYERSIZE/2, -_PLAYERSIZE/2, _PLAYERSIZE, _PLAYERSIZE);

            // 50. Restaure le repère
            drawingSpace.Graphics.Restore(state);
        }




    }
}
