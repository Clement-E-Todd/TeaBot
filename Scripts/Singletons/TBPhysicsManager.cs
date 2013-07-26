using UnityEngine;
using System.Collections;

public static class TBPhysicsManager {
	
//	[Gravity Direction not yet supported]
//	static Vector3 m_GravityDirection = Vector3.down;
//	public static Vector3 gravityDirection {
//		get { return m_GravityDirection; }
//		set { m_GravityDirection = value.normalized; }
//	}
	
	static float m_GravityStrength = 1;
	public static float gravityStrength {
		get { return m_GravityStrength; }
		set { m_GravityStrength = value; }
	}
}
