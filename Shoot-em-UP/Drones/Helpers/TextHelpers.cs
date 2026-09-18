using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Joueurs.Helpers
{
    // Outils pour écrire du texte dans un environnement graphique
    internal static class TextHelpers
    {
        private static PrivateFontCollection _privateFonts = new PrivateFontCollection();

        public static Font drawFont { get; private set; }
        public static SolidBrush writingBrush = new SolidBrush(Color.Black);

        // Constructeur statique : exécuté automatiquement au démarrage
        static TextHelpers()
        {
            ChargerPolice();
        }

        private static void ChargerPolice()
        {
            var assembly = Assembly.GetExecutingAssembly();

            // Recherche automatique de la ressource game_over.ttf dans l'assembly
            string nomRessource = null;
            foreach (string nom in assembly.GetManifestResourceNames())
            {
                if (nom.EndsWith("game_over.ttf", StringComparison.OrdinalIgnoreCase))
                {
                    nomRessource = nom;
                    break;
                }
            }

            if (nomRessource != null)
            {
                using (Stream stream = assembly.GetManifestResourceStream(nomRessource))
                {
                    if (stream != null)
                    {
                        byte[] fontData = new byte[stream.Length];
                        stream.Read(fontData, 0, (int)stream.Length);

                        IntPtr fontPtr = Marshal.AllocHGlobal(fontData.Length);
                        Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
                        _privateFonts.AddMemoryFont(fontPtr, fontData.Length);
                        Marshal.FreeHGlobal(fontPtr);

                        // game_over nécessite souvent une taille plus grande (ex: 40f à 72f)
                        drawFont = new Font(_privateFonts.Families[0], 48f, FontStyle.Regular);
                        return;
                    }
                }
            }

            // Solution de repli si la ressource n'est pas trouvée
            drawFont = new Font(FontFamily.GenericSansSerif, 12f);
        }
    }
}
