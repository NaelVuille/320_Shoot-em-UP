using shootEmUp.Helpers;
using shootEmUp.Properties;

namespace shootEmUp.Model
{
    public class Enemy
    {
        private const int _ENEMYSIZE = 100;
        private int _x;                             // Position en X (coin supérieur gauche)
        private int _y;                             // Position en Y (coin supérieur gauche)
        private int _life;
        private List<Bullet> _bullets;
        private int _timer = 0;
        private bool _flip=false;

        // Constructeur
        public Enemy(int x, int y, int life,List<Bullet> bullets)
        {
            _x = x;
            _y = y;
            _life = life;
            _bullets = bullets;
        }

        public int Life { get => _life; set => _life = value; }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }

        public static int ENEMYSIZE => _ENEMYSIZE;

        public void Shoot(List<EnemyBullet> bullets,int interval, Player player)
        {
            int posStartX;
            if (_flip)
            {
                posStartX = _x;
            }
            else 
            {
                posStartX = _x + _ENEMYSIZE;
            }
            
            int posStartY = _y + _ENEMYSIZE / 2;


            if (_timer >= 20)
            {
                if (_timer == 20)
                {
                    bullets.Add(new EnemyBullet(posStartX, posStartY, interval,_timer,this, player));
                }
                if (_timer >= 25)
                {
                    bullets.Add(new EnemyBullet(posStartX, posStartY, interval, _timer,this, player));
                    _timer = 0;
                }
            }

        }

        public int Update(int interval, List<Enemy> enemies, List<Protection> protections,List<EnemyBullet> bullets,int score,Player player)
        {
            if (_x <= player.X)
            {
                _flip = false;
            }
            else
            {
                _flip = true;
            }
            _timer++;
            
            Shoot(bullets,interval, player);

            int targetX = player.X + player.PLAYERSIZE / 2;
            int targetY = player.Y + player.PLAYERSIZE / 2;

            int enemyCenterX = _x + _ENEMYSIZE / 2;
            int enemyCenterY = _y + _ENEMYSIZE / 2;

            double distance = MathHelpers.Distance(enemyCenterX, enemyCenterY, targetX, targetY);

            int deltaX = 0;
            int deltaY = 0;

            if (distance <= Config.SPEED * 5 * interval / 1000)
            {
                deltaX = targetX - _ENEMYSIZE / 2 - _x;
                deltaY = targetY - _ENEMYSIZE / 2 - _y;
            }
            else if (distance > 0)
            {
                float dx = targetX - enemyCenterX;
                float dy = targetY - enemyCenterY;
                deltaX = (int)(dx / distance * Config.SPEED * 5 * interval / 1000);
                deltaY = (int)(dy / distance * Config.SPEED * 5 * interval / 1000);
            }

            (_x,_y) = CollisionHelpers.MoveEnemy(_x, _y,deltaX,deltaY,protections,_ENEMYSIZE,enemies,this);

            if (_life <= 0)
            {
                _life = 0;
                enemies.Remove(this);
                score += 125;
            }

            return score;
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            var state = drawingSpace.Graphics.Save();

            int imageSize = 25;
            int heartsY = -imageSize - 10; // Au-dessus de l'ennemi

            if (_flip)
            {
                

                drawingSpace.Graphics.TranslateTransform((_x + _ENEMYSIZE), _y);
                drawingSpace.Graphics.ScaleTransform(-1, 1);
            }
            else
            {
                // On place l'origine normalement sur le coin supérieur gauche de l'ennemi
                drawingSpace.Graphics.TranslateTransform(_x, _y);
                drawingSpace.Graphics.ScaleTransform(1, 1);
            }


            // Dessin de l'ennemi à l'origine (0, 0) de notre nouveau repère transformé
            drawingSpace.Graphics.DrawImage(Resources.enemy, 0, 0, _ENEMYSIZE, _ENEMYSIZE);

            // Largeur totale occupée par tous les cœurs
            int totalHeartsWidth = _life * imageSize;

            // Point de départ X pour centrer les cœurs au milieu de l'ennemi (par rapport à son centre _ENEMYSIZE / 2)
            int startX = (_ENEMYSIZE / 2) - (totalHeartsWidth / 2);

            // Boucle pour dessiner chaque cœur
            for (int i = 0; i < _life; i++)
            {
                int heartX = startX + (i * imageSize);
                drawingSpace.Graphics.DrawImage(Resources.enemyLifeHeart, heartX, heartsY, imageSize, imageSize);
            }

            drawingSpace.Graphics.Restore(state);
        }
    }
}