using Godot;
using System;

public class Weapon1 : Weapon
{
	// Declare member variables here. Examples:
	
	public override void _Ready () {
		ProjectileScene = (PackedScene)GD.Load("Scenes/Projectiles/Projectile1.tscn");
	}
	
	public override void Summon (Vector2 Position, Vector2 direction) {
		Projectile proj1 = (Projectile1)ProjectileScene.Instance();
		proj1.Init(Position, direction, Sign);
		Sign *= -1;
		Projectile proj2 = (Projectile1)ProjectileScene.Instance();
		proj2.Init(Position, direction, Sign);
		Sign *= -1;
		ProjectileGroup.AddChild(proj1);
		ProjectileGroup.AddChild(proj2);
	}
}
