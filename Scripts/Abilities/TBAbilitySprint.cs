using UnityEngine;
using System.Collections;

public class TBAbilitySprint : MonoBehaviour {
	
	TBAbilitySprintInput abilityInput;
	TBAbilityMove moveAbility;
	public float sprintSpeedMax = 8.0f;
	
	protected void Start()
	{
		abilityInput = (TBAbilitySprintInput)GetComponent(typeof(TBAbilitySprintInput));
		moveAbility = (TBAbilityMove)GetComponent(typeof(TBAbilityMove));
	}

	void Update()
	{
		if (abilityInput.Sprinting())
		{
			moveAbility.BoostTopSpeed(sprintSpeedMax);
		}
	}
}
