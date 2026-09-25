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
        private int _angle;


        public Bullet(int x, int y,int angle)
        {
            _x = x;
            _y = y;
            _angle = angle;
        }
        public void Update(int interval, Point mousePos)
        {
            double distance = MathHelpers.Distance(_x, _y, mousePos.X, mousePos.Y);

            double dx = mousePos.X - _x;
            double dy = mousePos.Y - _y;
            _x += (int)(dx / distance * Config.SPEED * interval / 1000);
            _y += (int)(dy / distance * Config.SPEED * interval / 1000);
        }
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.RotateTransform(_angle);
            drawingSpace.Graphics.DrawImage(Resources.Bullet, _x, _y, 5, 5);
        }
    }
}
