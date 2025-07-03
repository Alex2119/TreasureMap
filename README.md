# 🗺️ Treasure Map Simulation

Ce projet simule les déplacements d'aventuriers sur une carte à la recherche de trésors, en respectant des règles simples de déplacement et d'obstacles.

---

## 📂 Structure du projet

* **TreasureMap.Entities** : Contient les classes principales (`Map`, `Tile`, `Adventurer`, etc.).
* **TreasureMap** : Projet console qui exécute la simulation.
* **TreasureMap.Tests** : Projet de tests unitaires et d'intégration avec xUnit.

---

## ⚙️ Technologies

* C# 12 / .NET 9
* xUnit pour les tests
* Aucun framework externe imposé (console app simple)

---

## 📝 Format du fichier d'entrée

Le fichier `input.txt` doit suivre ce format :

```
C - Largeur - Hauteur
M - X - Y
T - X - Y - NombreDeTrésors
A - Nom - X - Y - Orientation(N/S/E/W) - Mouvements(AADADAGGA)
```

Exemple :

```
C - 3 - 4
M - 1 - 0
M - 2 - 1
T - 0 - 3 - 2
T - 1 - 3 - 3
A - Link - 1 - 1 - S - AADADAGGA
```

---

## 🚀 Exécution

Depuis le dossier contenant la solution :

```bash
dotnet build
dotnet run --project TreasureMap
```

Le fichier `input.txt` doit être placé à la racine du projet **TreasureMap**.

Après exécution, le résultat sera généré dans le dossier de compilation, par exemple :

```
<chemin_du_projet>\TreasureMap\bin\Debug\net9.0\result.txt
```

🚨 L'emplacement exact dépend de votre machine et de votre environnement.

---

## ✅ Tests

Les tests se lancent avec :

```bash
dotnet test
```

Ils couvrent :

* Le déplacement et la collecte de trésors par les aventuriers
* Les obstacles (montagnes)
* Un test d'intégration complet (chargement, simulation, sauvegarde)

---

## 🎯 Points clés

* Respect des principes de séparation des responsabilités
* Code modulaire et facilement testable
* Possibilités d'extension (autres types de terrains, nouvelles règles...)

---
