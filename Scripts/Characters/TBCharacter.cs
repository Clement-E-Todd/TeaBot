using UnityEngine;
using System.Collections;

public class TBCharacter : MonoBehaviour {
	
	public Vector3 horizontalDirection = Vector3.zero;
	public float horizontalSpeed = 0;
	public float verticalSpeed = 0;
	public Vector3 arialVelocity = Vector3.zero;
	
	public float rotateSpeed = 500.0f;
	public float arialAcceleration = 3.0f;
	
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
		verticalSpeed = IsGrounded() ? 0 : verticalSpeed - TBPhysicsManager.gravityStrength;
	}
	
	public bool IsGrounded()
	{
		return (collisionFlags & CollisionFlags.CollidedBelow) != 0;
	}
}
