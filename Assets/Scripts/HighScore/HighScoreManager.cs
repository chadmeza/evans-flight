using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour {
	[SerializeField]
	private Text _highScoreText;

	private AudioManager _audioManager;

	// Use this for initialization
	void Start () {
		// Get a handle for the Audio Manager
		_audioManager = GameObject.Find ("AudioManager").GetComponent<AudioManager> ();

		int highScore = 0;

		// Get the player's high score, if it is set
		if (PlayerPrefs.HasKey("highScore")) {
			highScore = PlayerPrefs.GetInt ("highScore");
		}

		_highScoreText.text = highScore + "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayUIAudio() {
		_audioManager.PlayUIAudio ();
	}

	public void LoadMenuScene() {
		// If the player presses the "back" button, the menu scene is loaded
		SceneManager.LoadScene("Menu");
	}
}
