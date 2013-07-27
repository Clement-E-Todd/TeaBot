using UnityEngine;
using System.Collections;

public class TBActionJumpInputPlayer : MonoBehaviour, TBActionJumpInput {
	
	public bool StartingJump()
	{
		return Input.GetKeyDown(KeyCode.Space);
	}
	
	public bool HoldingJump()
	{
		return Input.GetKey(KeyCode.Space);
	}
}
