using Godot;
using System;

public class Player : KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private PackedScene WeaponScene;
	private AnimationPlayer SpriteLoader;
	private string CurrentAnimation;
	private Weapon Weapon;
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		WeaponScene = (PackedScene)GD.Load("Scenes/Weapons/WeaponV.tscn");
		Weapon = (WeaponV)WeaponScene.Instance();
		Weapon.Init(0.125f, Owner.GetNode<Node2D>("Projectiles"));
		AddChild(Weapon);
		SpriteLoader = GetNode<AnimationPlayer>("AnimationPlayer");
		CurrentAnimation = "Bard_Idle_E";
		
	}

  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta)
	{
		var moveVect = new Vector2(0, 0);
		// WASD Movement
		if (Input.IsKeyPressed(65)) {
			moveVect.x -= 1;
		}
		if (Input.IsKeyPressed(68)) {
			moveVect.x += 1;
		}
		if (Input.IsKeyPressed(87)) {
			moveVect.y -= 1;
		}
		if (Input.IsKeyPressed(83)) {
			moveVect.y += 1;
		}
		
		float rotate = 0;
		// Camera Rotation
		if (Input.IsKeyPressed(81)) {
			rotate -= 1;
		}
		if (Input.IsKeyPressed(69)) {
			rotate += 1;
		}
		
		if (Input.IsKeyPressed(90)) {
			Rotation = 0;
		}
		

		// Mouse action
		if (Input.IsMouseButtonPressed(1)) {
			Vector2 direction = (GetGlobalMousePosition() - Position).Normalized();
			var angle = direction.Rotated(-Rotation).Angle();
			Weapon.Shoot(Position, direction);
			SpriteLoader.PlaybackSpeed = 1 / Weapon.Cooldown;
			if (angle >= -3 * (float)Math.PI / 4 && angle <= -(float)Math.PI / 4) 
				CurrentAnimation = "Bard_Shoot_N";
			else if (angle > -(float)Math.PI / 4 && angle < (float)Math.PI / 4) 
				CurrentAnimation = "Bard_Shoot_E";
 			else if (angle >= (float)Math.PI / 4 && angle <= 3 * (float)Math.PI / 4) 
				CurrentAnimation = "Bard_Shoot_S";
			else
				CurrentAnimation = "Bard_Shoot_W";
				
		} else if (moveVect.Length() > 0) {
			SpriteLoader.PlaybackSpeed = 1;
			var angle = moveVect.Angle();
			if (angle >= -3 * (float)Math.PI / 4 && angle <= -(float)Math.PI / 4) 
				CurrentAnimation = "Bard_Walk_N";
			else if (angle > -(float)Math.PI / 4 && angle < (float)Math.PI / 4) 
				CurrentAnimation = "Bard_Walk_E";
 			else if (angle >= (float)Math.PI / 4 && angle <= 3 * (float)Math.PI / 4) 
				CurrentAnimation = "Bard_Walk_S";
			else
				CurrentAnimation = "Bard_Walk_W";
		
		} else {
			var facing = CurrentAnimation[CurrentAnimation.Length - 1];
			CurrentAnimation = $"Bard_Idle_{facing}";
		}
		

		
		Rotation += rotate * 180f * (float)Math.PI / 180f * delta;
		moveVect = moveVect.Normalized().Rotated(Rotation) * 350f ;
		MoveAndSlide(moveVect);
		
		SpriteLoader.Play(CurrentAnimation);
		
		

		
	  }
	
}
