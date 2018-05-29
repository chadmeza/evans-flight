using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public bool _isGameOver = false;
	public int playerScore = 0;

	[SerializeField]
	private GameObject _playerPrefab;
	[SerializeField]
	private GameObject _enemyPrefab;

	private float _enemySpawnTime = 1.25f;
	private int _highScore;

	private UIManager _uiManager;
	private AudioManager _audioManager;

	void Start () {
		// Get a handle for the UI Manager
		_uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

		// Get a handle for the Audio Manager
		_audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

		// If a high score is saved, load it
		_highScore = LoadHighScore();

		// Pause the game
		Time.timeScale = 0f;

		// Spawn the player
		Instantiate(_playerPrefab, new Vector3(-1.5f, 0, 0), Quaternion.identity);

		// Start spawning enemies
		StartCoroutine (SpawnEnemies ());
	}
	
	void Update () {
		
	}

	public void PlayGame() {
		// Hide the instructions
		_uiManager.HideTapToFlyText ();

		// Start the game by resuming time
		Time.timeScale = 1.0f;
	}

	IEnumerator SpawnEnemies() {
		// Spawn new enemies
		while (!_isGameOver) {
			// Get an enemy from the pooled enemies
			GameObject enemy = EnemyObjectPooler.sharedInstance.GetPooledEnemy();

			// Set the enemy active in the scene
			if (enemy != null) {
				enemy.SetActive (true);
			}

			yield return new WaitForSeconds (_enemySpawnTime);
		}
	}

	public void IncreaseScore() {
		playerScore++;

		// Update the score on the UI
		_uiManager.UpdatePlayerScore (playerScore);
	}

	public void ToggleGameOver() {
		_isGameOver = !_isGameOver;

		if (playerScore > _highScore) {
			SaveHighScore ();

			// Display the game over screen with the "New High Score" label
			_uiManager.DisplayGameOverPanel (playerScore, true);
		} else {
			_uiManager.DisplayGameOverPanel (playerScore, false);
		}
	}

	public void SaveHighScore() {
		PlayerPrefs.SetInt ("highScore", playerScore);
		PlayerPrefs.Save ();
	}

	private int LoadHighScore() {
		if (PlayerPrefs.HasKey("highScore")) {
			return PlayerPrefs.GetInt ("highScore");
		} else {
			return 0;
		}
	}

	public void LoadNewScene(string newScene) {
		SceneManager.LoadScene (newScene);
	}

	public void PlayUIAudio() {
		_audioManager.PlayUIAudio ();
	}

	public void PlayScreenTapAudio() {
		_audioManager.PlayScreenTapAudio ();
	}

	public void PlayExplosionSound() {
		_audioManager.PlayExplosionSound ();
	}
}
