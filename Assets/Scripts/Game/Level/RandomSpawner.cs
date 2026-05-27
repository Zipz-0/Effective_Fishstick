using UnityEngine;

public class RandomSpawner : MonoBehaviour {
	#region setup
	[SerializeField] GameObject[] pool;
	#endregion

	void Awake() {
		if (pool.Length == 0) {
			Debug.LogWarning(this + " has no items to randomly spawn!", this);
			return;
		}

		GameObject spawned = Instantiate(pool[Random.Range(0, pool.Length)], transform);
	}
}

// ~ Rocco