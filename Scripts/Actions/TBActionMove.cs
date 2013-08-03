using UnityEngine;
using System.Collections;

public class TBActionMove : MonoBehaviour {
	
	TBCharacter character;
	TBActionMoveInput actionInput;
	TBActionDuck duckAction;
	public float moveSpeedMax = 4.0f;
	public float sprintSpeedMax = 6.0f;
	public float slowSpeedLimit = 1.0f;
	public float rotateSpeedMax = 3.0f;
	public float arialAccelRate = 3.0f;

	protected void Start()
	{
		character = (TBCharacter)GetComponent(typeof(TBCharacter));
		actionInput = (TBActionMoveInput)GetComponent(typeof(TBActionMoveInput));
		duckAction = (TBActionDuck)GetComponent(typeof(TBActionDuck));
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
					if (character.horizontalSpeed < slowSpeedLimit)
					{
						character.horizontalDirection = targetDirection.normalized;
					}
					// Otherwise turn gradually towards it
					else
					{
						character.horizontalDirection = Vector3.RotateTowards(character.horizontalDirection,
																			  targetDirection,
																			  (rotateSpeedMax*1000) / character.horizontalSpeed * Mathf.Deg2Rad * Time.deltaTime,
																			  1000);
						character.horizontalDirection = character.horizontalDirection.normalized;
					}
				}
				
				float targetSpeed = Mathf.Min(targetDirection.magnitude, 1.0f);
				bool crawling = (duckAction != null && duckAction.duckingDepth >= duckAction.minCrawlDepth);
				targetSpeed *= !crawling ?
					(actionInput.Sprinting() ? sprintSpeedMax : moveSpeedMax) :
					duckAction.maxCrawlSpeed;
				character.horizontalSpeed = Mathf.Lerp(character.horizontalSpeed, targetSpeed, Time.deltaTime*10);
				
				if (!actionInput.Strafing() && targetDirection != Vector3.zero)
				{
					transform.rotation = Quaternion.LookRotation(character.horizontalDirection);
				}
			}
			else
			{
				if (targetDirection != Vector3.zero)
				{
					character.arialVelocity += targetDirection.normalized * Time.deltaTime * arialAccelRate;
				}
			}
		}
	}
}
