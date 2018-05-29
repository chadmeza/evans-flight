using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPooler : MonoBehaviour {
	public static EnemyObjectPooler sharedInstance;

	public List<GameObject> pooledEnemies;

	[SerializeField]
	private GameObject _enemyPrefab;

	private int _amountToPool = 10;

	void Awake() {
		sharedInstance = this;
	}

	// Use this for initialization
	void Start () {
		pooledEnemies = new List<GameObject> ();

		// Spawn enemy off screen
		Vector3 enemySpawnPoint = new Vector3 (5f, 0, 0);

		// Create enemy pool
		for (int i = 0; i < _amountToPool; i++) {
			GameObject enemy = Instantiate (_enemyPrefab, enemySpawnPoint, Quaternion.identity) as GameObject;
			enemy.SetActive (false);
			pooledEnemies.Add (enemy);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject GetPooledEnemy() {
		// Check all pooled enemies, and return the first one that is not active
		for (int i = 0; i < pooledEnemies.Count; i++) {
			if (!pooledEnemies[i].activeInHierarchy) {
				return pooledEnemies [i];
			}
		}

		return null;
	}
}
