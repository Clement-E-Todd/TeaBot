using UnityEngine;
using System.Collections;

public class TBCharacterController : MonoBehaviour {
	
	public float jogSpeed = 4.0f; // Top speed without holding a run button
	public float sprintSpeed = 8.0f; // Top speed while holding a run button

	Vector3 horizontalDirection = Vector3.zero;
	float horizontalSpeed = 0;
	float verticalSpeed = 0;
	Vector3 arialVelocity = Vector3.zero;
	
	const float rotateSpeed = 500.0f;
	const float arialAcceleration = 3.0f;
	
	CollisionFlags collisionFlags;
	
	CharacterController characterController;
	TBMovementInteface movementInterface;
	
	void Awake() {
		horizontalDirection = transform.TransformDirection(Vector3.forward);
	}
	
	void Start() {
		characterController = (CharacterController)GetComponent(typeof(CharacterController));
		movementInterface = (TBMovementInteface)GetComponent(typeof(TBMovementInteface));
	}
	
	void Update() {
		
		// Calculate horizontal movement
		UpdateHorizontalMovement();
		
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
	
	void UpdateHorizontalMovement()
	{
		if (movementInterface != null)
		{
			Vector3 targetDirection = movementInterface.TargetMovementDirection();
			
			if (IsGrounded())
			{
				if (targetDirection != Vector3.zero)
				{
					// If movement is very slow, face intended direction immediately
					if (horizontalSpeed < jogSpeed/2)
					{
						horizontalDirection = targetDirection.normalized;
					}
					// Otherwise turn gradually towards it
					else
					{
						horizontalDirection = Vector3.RotateTowards(horizontalDirection, targetDirection, rotateSpeed * Mathf.Deg2Rad * Time.deltaTime, 1000);
						horizontalDirection = horizontalDirection.normalized;
					}
				}
				
				float targetSpeed = Mathf.Min(targetDirection.magnitude, 1.0f);
				targetSpeed *= movementInterface.Sprinting() ? sprintSpeed : jogSpeed;
				horizontalSpeed = Mathf.Lerp(horizontalSpeed, targetSpeed, Time.deltaTime*10);
			}
			else
			{
				if (targetDirection != Vector3.zero)
				{
					arialVelocity += targetDirection.normalized * Time.deltaTime * arialAcceleration;
				}
			}
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
