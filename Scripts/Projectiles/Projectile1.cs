using Godot;
using System;

public class Projectile1 : Projectile
{
	
	private Vector2 MainPath;
	private Vector2 Perp;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Lifetime = 0.475f;
		Speed = 720;
		Amplitude = 20;
		Frequency = 4 * (float)Math.PI / Lifetime;
		Perp = Direction.Rotated(Sign * (float)Math.PI / 2);
		MainPath = this.Position;
		Sign *= -1;
	}
	
	
	public override void Move(float delta) {
		MainPath += Direction * delta * Speed;
		float offset = (float)Math.Sin(Elapsed * Frequency) * Amplitude;
		Position = MainPath + Perp * offset;
		
	}


}
