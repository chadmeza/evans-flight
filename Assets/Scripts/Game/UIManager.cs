using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	[SerializeField]
	private Text _scoreText;
	[SerializeField]
	private GameObject _gameOverPanel;
	[SerializeField]
	private Text _gameOverScoreText;
	[SerializeField]
	private GameObject _newHighScoreText;
	[SerializeField]
	private GameObject _tapToFlyText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void HideTapToFlyText() {
		_tapToFlyText.SetActive (false);
	}

	public void UpdatePlayerScore (int playerScore) {
		_scoreText.text = playerScore + "";
	}

	public void DisplayGameOverPanel(int playerScore, bool isNewHighScore) {
		// Hide the main score
		_scoreText.gameObject.SetActive(false);

		// Display the Game Over Panel
		_gameOverPanel.SetActive (true);

		// Display the final score
		_gameOverScoreText.text = playerScore + "";

		// If this is a new high score, display the tag
		_newHighScoreText.SetActive(isNewHighScore);
	}
}
