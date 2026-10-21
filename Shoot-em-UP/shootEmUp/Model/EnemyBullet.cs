using shootEmUp.Helpers;
using shootEmUp.Properties;

namespace shootEmUp.Model
{
    public class EnemyBullet
    {
        private int _x;
        private int _y;
        private float _angle;
        private int _incrX;
        private int _incrY;
        private const int _BULLETSIZE = 20;
        private static int _targetX;
        private static int _targetY;
        private Enemy _shooter;

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }

        public static int BULLETSIZE => _BULLETSIZE;

        public EnemyBullet(int x, int y, int interval,int timer,Enemy shooter,Player player)
        {
            _x = x;
            _y = y;
            _shooter = shooter;

            if (timer == 20)
            {
                _targetX = player.X + player.PLAYERSIZE / 2;
                _targetY = player.Y + player.PLAYERSIZE / 2;
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

        public void Update(List<EnemyBullet> enemyBullets, List<Protection> protections, Player players,List<Enemy> enemies)
        {

            (_x, _y) = CollisionHelpers.CheckEnemyBulletCollisions(_x, _y, protections, this, enemyBullets, _incrX, _incrY, players,enemies, _shooter);

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
