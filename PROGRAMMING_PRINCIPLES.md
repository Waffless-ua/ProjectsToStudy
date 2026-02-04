# Used programming principles

### Single Responsibility Principle(SRP)
The engine processes the logic for objects inside the UI. You can see it [here](Lab1/ArcadeGame/ArcadeGameWPF/Engine).
The main engine is GameEngine. It creates other engines and starts game loops inside them.
There are four engines:
- PlayerEngine - handles logic for player movement
- EnemyEngine - handles logic for enemy movement and spawning
- BulletEngine - handles logic for bullet movement and spawning

The CollisionEngine works with all objects and processes logic during collisions between them. For example, it deletes enemies after they receive enough damage to be destroyed.

### Liskov Substitution Principle(LSP)


[Example of Liskov Substitution Principle(LSP)](Lab1/ArcadeGame/ArcadeGameWPF/Models)
