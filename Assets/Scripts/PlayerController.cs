using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	private Rigidbody2D Rigid;
	public float speed;

	void Start () {
		Rigid = gameObject.GetComponent<Rigidbody2D>();
		
		speed = 3;

	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move() {
		//transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.y);

		float h = Input.GetAxisRaw ("Horizontal");
		//float v = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (h, 0.0f);

		Rigid.velocity = movement.normalized * speed;		
		
	}
}
