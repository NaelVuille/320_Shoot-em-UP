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
        private int _x;                                 // Position en X depuis la gauche de l'affichage
        private int _y;                                 // Position en Y depuis le haut de l'affichage
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

        public static int ENNEMIESIZE => _ENNEMIESIZE;

        public void Update(int interval, List<Ennemie> ennemies)
        {

            for (int i = 0; i < bullets.Count - 1; i++)
            {
                if (MathHelpers.Distance(_x, _y, bullets[i].X, bullets[i].Y) <= _ENNEMIESIZE)
                {
                    _vie--;
                }
            }


            int targetX = Joueur.X + 50;
            int targetY = Joueur.Y + 50;
            double distance = MathHelpers.Distance(_x, _y, targetX, targetY);
            if (distance <= Config.SPEED * 5 * interval / 1000)                 // L'objectif est atteint (ou tout proche)
            {
                _x = targetX;
                _y = targetY;
            }


            float dx = targetX - _x;
            float dy = targetY - _y;
            _x += (int)(dx / distance * Config.SPEED * 5 * interval / 1000);
            _y += (int)(dy / distance * Config.SPEED * 5 * interval / 1000);
        }
        public void Render(BufferedGraphics drawingSpace)
        {
            
            var state = drawingSpace.Graphics.Save();

            if (_x - Joueur.X > 0)
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
