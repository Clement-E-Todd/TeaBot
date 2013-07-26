using UnityEngine;
using System.Collections;

public class TBActionMoveInputPlayer : MonoBehaviour, TBActionMoveInput {
	
	public Vector3 TargetMoveDirection()
	{
		var cameraTransform = Camera.main.transform;
	
		// "Forward" vector (from camera's perspective) flattened to the horizontal plane	
		Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);
		forward.y = 0;
		forward = forward.normalized;

		// "Right" (from camera's perspective) relative to forward vector
		Vector3 right = new Vector3(forward.z, 0, -forward.x);

		float verticalAxis = Input.GetAxisRaw("Vertical");
		float horizontalAxis = Input.GetAxisRaw("Horizontal");
		
		return (horizontalAxis * right) + (verticalAxis * forward);
	}
}
