using UnityEngine;
using System.Collections;

public class TBActionJump : MonoBehaviour {
	
	TBCharacter character;
	TBActionJumpInput actionInput;
	
	public float jumpStrength = 10.0f;
	public bool  slowFall = true;

	protected void Start()
	{
		character = (TBCharacter)GetComponent(typeof(TBCharacter));
		actionInput = (TBActionJumpInput)GetComponent(typeof(TBActionJumpInput));
	}

	void Update()
	{
		if (actionInput != null)
		{
			if (actionInput.StartingJump() && character.IsGrounded())
			{
					character.verticalSpeed = jumpStrength;
			}
			else if (actionInput.HoldingJump() && slowFall && character.verticalSpeed > 0)
			{
				character.verticalSpeed += TBPhysicsManager.gravityStrength/2;
			}
			
		}
	}
}
