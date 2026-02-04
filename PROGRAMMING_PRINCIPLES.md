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

All game objects inherit from the [GameObject](Lab1/ArcadeGame/ArcadeGameWPF/Models/GameObject.cs) class, which contains properties for size and position. The most important feature of GameObject is that it implements OnNotifyPropertyChanged, which allows updating model data for the UI via data binding.
