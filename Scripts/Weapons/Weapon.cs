using Godot;
using System;

public abstract class Weapon : Node
{
	// Declare member variables here. Examples:
	
	protected PackedScene ProjectileScene;
	public float Cooldown;
	public float Timer;
	protected bool OnCooldown;
	protected static Node2D ProjectileGroup;
	protected int Sign;
	

	public void Init(float cooldown, Node2D group) {
		if (ProjectileGroup == null)
			ProjectileGroup = group;
		Cooldown = cooldown;
		Timer = cooldown;
	}
	
	public abstract void Summon(Vector2 position, Vector2 direction);
	
	
	public override void _Process(float delta) {
		if (OnCooldown) {
			Timer -= delta;
			if (Timer <= 0) {
				OnCooldown = false;
				Timer = Cooldown;
			}
				
		}
		
		
	}

	public void Shoot (Vector2 position, Vector2 direction) {
		
		if (!OnCooldown) {
			Summon(position, direction);
			OnCooldown = true;
		} 
	}
	
	
}
