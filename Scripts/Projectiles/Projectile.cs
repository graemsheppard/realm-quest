using Godot;
using System;

public abstract class Projectile : KinematicBody2D
{
	// Declare member variables here. Examples:
	protected ProjectileType Type;
	protected float Elapsed;
	protected Vector2 Direction;
	protected float Lifetime;
	protected float Frequency;
	protected float Amplitude;
	protected float Speed;
	protected int Sign;

	public void Init  (Vector2 pos, Vector2 dir) {
		Direction = dir;
		Position = pos;
		Rotation = Vector2.Right.AngleTo(dir);
	}
	
	public void Init  (Vector2 pos, Vector2 dir, int sign) {
		Direction = dir;
		Position = pos;
		Rotation = Vector2.Right.AngleTo(dir);
		Sign = sign;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Elapsed = 0;
		Console.WriteLine($"Projectile created at {this.Position}, {this.Rotation}");
	}
	
	public abstract void Move(float delta);

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if (Elapsed >= Lifetime)
			QueueFree();
		Elapsed += delta;
		Move(delta);
		
	}
}
