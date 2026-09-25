using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoot_em_up.Helpers
{
    // Outils pour des calculs mathématiques
    internal static class MathHelpers
    {
        // Distance euclidienne entre les points (x1, y1) et (x2, y2)
        public static double Distance(double x1, double y1, double x2, double y2)
        {
            double dx = x2 - x1;
            double dy = y2 - y1;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
