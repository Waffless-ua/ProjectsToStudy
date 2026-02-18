# Used programming principles

### Single Responsibility Principle(SRP)
The engine processes the logic for objects inside the UI. You can see it [here](Lab1/ArcadeGame/ArcadeGameWPF/Engine). 

The main engine is GameEngine. It creates other engines and starts game loops inside them.
There are four different engines:
- PlayerEngine - handles logic for player movement
- EnemyEngine - handles logic for enemy movement and spawning
- BulletEngine - handles logic for bullet movement and spawning

The CollisionEngine works with all objects and processes logic during collisions between them. For [example](/Lab1/ArcadeGame/ArcadeGameWPF/Engine/CollisionEngine.cs#L40-L57), it deletes enemies after they receive enough damage to be destroyed.

### Liskov Substitution Principle(LSP)
All engines inherit the Loop method from the [IEngine](Lab1/ArcadeGame/ArcadeGameWPF/API/IEngine.cs) interface. They all follow the same principle of updating object information every deltaTime for the UI.

All game objects inherit from the [GameObject](Lab1/ArcadeGame/ArcadeGameWPF/Models/GameObject.cs) class, which contains properties for size and position. The most important feature of GameObject is that it implements OnNotifyPropertyChanged, which allows updating model data for the UI via data binding. They not replace any basic logic of GameObject but only impliment their own logic like [damage, speed or health](Lab1/ArcadeGame/ArcadeGameWPF/Models/EnemyObject.cs#L11-L13).

### Open/Closed Principle (OCP)
The engine architecture is open for extension but closed for modification because all game systems implement the common interface [IEngine](Lab1/ArcadeGame/ArcadeGameWPF/API/IEngine.cs)
The main loop in GameEngine updates each subsystem through its Loop method:
- [PlayerEngine.Loop](Lab1/ArcadeGame/ArcadeGameWPF/Engine/PlayerEngine.cs#L32)
- [EnemyEngine.Loop](Lab1/ArcadeGame/ArcadeGameWPF/Engine/EnemyEngine.cs#L35)
- [BulletEngine.Loop](Lab1/ArcadeGame/ArcadeGameWPF/Engine/BulletEngine.cs#L37)
- [CollisionEngine.Loop](Lab1/ArcadeGame/ArcadeGameWPF/Engine/CollisionEngine.cs#L34)

All of them follow the same contract and are executed every frame without changing the core game loop. This means that a new system can be added by implementing IEngine and creating its own Loop logic. Then registering it inside GameEngine without modifying the existing engines.
