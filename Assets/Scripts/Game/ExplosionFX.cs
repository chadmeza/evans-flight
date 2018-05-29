using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFX : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Pause one second before destorying this object
		Destroy (gameObject, 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
