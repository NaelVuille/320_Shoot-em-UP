using Joueurs.Helpers;
using Shoot_em_up.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Shoot_em_up.Helpers;
using Joueurs;
using Shoot_em_up.Model;

namespace Ennemie_name
{
    public class Ennemie
    {
        private const int _ENNEMIESIZE = 100;
        private int _x;                             // Position en X (coin supérieur gauche)
        private int _y;                             // Position en Y (coin supérieur gauche)
        private int _vie;
        private List<Bullet> bullets = Game.bullets;

        // Constructeur
        public Ennemie(int x, int y, int vie)
        {
            _x = x;
            _y = y;
            _vie = vie;
        }

        public int Vie { get => _vie; set => _vie = value; }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }

        public static int ENNEMIESIZE => _ENNEMIESIZE;

        public void Update(int interval, List<Ennemie> ennemies, List<Protection> protections)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].X >= _x && bullets[i].X <= _x + _ENNEMIESIZE &&
                    bullets[i].Y >= _y && bullets[i].Y <= _y + _ENNEMIESIZE)
                {
                    _vie--;
                }
            }

            int targetX = Joueur.X + Joueur.PLAYERSIZE / 2;
            int targetY = Joueur.Y + Joueur.PLAYERSIZE / 2;

            int enemyCenterX = _x + _ENNEMIESIZE / 2;
            int enemyCenterY = _y + _ENNEMIESIZE / 2;

            double distance = MathHelpers.Distance(enemyCenterX, enemyCenterY, targetX, targetY);

            int deltaX = 0;
            int deltaY = 0;

            if (distance <= Config.SPEED * 5 * interval / 1000)
            {
                deltaX = targetX - _ENNEMIESIZE / 2 - _x;
                deltaY = targetY - _ENNEMIESIZE / 2 - _y;
            }
            else if (distance > 0)
            {
                float dx = targetX - enemyCenterX;
                float dy = targetY - enemyCenterY;
                deltaX = (int)(dx / distance * Config.SPEED * 5 * interval / 1000);
                deltaY = (int)(dy / distance * Config.SPEED * 5 * interval / 1000);
            }

            (_x,_y) = CollisionHelpers.EnnemieMove(_x, _y,deltaX,deltaY,protections,_ENNEMIESIZE);
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            var state = drawingSpace.Graphics.Save();

            
            if (_x > Joueur.X)
            {
                
                drawingSpace.Graphics.TranslateTransform(_x + _ENNEMIESIZE, _y);
                drawingSpace.Graphics.ScaleTransform(-1, 1);
                drawingSpace.Graphics.DrawImage(Resources.ennemie, 0, 0, _ENNEMIESIZE, _ENNEMIESIZE);
            }
            else
            {
                
                drawingSpace.Graphics.DrawImage(Resources.ennemie, _x, _y, _ENNEMIESIZE, _ENNEMIESIZE);
            }

            drawingSpace.Graphics.Restore(state);
        }
    }
}