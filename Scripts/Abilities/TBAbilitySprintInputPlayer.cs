using UnityEngine;
using System.Collections;

public class TBAbilitySprintInputPlayer : MonoBehaviour, TBAbilitySprintInput {
	
	public bool Sprinting()
	{
		return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
	}
}