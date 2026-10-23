using shootEmUp.Properties;
using System.Drawing.Text;
using System.Text;

namespace shootEmUp.Helpers
{
    // Outils pour écrire du texte dans un environnement graphique
    public static class TextHelpers
    {
        private static PrivateFontCollection pfc = new PrivateFontCollection();
        public static Font BigFont = null!;
        public static Font MediumFont = null!;
        public static Font SmallFont = null!;
        public static void Init()
        {
            string tempPath = Path.Combine(Path.GetTempPath(), "gameOver.ttf");

            
            if (!File.Exists(tempPath))
            {
                try
                {
                    File.WriteAllBytes(tempPath, shootEmUp.Properties.Resources.gameOver);
                }
                catch (IOException)
                {
                }
            }

            pfc.AddFontFile(tempPath);
            BigFont = new Font(pfc.Families[0], 148F, FontStyle.Regular, GraphicsUnit.Point);
            MediumFont = new Font(pfc.Families[0], 100F, FontStyle.Regular, GraphicsUnit.Point);
            SmallFont = new Font(pfc.Families[0], 50F, FontStyle.Regular, GraphicsUnit.Point);
            
        }
    }
}
