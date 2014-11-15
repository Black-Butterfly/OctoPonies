Structure de fichier du projet
==============================


* Dossier GameSetup :

  Comprend, le Script d’InnoSetup pour créer l’installeur, les instructions d’installation et l’installeur.


* Dossier Objectif :

  Il contient tous les fiches d’itération et le tableau Excel des objectifs à la semaine avec leur avancement (couleur). Il contient aussi le rapport de bug où l’on retrouve les bugs rangé par fréquence / priorité


* Dossier Recup files :

  Contient des fichiers récupérés d’internet.


* Dossier Ressource :

  Il est divisé en 2 sous dossiers :
  - Music qui contient donc les musiques subdivisé par l’attrait du groupe pour celle-ci
  - Sprite où l’on retrouve par membre les éléments de graphisme fourni au projet


* Dossier UnityProject :

  Il contient le projet sur Unity, les seuls fichiers à modifier sont dans le dossier « Assets » les autres sont auto-généré et modifier par l’IDE.

  La structure du dossier « Assets » se présente ainsi :
  - Animations : On retrouve ici toutes les animations utilisés dans le projet, celle-ci sont créer et modifier avec l’IDE
  - Fonts : Polices d’écriture utilisée dans le programme
  - Prefabs : Ce sont les préfabriqué créer avec Unity cela permet d’avoir des objets ayant de base certaine propriété (Script, Animation, Box de collision, …) et ainsi ne pas avoir à tout refaire pour chaque monstre par exemple. Un paramètre modifier dans un préfab modifie tous les objets qui en découlent
  - Scenes : Contient toutes les scènes du jeu créé avec Unity (niveau, menu, …)
  - Scripts : Regroupe tous les scripts utilisé par le programme, ces scripts sont codée sous forme de class C#. On y retrouve souvent ces fonctions : Awake() et Start() s’exécutent 1 fois au lancement du script, Update() et FixedUpdate() s’exécutent à chaque frame dans le jeu.
  - Sounds : Contient les sons utilisés dans le jeu
  - Sprites : Ce sont toutes les textures utilisées dans le jeu

  *Note : tous les fichiers .meta sont générés par Unity*


* Dossier Wiki :

  Contient les diverses informations du projet.


A la racine de Git on trouve aussi des fichiers textes fournissant différent liens afin d’aider à prendre en main, corrigé des erreurs présentes, …
