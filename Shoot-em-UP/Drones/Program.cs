using shootEmUp.Model;
using shootEmUp.View;


namespace shootEmUp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            

            // Démarrage
            
            Application.Run(new Accueil());
            while (Helpers.Config.play)
            {
                Joueur joueur;
                Application.Run(new Game(joueur = new Joueur(Helpers.Config.WIDTH / 2, Helpers.Config.HEIGHT - 150, 3), new List<Bullet>()));
                Application.Run(new End_Game(joueur.Score));
            }

        }
    }
}