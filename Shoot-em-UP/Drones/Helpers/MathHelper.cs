using Ennemie_name;
using Shoot_em_up.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Shoot_em_up.Helpers
{
    // Outils pour des calculs mathématiques
    public static class MathHelpers
    {
        // Distance euclidienne entre les points (x1, y1) et (x2, y2)
        public static double Distance(double x1, double y1, double x2, double y2)
        {
            double dx = x2 - x1;
            double dy = y2 - y1;
            return Math.Sqrt(dx * dx + dy * dy);
        }
        
        public static Random alea = new Random();

        public static (int,int) CanMove(int x, int y,int deltaX,int deltaY,List<Protection> protections,int size)
        {
            int nextX = x + deltaX;
            int nextY = y + deltaY;

            bool canMoveX = true;
            bool canMoveY = true;

            foreach (Protection protection in protections)
            {
                int protSize = Protection.PROTECTIONSIZE;
                int protLeft = protection.X - protSize / 2;
                int protRight = protection.X + protSize / 2;
                int protTop = protection.Y - protSize / 4;
                int protBottom = protection.Y + protSize / 4;

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


            if (canMoveX) x = nextX;
            if (canMoveY) y = nextY;
            return (x, y);
        }

        public static (int, int) CanMove(int x, int y, int deltaX, int deltaY, List<Protection> protections,int size,int nextX, int nextY)
        {

            bool canMove = true;

            foreach (Protection protection in protections)
            {
                int protSize = Protection.PROTECTIONSIZE;


                int protLeft = protection.X - protSize / 2;
                int protRight = protection.X + protSize / 2;
                int protTop = protection.Y - protSize / 4;
                int protBottom = protection.Y + protSize / 4;


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

    }
}
