using UnityEngine;

[DisallowMultipleComponent]
public class RandomDoorway : MonoBehaviour {
	void Start() {
		if (RandomDoorwayManager.instance) {
			RandomDoorwayManager.instance.RegisterDoorway(this);
		}
	}
}

// ~ Rocco