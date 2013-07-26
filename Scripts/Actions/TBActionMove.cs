using UnityEngine;
using System.Collections;

public class TBActionMove : MonoBehaviour {
	
	TBCharacter character;
	TBActionMoveInput actionInput;
	public float moveSpeedMax = 4.0f;
	float boostedSpeedMax = 0.0f;
	
	protected void Start()
	{
		character = (TBCharacter)GetComponent(typeof(TBCharacter));
		actionInput = (TBActionMoveInput)GetComponent(typeof(TBActionMoveInput));
	}

	void Update()
	{
		if (actionInput != null)
		{
			Vector3 targetDirection = actionInput.TargetMoveDirection();
			
			if (character.IsGrounded())
			{
				if (targetDirection != Vector3.zero)
				{
					// If movement is very slow, face intended direction immediately
					if (character.horizontalSpeed < moveSpeedMax/2)
					{
						character.horizontalDirection = targetDirection.normalized;
					}
					// Otherwise turn gradually towards it
					else
					{
						character.horizontalDirection = Vector3.RotateTowards(character.horizontalDirection, targetDirection, character.rotateSpeed * Mathf.Deg2Rad * Time.deltaTime, 1000);
						character.horizontalDirection = character.horizontalDirection.normalized;
					}
				}
				
				float targetSpeed = Mathf.Min(targetDirection.magnitude, 1.0f);
				targetSpeed *= Mathf.Max(moveSpeedMax, boostedSpeedMax);
				character.horizontalSpeed = Mathf.Lerp(character.horizontalSpeed, targetSpeed, Time.deltaTime*10);
				boostedSpeedMax = 0;
			}
			else
			{
				if (targetDirection != Vector3.zero)
				{
					character.arialVelocity += targetDirection.normalized * Time.deltaTime * character.arialAcceleration;
				}
			}
		}
	}
	
	public void BoostTopSpeed(float newTopSpeed)
	{
		boostedSpeedMax = Mathf.Max(boostedSpeedMax, newTopSpeed);
	}
}
