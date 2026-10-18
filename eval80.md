# Évaluation intermédiaire (80 %) – Naël Vuille-Bille

## Synthèse

Le personnage pivote vers la souris (avec un effet miroir pour ne pas avoir la tête en bas), se déplace en WASD ou aux flèches et tire 3 balles en éventail. Les ennemis apparaissent en haut et poursuivent le joueur. **Il n'y a ni obstacles, ni tirs ennemis, ni score, ni vies, ni fin de partie.** Un écran d'accueil existe mais il est désactivé. L'organisation du code est confuse (5 namespaces différents) et plusieurs bugs faussent le gameplay.

## Points à améliorer d'ici au rendu final (30.10)

1. Corriger la durée de vie des balles (chaque balle se supprime elle-même, avec un parcours à l'envers dans `Game`).
2. Obstacles, tirs ennemis, vies, score, victoire et défaite, ≥ 10 ennemis.
3. Un seul namespace racine (`ShootEmUp`).
4. Retirer le `static` de la position du joueur et passer les dépendances en paramètre.
5. Mettre à jour le rapport.
6. Ajouter des tests unitaires
