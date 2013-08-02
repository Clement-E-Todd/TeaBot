using UnityEngine;
using System.Collections;

public class TBActionDuck : MonoBehaviour {
	
	TBCharacter character;
	TBActionDuckInput actionInput;
	CharacterController characterController;
	
	public float duckingDepth = 0.0f; // 0 = standing, 1 = litterally two-dimensional
	public float maxDuckingDepth = 0.5f;
	float standingHeight;

	protected void Start()
	{
		character = (TBCharacter)GetComponent(typeof(TBCharacter));
		actionInput = (TBActionDuckInput)GetComponent(typeof(TBActionDuckInput));
		characterController = (CharacterController)GetComponent(typeof(CharacterController));
		
		if (characterController)
		{
			standingHeight = characterController.height;
		}
	}

	void Update()
	{
		if (actionInput != null)
		{
			float heightBefore = characterController.height;
			float intendedDuckDepth = actionInput.DuckingDepth()*maxDuckingDepth;
			duckingDepth = Mathf.Lerp(duckingDepth, intendedDuckDepth, 0.9f);
			characterController.height = standingHeight*(1-duckingDepth);
			characterController.Move (new Vector3(0, (characterController.height-heightBefore)/2, 0));
		}
	}
}
