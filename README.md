# Yams

L'objectif de ce projet est de développer une application C# en mode console qui permet à 2 joueurs de faire une partie de Yam's sur un même ordinateur puis d'afficher un récapitulatif de la partie sur un navigateur web en HTML-CSS-JS.

Le  programme  C#,  en  plus  de  la  gestion  du  jeu,  sera chargé  de  créer  un  fichier Json  qui  pourra  être  déposé  sur  un serveur dédié ( Malheureusement ce serveur a été supprimé après le rendu du projet).

La page web pourra récupérer à partir du serveur dédié, le flux Json associé à un fichier auparavant déposé afin de procéder à l'affichage de la partie.

## Partie gameplay en C#

### Situation de départ :

🎲 5 dés
👥 2 joueurs qui doivent saisir leur pseudo et qui partagent le même ordinateur
Une partie se déroule en 13 tours car un joueur doit choisir à chaque tour l'un des 13 challenges suivants qui devient inaccessible au tour suivant :

### Challenges mineurs

|Challenge | Objectif | Nombre de points|
|:----------:|:----------:|:-----------------:|
|Nombre de 1 | Obtenir le maximum de 1 | Somme des dés ayant obtenu 1 |
|Nombre de 2 | Obtenir le maximum de 2 | Somme des dés ayant obtenu 2 |
|Nombre de 3 | Obtenir le maximum de 3 | Somme des dés ayant obtenu 3 |
|Nombre de 4 | Obtenir le maximum de 4 | Somme des dés ayant obtenu 4 |
|Nombre de 5 | Obtenir le maximum de 5 | Somme des dés ayant obtenu 5 |
|Nombre de 6 | Obtenir le maximum de 6 | Somme des dés ayant obtenu 6 |

Bonus : Si la somme de la partie mineure atteint 63 le joueur reçoit un bonus de 35 points.

### Challenges majeurs

|Challenge | Objectif | Nombre de points |
|:----------:|:----------:|:------------------:|
|Brelan | Obtenir 3 dés de même valeur | Sommes des 3 dés identiques |
|Carré | Obtenir 4 dés de même valeur | Sommes des 4 dés identiques | 
|Full | Obtenir 3 dés de même valeur + 2 dés de même valeur | 25 points |
|Petite suite | Obtenir 1-2-3-4 ou 2-3-4-5 ou 3-4-5-6 | 30 points |
|Grande suite | Obtenir 1-2-3-4-5 ou 2-3-4-5-6 | 40 points |
|Yam's | Obtenir 5 dés de même valeur | 50 points |
|Chance | Obtenir le maximum de points | le total des dés obtenus |

### Un tour se déroule de la façon suivante :

\*Le joueur peut effectuer jusqu'à 3 lancés des 5 dés
\*1er lancé : le joueur lance les 5 dés
\*Le joueur indique les dés à garder, les autres vont être relancés
\*2ème lancé (facultatif) le joueur relance les dés non gardés
\*Le joueur indique les dés à garder, les autres vont être relancés
\*3ème lancé (facultatif) le joueur relance les dés non gardés
\*Le joueur indique son choix parmi les challenges disponibles et se voit affecter le nombre de points correspondants après, ou 0 si les dés obtenus ne remplissent pas les conditions du challenge choisi.

Le programme C# orchestre en mode console une partie pour 2 joueurs en gérant les lancés des dés et en proposant à chaque tour les challenges disponibles. Il affiche à chaque tour et pour chaque joueur un récapitulatif clair de la partie en cours afin qu'il puisse
prendre les bonnes décisions.

