using Joueurs.Helpers;
using Shoot_em_up.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Shoot_em_up.Helpers;
using Ennemie_name;

namespace Shoot_em_up.Model
{
    public class Bullet
    {
        private int _x;
        private int _y;
        private float _angle;
        private int _incrX;
        private int _incrY;
        private int _timer;
        private const int _BULLETSIZE = 20;

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }

        public Bullet(int x, int y, float angle, int interval)
        {
            _x = x;
            _y = y;
            _angle = angle;

            _timer = 0;

            double rad = angle * Math.PI / 180.0;
            _incrX = (int)Math.Round(Math.Cos(rad) * Config.SPEED*100 * interval / 1000.0);
            _incrY = (int)Math.Round(Math.Sin(rad) * Config.SPEED*100 * interval / 1000.0);
        }

        public void Update(List<Bullet> bullets,List<Protection> protections,List<Ennemie> enemies)
        {
            _timer++;
            if(_timer >= 3)
            {
                bullets.Clear();
                return;
            }

            (_x,_y) = CollisionHelpers.VerifBullet(_x,_y,protections,this,bullets,_incrX,_incrY,enemies);
            

            
        }
        public void Render(BufferedGraphics drawingSpace)
        {
            var state = drawingSpace.Graphics.Save();
            drawingSpace.Graphics.TranslateTransform(_x, _y);
            drawingSpace.Graphics.RotateTransform(_angle);
            drawingSpace.Graphics.DrawImage(Resources.Bullet, -_BULLETSIZE/2, -_BULLETSIZE/2, _BULLETSIZE, _BULLETSIZE);
            drawingSpace.Graphics.Restore(state);
        }
    }
}
