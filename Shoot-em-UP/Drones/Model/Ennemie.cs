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
using System.Drawing;

namespace Ennemie_name
{
    public class Ennemie
    {
        private const int _ENNEMIESIZE = 100;
        private int _x;                             // Position en X (coin supérieur gauche)
        private int _y;                             // Position en Y (coin supérieur gauche)
        private int _vie;
        private List<Bullet> _bullets;
        private int _timer = 0;
        private bool _flip=false;

        // Constructeur
        public Ennemie(int x, int y, int vie,List<Bullet> bullets)
        {
            _x = x;
            _y = y;
            _vie = vie;
            _bullets = bullets;
        }

        public int Vie { get => _vie; set => _vie = value; }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }

        public static int ENNEMIESIZE => _ENNEMIESIZE;

        public void Shoot(List<EnemyBullet> bullets,int interval, Joueur joueur)
        {
            int posStartX;
            if (_flip)
            {
                posStartX = _x;
            }
            else 
            {
                posStartX = _x + _ENNEMIESIZE;
            }
            
            int posStartY = _y + _ENNEMIESIZE / 2;


            if (_timer >= 20)
            {
                if (_timer == 20)
                {
                    bullets.Add(new EnemyBullet(posStartX, posStartY, interval,_timer,this, joueur));
                }
                if (_timer >= 25)
                {
                    bullets.Add(new EnemyBullet(posStartX, posStartY, interval, _timer,this, joueur));
                    _timer = 0;
                }
            }

        }

        public int Update(int interval, List<Ennemie> ennemies, List<Protection> protections,List<EnemyBullet> bullets,int score,Joueur joueur)
        {
            if (_x <= joueur.X)
            {
                _flip = false;
            }
            else
            {
                _flip = true;
            }
            _timer++;
            
            Shoot(bullets,interval, joueur);

            int targetX = joueur.X + joueur.PLAYERSIZE / 2;
            int targetY = joueur.Y + joueur.PLAYERSIZE / 2;

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

            (_x,_y) = CollisionHelpers.EnemyMove(_x, _y,deltaX,deltaY,protections,_ENNEMIESIZE,ennemies,this);

            if (_vie <= 0)
            {
                _vie = 0;
                ennemies.Remove(this);
                score += 125;
            }

            return score;
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            var state = drawingSpace.Graphics.Save();
            Brush writingBrush = new SolidBrush(Color.Green);
            Font font = new Font("Segoe UI", 30F);
            string life = string.Concat(Enumerable.Repeat("♥", _vie));

            if (_flip)
            {
                
                drawingSpace.Graphics.TranslateTransform(_x + _ENNEMIESIZE, _y);
                drawingSpace.Graphics.ScaleTransform(-1, 1);
                drawingSpace.Graphics.DrawImage(Resources.ennemie, 0, 0, _ENNEMIESIZE, _ENNEMIESIZE);
                drawingSpace.Graphics.DrawString($"{life}",font , writingBrush, 0 , 0 - _ENNEMIESIZE / 2);

            }
            else
            { 
                drawingSpace.Graphics.DrawImage(Resources.ennemie, _x, _y, _ENNEMIESIZE, _ENNEMIESIZE);
                drawingSpace.Graphics.DrawString($"{life}", font, writingBrush, _x , _y - _ENNEMIESIZE / 2);

            }
            
            drawingSpace.Graphics.Restore(state);
        }
    }
}