using Godot;
using System;

public class WeaponV : Weapon
{
	public override void _Ready () {
		ProjectileScene = (PackedScene)GD.Load("Scenes/Projectiles/ProjectileV.tscn");
		Sign = 1;
	}
	
	public override void Summon (Vector2 Position, Vector2 direction) {
		Projectile proj = (ProjectileV)ProjectileScene.Instance();
		proj.Init(Position, direction, Sign);
		Sign *= -1;
		ProjectileGroup.AddChild(proj);
	}
}
