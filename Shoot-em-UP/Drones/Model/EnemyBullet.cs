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
using Ennemie_name;

namespace Shoot_em_up.Model
{
    public class EnemyBullet
    {
        private int _x;
        private int _y;
        private float _angle;
        private int _incrX;
        private int _incrY;
        private const int _BULLETSIZE = 20;
        private static int _targetX = Joueur.X + Joueur.PLAYERSIZE / 2;
        private static int _targetY = Joueur.Y + Joueur.PLAYERSIZE / 2;
        private Ennemie _shooter;

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }

        public static int BULLETSIZE => _BULLETSIZE;

        public EnemyBullet(int x, int y, int interval,int timer,Ennemie shooter)
        {
            _x = x;
            _y = y;
            _shooter = shooter;

            if (timer == 20)
            {
                _targetX = Joueur.X + Joueur.PLAYERSIZE / 2;
                _targetY = Joueur.Y + Joueur.PLAYERSIZE / 2;
            }

            int bulletCenterX = _x + EnemyBullet.BULLETSIZE / 2;
            int bulletCenterY = _y + EnemyBullet.BULLETSIZE / 2;

            double distance = MathHelpers.Distance(bulletCenterX, bulletCenterY, _targetX, _targetY);


            float dx = _targetX - bulletCenterX;
            float dy = _targetY - bulletCenterY;

            _incrX = (int)(dx / distance * Config.SPEED * 15 * interval / 1000);
            _incrY = (int)(dy / distance * Config.SPEED * 15 * interval / 1000);

            _angle = (float)(Math.Atan2(dy, dx) * (180.0 / Math.PI));
        }

        public void Update(List<EnemyBullet> enemyBullets, List<Protection> protections, Joueur joueurs,List<Ennemie> enemies)
        {

            (_x, _y) = CollisionHelpers.VerifEnemyBullet(_x, _y, protections, this, enemyBullets, _incrX, _incrY, joueurs,enemies, _shooter);

        }
        public void Render(BufferedGraphics drawingSpace)
        {
            var state = drawingSpace.Graphics.Save();
            drawingSpace.Graphics.TranslateTransform(_x, _y);
            drawingSpace.Graphics.RotateTransform(_angle);
            drawingSpace.Graphics.DrawImage(Resources.EnemyBullet, -_BULLETSIZE / 2, -_BULLETSIZE / 2, _BULLETSIZE, _BULLETSIZE);
            drawingSpace.Graphics.Restore(state);
        }
    }
}
