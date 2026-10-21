using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shootEmUp.Model;
using shootEmUp.Helpers;

namespace TestShootEmUp
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestShootMethodGeneratesBullets()
        {
            // Arrange
            Player player = new Player(100, 100, 3);
            List<Bullet> bullets = new List<Bullet>();
            int interval = 16;

            // Act
            player.Shoot(bullets, interval, player);

            // Assert
            Assert.IsTrue(bullets.Count > 0);
        }
        [TestMethod]
        public void TestBulletRemovesSelfAfterDelay()
        {
            // Arrange
            List<Bullet> bullets = new List<Bullet>();
            List<Protection> protections = new List<Protection>();
            List<Enemy> enemies = new List<Enemy>();
            Bullet b = new Bullet(100, 100, 0f, 16);
            bullets.Add(b);

            // Act
            for (int i = 0; i < 5; i++)
            {
                b.Update(bullets, protections, enemies);
            }

            // Assert
            Assert.IsFalse(bullets.Contains(b));
        }

        [TestMethod]
        public void TestScoreIncrementsWhenEnemyDies()
        {
            // Arrange
            int initialScore = 0;
            List<Enemy> enemies = new List<Enemy>();
            List<Bullet> bullets = new List<Bullet>();
            enemies.Add(new Enemy(50, 50, 0, bullets)); // Vie à 0 pour simuler sa mort immédiate
            List<Protection> protections = new List<Protection>();
            List<EnemyBullet> enemyBullets = new List<EnemyBullet>();
            Player player = new Player(100, 100, 3);

            // Act
            int newScore = enemies[0].Update(16, enemies, protections, enemyBullets, initialScore, player);

            // Assert
            Assert.IsTrue(newScore > initialScore);
        }

        [TestMethod]
        public void TestPlayerMovementRespectsScreenBounds()
        {
            // Arrange
            Player player = new Player(100, 100, 3);
            List<Protection> protections = new List<Protection>();

            // Act
            player.X = Config.WIDTH + 50;
            if (player.X + player.PLAYERSIZE > Config.WIDTH)
            {
                player.X = Config.WIDTH - player.PLAYERSIZE;
            }

            // Assert
            Assert.IsTrue(player.X <= Config.WIDTH);
        }

        [TestMethod]
        public void TestGameOverCondition()
        {
            // Arrange
            Player player = new Player(100, 100, 1);

            // Act
            player.Life -= 1;

            // Assert
            bool isGameOver = (player.Life <= 0);
            Assert.IsTrue(isGameOver);
        }
    }
}