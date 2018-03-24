using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	// Use this for initialization
	private float kScale;
	private Vector3 normalScale;
	void Start () {
		kScale = 1.2f;
		normalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            transform.localScale = new Vector3(transform.localScale.x * kScale, transform.localScale.y * kScale, transform.localScale.z);

			other.gameObject.GetComponent<PlayerController>().set_interaction(true);
        }
    }

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
            transform.localScale = normalScale;

			other.gameObject.GetComponent<PlayerController>().set_interaction(false);
        }
	}
}
