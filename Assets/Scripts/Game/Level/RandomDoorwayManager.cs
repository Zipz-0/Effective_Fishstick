using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class RandomDoorwayManager : MonoBehaviour {
	#region setup
	public List<RandomDoorway> doorways { get; private set; } = new List<RandomDoorway>();

	public static RandomDoorwayManager instance { get; private set; }

	[SerializeField] GameObject wallPrefab;
	[SerializeField] GameObject doorwayPrefab;
	#endregion

	void Start() {
		SetSingleton();

		if (instance == this) {
			RandomizeDoorways();
		}
	}

	void OnEnable() {
		if (!instance) {
			SetSingleton();
		}
	}

	#region internal functions
	void SetSingleton() {
		if (!instance) {
			instance = this;
			transform.parent = null;
			DontDestroyOnLoad(this);
		} else if (instance && instance != this) {
			Destroy(gameObject);
		}
	}
	#endregion

	#region commands
	public void RegisterDoorway(RandomDoorway which) {
		doorways.Add(which);
	}

	public void RandomizeDoorways() {
		foreach (RandomDoorway d in doorways) {
			if (d.transform.childCount > 0) {
				Destroy(d.transform.GetChild(0).gameObject); //shouldn't need to destroy them all unless something was manually spawned
			}

			int r = Random.Range(0, 2);

			if (r == 0) {
				Instantiate(wallPrefab, d.transform);
			} else {
				Instantiate(doorwayPrefab, d.transform);
			}
		}
	}
	#endregion
}

// ~ Rocco