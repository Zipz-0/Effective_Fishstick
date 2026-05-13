using UnityEngine;

[DisallowMultipleComponent]
public class RandomDoorway : MonoBehaviour {
	#region setup

	#endregion

	void Start() {
		if (RandomDoorwayManager.instance) {
			RandomDoorwayManager.instance.RegisterDoorway(this);
		}
	}

	#region internal functions

	#endregion

	#region commands

	#endregion
}

// ~ Shaggy39