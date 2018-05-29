using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private Rigidbody2D _rb;
	private float _upForce = 200f;

	[SerializeField]
	private Animator _thrustersAnimator;

	[SerializeField]
	private GameObject _explosionPrefab;

	private GameManager _gameManager;

	// Use this for initialization
	void Start () {
		// Get a handle for the rigidbody
		_rb = GetComponent<Rigidbody2D> ();

		// Get a handle for the Game Manager
		_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	void Update() {
		#if UNITY_ANDROID
		// When the screen is tapped, the player moves up
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
			// Play sound effect
			_gameManager.PlayScreenTapAudio();

			// Play thrusters animation
			_thrustersAnimator.SetBool("isActive", true);

			_rb.velocity = Vector2.zero;
			_rb.AddForce (new Vector2 (0, _upForce));
		} else {
			// If the player is not tapping, do not play the thruster animation
			_thrustersAnimator.SetBool("isActive", false);
		}
		#else
		// When the screen is tapped, the player moves up
		if (Input.GetButtonDown ("Fire1")) {
			// Play sound effect
			_gameManager.PlayScreenTapAudio();

			// Play thrusters animation
			_thrustersAnimator.SetBool("isActive", true);

			_rb.velocity = Vector2.zero;
			_rb.AddForce (new Vector2 (0, _upForce));
		} else {
			// If the player is not tapping, do not play the thruster animation
			_thrustersAnimator.SetBool("isActive", false);
		}
		#endif

		// If the player falls off the screen, they die
		if (transform.position.y < -7) {
			KillPlayer ();
		}

		// Set a vertical height boundary for the player
		if (transform.position.y > 5) {
			transform.position = new Vector3 (transform.position.x, 5.0f, 0f);
		}
	}

	void KillPlayer() {
		_gameManager.ToggleGameOver ();

		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.transform.tag == "Enemy") {
			// Play explosion sound effect
			_gameManager.PlayExplosionSound();

			// Play the explosion animation
			Instantiate (_explosionPrefab, transform.position, Quaternion.identity);

			// Set the game to over and destory the player object
			KillPlayer ();
		}
	}
}
