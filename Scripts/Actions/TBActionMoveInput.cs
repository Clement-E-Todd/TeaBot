using UnityEngine;

public interface TBActionMoveInput {
	Vector3 TargetMoveDirection();
	bool Sprinting();
	bool Strafing();
}