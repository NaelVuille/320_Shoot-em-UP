using shootEmUp.Model;


namespace shootEmUp.Helpers
{

    public static class CollisionHelpers
    {
        public static (int, int, int, int, int) GetProtectionBounds(Protection protection)
        {
            int protSize = Protection.PROTECTIONSIZE;
            int protLeft = protection.X - protSize / 2;
            int protRight = protection.X + protSize / 2;
            int protTop = protection.Y - protSize / 4;
            int protBottom = protection.Y + protSize / 4;

            return (protSize, protLeft, protRight, protTop, protBottom);
        }

        public static (int, int, int, int, int) GetEnemyBounds(Enemy enemy)
        {
            int enemySize = Enemy.ENEMYSIZE;
            int enemyLeft = enemy.X;
            int enemyRight = enemy.X + enemySize;
            int enemyTop = enemy.Y;
            int enemyBottom = enemy.Y + enemySize;

            return (enemySize, enemyLeft, enemyRight, enemyTop, enemyBottom);
        }


        public static (int, int) MoveEnemy(int x, int y, int deltaX, int deltaY, List<Protection> protections, int size, List<Enemy> enemies, Enemy thisEnemy)
        {
            int nextX = x + deltaX;
            int nextY = y + deltaY;

            bool canMoveX = true;
            bool canMoveY = true;

            foreach (Protection protection in protections)
            {
                (int protSize, int protLeft, int protRight, int protTop, int protBottom) = GetProtectionBounds(protection);

                // Test axe X
                int enemyRightX = nextX + size;
                int enemyBottomY = y + size;
                if (enemyRightX >= protLeft && nextX <= protRight &&
                    enemyBottomY >= protTop && y <= protBottom)
                {
                    canMoveX = false;
                }

                // Test axe Y
                int enemyRightX2 = x + size;
                int enemyBottomY2 = nextY + size;
                if (enemyRightX2 >= protLeft && x <= protRight &&
                    enemyBottomY2 >= protTop && nextY <= protBottom)
                {
                    canMoveY = false;
                }
            }
            foreach (Enemy enemy in enemies)
            {
                if (thisEnemy != enemy)
                {

                    (int enemySize, int enemyLeft, int enemyRight, int enemyTop, int enemyBottom) = GetEnemyBounds(enemy);

                    // Test axe X
                    int enemyRightX = nextX + size;
                    int enemyBottomY = y + size;
                    if (enemyRightX >= enemyLeft && nextX <= enemyRight &&
                        enemyBottomY >= enemyTop && y <= enemyBottom)
                    {
                        canMoveX = false;
                    }

                    // Test axe Y
                    int enemyRightX2 = x + size;
                    int enemyBottomY2 = nextY + size;
                    if (enemyRightX2 >= enemyLeft && x <= enemyRight &&
                        enemyBottomY2 >= enemyTop && nextY <= enemyBottom)
                    {
                        canMoveY = false;
                    }
                }
            }


            if (canMoveX) x = nextX;
            if (canMoveY) y = nextY;
            return (x, y);
        }

        public static (int, int) MovePlayer(int x, int y, int deltaX, int deltaY, List<Protection> protections, int size, int nextX, int nextY)
        {

            bool canMove = true;

            foreach (Protection protection in protections)
            {
                (int protSize, int protLeft, int protRight, int protTop, int protBottom) = GetProtectionBounds(protection);


                int playerLeft = nextX;
                int playerRight = nextX + size;
                int playerTop = nextY;
                int playerBottom = nextY + size;


                if (playerRight >= protLeft && playerLeft <= protRight &&
                    playerBottom >= protTop && playerTop <= protBottom)
                {
                    canMove = false;
                    break;
                }
            }

            if (canMove)
            {
                x = nextX;
                y = nextY;
            }
            return (x, y);
        }
        public static (int, int) CheckBulletCollisions(int x, int y, List<Protection> protections, Bullet bullet, List<Bullet> bullets, int incrX, int incrY, List<Enemy> enemies)
        {
            bool CanMove = true;

            float verifX = x;
            float verifY = y;

            foreach (Protection protection in protections)
            {
                verifX = x;
                verifY = y;

                (int protSize, int protLeft, int protRight, int protTop, int protBottom) = GetProtectionBounds(protection);

                for (int i = 0; i < 2; i++)
                {
                    if (verifX >= protLeft && verifX <= protRight &&
                        verifY >= protTop && verifY <= protBottom)
                    {
                        CanMove = false;
                        break;
                    }
                    verifX = x + incrX / 2;
                    verifY = y + incrY / 2;
                }

            }
            foreach (Enemy enemy in enemies)
            {
                verifX = x;
                verifY = y;

                (int enemySize, int enemyLeft, int enemyRight, int enemyTop, int enemyBottom) = GetEnemyBounds(enemy);

                for (int i = 0; i < 2; i++)
                {
                    if (verifX >= enemyLeft && verifX <= enemyRight &&
                        verifY >= enemyTop && verifY <= enemyBottom)
                    {
                        enemy.Vie--;
                        break;
                    }
                    verifX = x + incrX / 2;
                    verifY = y + incrY / 2;
                }

            }

            if (CanMove)
            {
                x += incrX;
                y += incrY;
            }
            else
            {
                bullets.Remove(bullet);
            }
            return (x, y);


        }

        public static (int, int) CheckEnemyBulletCollisions(int x, int y, List<Protection> protections, EnemyBullet enemyBullet, List<EnemyBullet> enemyBullets, int incrX, int incrY, Player player, List<Enemy> enemies, Enemy shooter)
        {
            bool CanMove = true;

            float verifX = x;
            float verifY = y;

            foreach (Protection protection in protections)
            {
                verifX = x;
                verifY = y;

                (int protSize, int protLeft, int protRight, int protTop, int protBottom) = GetProtectionBounds(protection);

                for (int i = 0; i < 2; i++)
                {
                    if (verifX >= protLeft && verifX <= protRight &&
                        verifY >= protTop && verifY <= protBottom)
                    {
                        CanMove = false;
                        break;
                    }
                    verifX = x + incrX / 2;
                    verifY = y + incrY / 2;
                }

            }
            foreach (Enemy enemy in enemies)
            {
                if (enemy != shooter)
                {
                    verifX = x;
                    verifY = y;

                    (int enemySize, int enemyLeft, int enemyRight, int enemyTop, int enemyBottom) = GetEnemyBounds(enemy);

                    for (int i = 0; i < 2; i++)
                    {
                        if (verifX >= enemyLeft && verifX <= enemyRight &&
                            verifY >= enemyTop && verifY <= enemyBottom)
                        {
                            enemy.Vie--;
                            CanMove = false;
                            break;
                        }
                        verifX = x + incrX / 2;
                        verifY = y + incrY / 2;
                    }
                }
            }

            verifX = x;
            verifY = y;


            int size = player.PLAYERSIZE;

            int playerLeft = player.X;
            int playerRight = player.X + size;
            int playerTop = player.Y;
            int playerBottom = player.Y + size;


            for (int i = 0; i < 2; i++)
            {
                if (verifX >= playerLeft && verifX <= playerRight &&
                    verifY >= playerTop && verifY <= playerBottom)
                {
                    CanMove = false;
                    player.Vie--;
                    break;
                }
                verifX = x + incrX / 2;
                verifY = y + incrY / 2;
            }

            verifX = x;
            verifY = y;
            
            if(verifX >= Config.WIDTH || verifX <= 0 ||
               verifY >= Config.HEIGHT || verifY <= 0)
            {
                CanMove = false;
            }

            if (CanMove)
            {
                x += incrX;
                y += incrY;
            }
            else
            {
                enemyBullets.Remove(enemyBullet);
            }

            return (x, y);

        }
    }
}
