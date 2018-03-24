using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private bool flag_interaction;

	// Use this for initialization
	private Rigidbody2D Rigid;
	public float speed;

	void Start () {
		Rigid = gameObject.GetComponent<Rigidbody2D>();
		
		speed = 3;

		flag_interaction = false;

	}
	
	// Update is called once per frame
	void Update () {
		Move();

		
		if( Input.GetKeyDown(KeyCode.Space) && flag_interaction){
			Debug.Log("Interagindo com o objeto.");
			
		}
	}

	void Move() {
		//transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.y);

		float h = Input.GetAxisRaw ("Horizontal");
		//float v = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (h, 0.0f);

		Rigid.velocity = movement.normalized * speed;		
		
	}

	public void set_interaction(bool b){
		flag_interaction = b;
	}
}
