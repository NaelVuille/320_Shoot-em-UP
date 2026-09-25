using Joueurs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoot_em_up.Helpers
{
    public static class ButtonHelper
    {
        public static void Configure(Button butt)
        {
            butt.Font = TextHelpers.MediumFont;
        }
    }
}
