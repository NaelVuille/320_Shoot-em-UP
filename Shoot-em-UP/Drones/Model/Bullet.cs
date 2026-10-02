using Joueurs.Helpers;
using Shoot_em_up.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Shoot_em_up.Helpers;

namespace Shoot_em_up.Model
{
    public class Bullet
    {
        private int _x;
        private int _y;
        private float _angle;
        private int _incrX;
        private int _incrY;
     



        public Bullet(int x, int y, float angle, int interval)
        {
            _x = x;
            _y = y;
            _angle = angle;

            double rad = angle * Math.PI / 180.0;
            _incrX = (int)Math.Round(Math.Cos(rad) * Config.SPEED*10 * interval / 1000.0);
            _incrY = (int)Math.Round(Math.Sin(rad) * Config.SPEED*10 * interval / 1000.0);
        }

        public void Update(List<Bullet> bullets)
        {
            
            _x += _incrX;
            _y += _incrY;
        }
        public void Render(BufferedGraphics drawingSpace)
        {
            var state = drawingSpace.Graphics.Save();
            drawingSpace.Graphics.TranslateTransform(_x, _y);
            drawingSpace.Graphics.RotateTransform(_angle);
            drawingSpace.Graphics.DrawImage(Resources.Bullet, -15, -15, 30, 30);
            drawingSpace.Graphics.Restore(state);
        }
    }
}
