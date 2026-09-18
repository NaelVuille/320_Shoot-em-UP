using Drones.View;

namespace Joueurs
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
            Application.Run(new Game(new Joueur(Game.WIDTH / 2, Game.HEIGHT / 2, "Larbin")));
        }
    }
}