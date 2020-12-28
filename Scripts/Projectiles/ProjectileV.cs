using Godot;
using System;

public class ProjectileV : Projectile
{
	
	private Vector2 MainPath;
	private Vector2 Perp;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Lifetime = 0.35f;
		Speed = 640;
		Amplitude = 14;
		Frequency = 0.4f * (float)Math.PI / Lifetime;
		Perp = Direction.Rotated(Sign * (float)Math.PI / 2);
		MainPath = this.Position;
	}
	
	
	public override void Move(float delta) {
		MainPath += Direction * delta * Speed;
		float offset = (float)Math.Sin(Elapsed * Frequency) * Amplitude;
		Position = MainPath + Perp * offset;
		
	}


}
