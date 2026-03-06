# PacPanic

Un jeu PacMan créé avec Unity 2020 utilisant le système d'input Legacy.

## Configuration du Projet

### Structure des Dossiers
```
Assets/
├── Scripts/
│   ├── PacmanController.cs
│   ├── GhostAI.cs
│   ├── PelletManager.cs
│   ├── GameManager.cs
│   └── CollisionHandler.cs
└── Prefabs/
    ├── Pacman.prefab
    ├── Ghost.prefab
    └── Pellet.prefab
```

### Scripts Créés

1. **PacmanController.cs** - Contrôle du joueur
   - Mouvement avec flèches directionnelles ou WASD (Input Legacy)
   - Système de grille pour un mouvement fluide
   - Animation directionnelle

2. **GhostAI.cs** - Intelligence artificielle des fantômes
   - Poursuit le joueur à proximité
   - Déplacement aléatoire sinon
   - Vitesse configurable

3. **PelletManager.cs** - Gestion des pellets
   - Génération aléatoire des pellets
   - Comptage des pellets restants
   - Détection de victoire

4. **GameManager.cs** - Gestionnaire principal du jeu
   - Gestion des vies
   - Système de score
   - Spawn des objets

5. **CollisionHandler.cs** - Gestion des collisions
   - Interaction avec les pellets
   - Contact avec les fantômes

## Installation dans Unity 2020

### Étapes de Configuration

1. **Ouvrir/Créer un projet Unity 2020**
   - File → New Project
   - Sélectionner 2D (Core)

2. **Importer les Scripts**
   - Créer dossier `Assets/Scripts`
   - Copier tous les fichiers .cs

3. **Créer les Tags**
   - Edit → Project Settings → Tags and Layers
   - Ajouter les tags: "Player", "Ghost", "Pellet"

4. **Configurer l'Input Legacy**
   - Dans le menu Edit → Project Settings → Input Manager
   - Vérifier que les touches suivantes sont configurées:
     - Horizontal (Flèches gauche/droite, A/D)
     - Vertical (Flèches haut/bas, W/S)

5. **Créer les Prefabs**

   **Pacman:**
   - Create Empty GameObject → renommer "Pacman"
   - Ajouter SpriteRenderer (jaune ou couleur personnalisée)
   - Ajouter BoxCollider2D (Is Trigger: OFF)
   - Ajouter CircleCollider2D (Is Trigger: ON)
   - Ajouter script PacmanController
   - Ajouter script CollisionHandler
   - Faire Prefab dans Assets/Prefabs/

   **Ghost:**
   - Create Empty GameObject → renommer "Ghost"
   - Ajouter SpriteRenderer (rouge, bleu, rose, ou orange)
   - Ajouter BoxCollider2D (Is Trigger: OFF)
   - Ajouter CircleCollider2D (Is Trigger: ON)
   - Ajouter script GhostAI
   - Faire Prefab dans Assets/Prefabs/

   **Pellet:**
   - Create Empty GameObject → renommer "Pellet"
   - Ajouter SpriteRenderer (petite taille)
   - Ajouter CircleCollider2D (Is Trigger: ON)
   - Ajouter tag "Pellet"
   - Faire Prefab dans Assets/Prefabs/

6. **Configurer la Scène**
   - Create → Scene
   - Ajouter Camera 2D
   - Créer un GameObject vide "GameManager"
     - Ajouter script GameManager
     - Assigner les prefabs dans l'inspecteur
     - Créer des Transform enfants pour spawn points
   - Créer une grid visuelle avec des GameObjects (murs optionnels)

7. **Contrôles du Jeu**
   - **Flèches** ou **WASD** : Déplacer Pacman
   - **ESC** : Quitter le jeu
   - Manger les pellets pour marquer des points
   - Éviter les fantômes!

## Fonctionnalités

✓ Mouvement en grille avec input legacy  
✓ IA des fantômes (chasse et aléatoire)  
✓ Système de collision  
✓ Gestion des vies  
✓ Système de score  
✓ Génération de pellets  

## Notes

- Le système utilise **Input.GetKeyDown()** pour l'Input Legacy
- Les mouvements sont basés sur une grille de 0.5 unités
- Les fantômes ont 2 modes: chasse et déplacement aléatoire
- Le jeu se met en pause quand tous les pellets sont mangés (victoire)