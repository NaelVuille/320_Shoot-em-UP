using shootEmUp.Properties;
using System.Text;

namespace shootEmUp.Helpers
{
    // Outils pour écrire du texte dans un environnement graphique
    public static class Config
    {
        public const int SPEED = 10;

        public static bool isBig = false;
        public static int width = 1280;        // Dimensions
        public static int height = 720;
        public static bool play = true;
        public const int ENEMIESMAXLIFE = 2;

        public static int HIGHSCORE => Properties.Settings.Default.HighScore;
    }
}
