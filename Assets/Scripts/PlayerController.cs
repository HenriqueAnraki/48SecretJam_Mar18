using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField] private GameObject obj_interact;

	public GameManager gameManager;
	public bool isActive;

	// Use this for initialization
	private Rigidbody2D Rigid;
	public float speed;

	void Start () {
		Rigid = gameObject.GetComponent<Rigidbody2D>();
		
		speed = 3;

		isActive = true; //false
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isActive){
			Move();
			
			if( Input.GetKeyDown(KeyCode.Space) && obj_interact != null){
				Debug.Log("Interagindo com o objeto " + obj_interact.name + ".");	

				gameManager.Interact(obj_interact);
			}
		}
	}

	void Move() {
		//transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.y);

		float h = Input.GetAxisRaw ("Horizontal");
		//float v = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (h, 0.0f);

		Rigid.velocity = movement.normalized * speed;		
		
	}

	public void set_interaction(GameObject b){
		//flag_interaction = b;
		obj_interact = b;
	}
}
