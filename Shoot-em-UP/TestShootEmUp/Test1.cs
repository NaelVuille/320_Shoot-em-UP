using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shootEmUp.Model;
using shootEmUp.Helpers;
using System.Drawing;
using shootEmUp.View;
using System.Numerics;

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
            
            // Act
            player.Shoot(bullets, 16, player);

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
            Bullet bullet = new Bullet(100, 100, 0f, 16);
            bullets.Add(bullet);

            // Act
            for (int i = 0; i < 5; i++)
            {
                bullet.Update(bullets, protections, enemies);
            }

            // Assert
            Assert.IsFalse(bullets.Contains(bullet));
        }

        [TestMethod]
        public void TestScoreIncrementsWhenEnemyDies()
        {
            // Arrange
            int initialScore = 0;
            List<Enemy> enemies = new List<Enemy>();
            List<Bullet> bullets = new List<Bullet>();
            enemies.Add(new Enemy(50, 50, 1, bullets)); 
            List<Protection> protections = new List<Protection>();
            List<EnemyBullet> enemyBullets = new List<EnemyBullet>();
            Player player = new Player(100, 100, 3);

            // Act
            enemies[0].Life--;
            int newScore = enemies[0].Update(16, enemies, protections, enemyBullets, initialScore, player);

            // Assert
            Assert.IsTrue(newScore > initialScore);
        }

        [TestMethod]
        public void TestPlayerMovementRespectsCollisionWithScreen()
        {
            // Arrange
            Player player = new Player(100, Config.HEIGHT, 3);
            List<Protection> protections = new List<Protection>();
            int initialX = player.X;
            int deltaX = 10;
            int deltaY = 10;
            int nextX = player.X + 10;
            int nextY = player.Y + 10;

            // Act
            CollisionHelpers.MovePlayer(player.X, player.Y,deltaX,deltaY,protections,player.PLAYERSIZE,nextX,nextY);
            int newX= player.X;
            int newY= player.Y;

            // Assert
            Assert.IsTrue(newX == initialX);
        }

        [TestMethod]
        public void TestPlayerMovementRespectsCollisionWithprotection()
        {
            // Arrange
            Player player = new Player(100, 100, 3);
            List<Protection> protections = new List<Protection>();
            protections.Add(new Protection(100, 100));
            int initialX = player.X;
            int deltaX = 10;
            int deltaY = 10;
            int nextX = player.X + 10;
            int nextY = player.Y + 10;

            // Act
            CollisionHelpers.MovePlayer(player.X, player.Y, deltaX, deltaY, protections, player.PLAYERSIZE, nextX, nextY);
            int newX = player.X;
            int newY = player.Y;

            // Assert
            Assert.IsTrue(newX == initialX);
        }
    }
}