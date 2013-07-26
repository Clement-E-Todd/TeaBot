using UnityEngine;
using System.Collections;

public class TBActionSprint : MonoBehaviour {
	
	TBActionSprintInput actionInput;
	TBActionMove moveAction;
	public float sprintSpeedMax = 8.0f;
	
	protected void Start()
	{
		actionInput = (TBActionSprintInput)GetComponent(typeof(TBActionSprintInput));
		moveAction = (TBActionMove)GetComponent(typeof(TBActionMove));
	}

	void Update()
	{
		if (actionInput.Sprinting())
		{
			moveAction.BoostTopSpeed(sprintSpeedMax);
		}
	}
}
