using UnityEngine;
using System.Collections;

public class TBCharacter : MonoBehaviour {
	
	public Vector3 horizontalDirection = Vector3.zero;
	public float horizontalSpeed = 0;
	public float verticalSpeed = 0;
	public Vector3 arialVelocity = Vector3.zero;
	
	CollisionFlags collisionFlags;
	
	CharacterController characterController;
	
	void Awake() {
		horizontalDirection = transform.TransformDirection(Vector3.forward);
	}
	
	void Start() {
		characterController = (CharacterController)GetComponent(typeof(CharacterController));
	}
	
	void Update() {
		
		// Apply gravity
		ApplyGravity();
		
		// Calculate combined motion
		Vector3 movement = (horizontalDirection*horizontalSpeed) + new Vector3(0,verticalSpeed,0) + arialVelocity;
		movement *= Time.deltaTime;
		
		// Move the controller
		collisionFlags = characterController.Move(movement);
		
		// While on the ground...
		if (IsGrounded())
		{
			arialVelocity = Vector3.zero;
		}
	}
	
	void ApplyGravity()
	{
		float gravity = TBPhysicsManager.gravityStrength;
		verticalSpeed = verticalSpeed - gravity;
		if (IsGrounded() && verticalSpeed < -gravity) verticalSpeed = -gravity;
	}
	
	public bool IsGrounded()
	{
		return (collisionFlags & CollisionFlags.CollidedBelow) != 0;
	}
}
