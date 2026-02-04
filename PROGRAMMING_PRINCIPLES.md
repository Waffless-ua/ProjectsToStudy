# Used programming principles

### Single Responsibility Principle(SRP)
Engines process logic for objects inside of UI. 
Main engine is GameEngine. It creates others engines and starts game loops inside others engines.
Here is 4 engines:
- PlayerEngine - process logic for player movement
- EnemyEngine - process logic for enemy movement and spawn
- BulletEngine - process logic for bullet movement and spawn

When CollisionEngine works with all objects and process logic during collision between them, for example deleting enemies after recieving enough damage to kill them.


[Example of Single Responsibility Principle(SRP)](Lab1/ArcadeGame/ArcadeGameWPF/Engine)


### Liskov Substitution Principle(LSP)
[Example of Liskov Substitution Principle(LSP)](Lab1/ArcadeGame/ArcadeGameWPF/Models)
