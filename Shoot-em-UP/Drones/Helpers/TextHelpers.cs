using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using Drones.View;

namespace Joueurs.Helpers
{
    // Outils pour écrire du texte dans un environnement graphique
    internal static class TextHelpers
    {
        private static PrivateFontCollection pfc = new PrivateFontCollection();
        public static Font BigFont;
        public static Font MediumFont;
        public static void Init()
        {
            string fontPath = Path.Combine(Application.StartupPath, "Resources", "game_over.ttf");

            if (File.Exists(fontPath))
            {
                pfc.AddFontFile(fontPath);
                BigFont = new Font(pfc.Families[0], 148F, FontStyle.Regular, GraphicsUnit.Point);
                MediumFont = new Font(pfc.Families[0], 100F, FontStyle.Regular, GraphicsUnit.Point);
            }
        }
    }
}
