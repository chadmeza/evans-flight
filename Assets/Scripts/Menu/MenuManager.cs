using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	[SerializeField]
	private Image _audioButtonImage;
	[SerializeField]
	private Sprite _audioOnSprite;
	[SerializeField]
	private Sprite _audioOffSprite;

	private AudioManager _audioManager;

	// Use this for initialization
	void Start () {
		
	}

	void OnEnable() {
		// Get a handle for the audio manager
		_audioManager = GameObject.Find ("AudioManager").GetComponent<AudioManager> ();

		UpdateAudioButtonSprite ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateAudioButtonSprite() {
		// Display the correct sprite for the audio button
		if (_audioManager.GetIsAudioOn()) {
			_audioButtonImage.sprite = _audioOnSprite;
		} else {
			_audioButtonImage.sprite = _audioOffSprite;
		}
	}

	public void PlayUIAudio() {
		_audioManager.PlayUIAudio ();
	}

	public void ToggleIsAudioOn() {
		_audioManager.ToggleIsAudioOn ();
	}

	public void LoadNewScene(string newScene) {
		SceneManager.LoadScene (newScene);
	}
}
