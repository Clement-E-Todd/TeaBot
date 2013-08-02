using UnityEngine;

public interface TBActionDuckInput {
	
	/// <summary>
	/// Ducking Depth
	/// </summary>
	/// <returns>
	/// The depth that the character should be ducking at (0 = not ducking, 1 = full duck).
	/// </returns>
	float DuckingDepth();
}