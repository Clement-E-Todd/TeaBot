using UnityEngine;

public interface TBActionJumpInput {
	
	/// <summary>
	/// Starting Jump
	/// </summary>
	/// <returns>
	/// A bool reflecting whether the character wants to start a new jump.
	/// </returns>
	bool StartingJump();
	
	/// <summary>
	/// Holding Jump
	/// </summary>
	/// <returns>
	/// A bool reflecting whether the character intends to continue the jump for now.
	/// </returns>
	bool HoldingJump();
}