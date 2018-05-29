using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[SerializeField]
	private Sprite[] _enemySprites;

	private float _maxYPosition = 5.0f;
	private float _minYPosition = -5.0f;
	private float _moveSpeed = 2.0f;

	private GameManager _gameManager;

	void OnEnable () {
		// Create enemy at a random size
		float newScale = Random.Range (0.25f, 1.0f);
		transform.localScale = new Vector3 (newScale, newScale); 

		// Spawn enemy at a random position
		Vector3 startPosition = new Vector3 (0, Random.Range (_minYPosition, _maxYPosition), 0);
		transform.position += startPosition;

		// Select a random sprite for the enemy
		int randomInt = Random.Range (0, 5);
		GetComponent<SpriteRenderer> ().sprite = _enemySprites [randomInt];

		// Get a handle for the Game Manager
		_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	void Update () {
		if (_gameManager._isGameOver) {
			Destroy (gameObject);
		}

		// Move to the left
		transform.Translate (Vector3.left * _moveSpeed * Time.deltaTime);

		// When the enemy moves off screen, destroy the object
		if (transform.position.x < -4 && gameObject.activeInHierarchy) {
			_gameManager.IncreaseScore ();

			// Add the enemy back to the pool
			gameObject.SetActive (false);

			// Go back to start position
			transform.position = new Vector3 (5f, 0, 0);
		}
	}
}
