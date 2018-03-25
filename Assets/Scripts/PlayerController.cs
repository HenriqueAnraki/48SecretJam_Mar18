using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField] private GameObject obj_interact;

	public GameManager gameManager;
	public bool isActive;

	public Sprite[] playerSprites;

	// Use this for initialization
	private Rigidbody2D Rigid;
	public float speed;

	public GameObject back_to_present;
	public GameObject back_to_present2;
	public GameObject go_to_further_past;
	public GameObject bathroom;

	void Start () {
		Rigid = gameObject.GetComponent<Rigidbody2D>();
		
		speed = 3;

		isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isActive){
			Move();
			


			if( Input.GetKeyDown(KeyCode.Space) && obj_interact != null){
				Debug.Log("Interagindo com o objeto " + obj_interact.name + ".");	

				gameManager.Interact(obj_interact);
			}

			if(Input.GetKeyDown(KeyCode.Alpha1)){
				set_sprite(0);
			}
			if(Input.GetKeyDown(KeyCode.Alpha2)){
				set_sprite(1);
			}
			if(Input.GetKeyDown(KeyCode.Alpha3)){
				set_sprite(2);
			}
		} else {
			Rigid.velocity = new Vector2(0.0f, 0.0f);
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

	public void set_sprite(int id){
		
		gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[id];
		
	}

	public void Force_travel(int a){
		
		if(a == 0){
			gameObject.transform.position = back_to_present.transform.position;	
		} else if(a == 2){
			gameObject.transform.position = go_to_further_past.transform.position;
		} else if(a == 3){
			gameObject.transform.position = back_to_present2.transform.position;	
		} else {
			gameObject.transform.position = obj_interact.GetComponent<Interactable>().target_position;
		}
		

		if(gameManager.game_state == 10){
			gameManager.disableText();
		}

		if(gameManager.game_state == 16){
			gameManager.inputControl.isLastText = true;
		}


	}

	public void End_game(){
		isActive = false;
		gameObject.transform.position = bathroom.transform.position;	
	}
}
