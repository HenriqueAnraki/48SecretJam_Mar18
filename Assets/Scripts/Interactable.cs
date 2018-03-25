using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	// Use this for initialization
	private float kScale;
	private Vector3 normalScale;

	public GameObject target_object; //para portas
	public Vector3 target_postion;

	public GameManager gameManager;

	public bool isLocked;
	void Start () {
		kScale = 1.2f;
		normalScale = transform.localScale;

		if(target_object != null){
			target_postion = target_object.transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {

			if(gameObject.tag == "Trigger"){
				
				gameManager.Interact(gameObject);
			} else {

				transform.localScale = new Vector3(transform.localScale.x * kScale, transform.localScale.y * kScale, transform.localScale.z);

				other.gameObject.GetComponent<PlayerController>().set_interaction(gameObject);
			}
        }
    }

	void OnTriggerExit2D (Collider2D other) {
		other.gameObject.GetComponent<PlayerController>().set_interaction(null);
		if (other.gameObject.tag == "Player") {
            transform.localScale = normalScale;

			
        }
	}

}
