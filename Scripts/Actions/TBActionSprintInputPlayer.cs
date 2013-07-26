using UnityEngine;
using System.Collections;

public class TBActionSprintInputPlayer : MonoBehaviour, TBActionSprintInput {
	
	public bool Sprinting()
	{
		return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
	}
}