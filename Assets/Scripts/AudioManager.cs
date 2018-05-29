using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public static AudioManager instance = null;

	[SerializeField]
	private AudioSource _uiAudio;
	[SerializeField]
	private AudioSource _screenTapAudio;
	[SerializeField]
	private AudioClip _explosionSound;

	[SerializeField]
	private bool _isAudioOn = true;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool GetIsAudioOn() {
		return _isAudioOn;
	}

	public void ToggleIsAudioOn() {
		_isAudioOn = !_isAudioOn;

		// If audio is off, the background audio stops
		AudioSource backgroundAudio = GameObject.Find("BackgroundAudio").GetComponent<AudioSource>();

		if (_isAudioOn) {
			backgroundAudio.Play ();
		} else {
			backgroundAudio.Stop ();
		}
	}

	public void PlayUIAudio() {
		if (_isAudioOn) {
			_uiAudio.Play ();
		}
	}

	public void PlayScreenTapAudio() {
		if (_isAudioOn) {
			_screenTapAudio.Play ();
		}
	}

	public void PlayExplosionSound() {
		if (_isAudioOn) {
			AudioSource.PlayClipAtPoint (_explosionSound, Camera.main.transform.position);
		}
	}
}
