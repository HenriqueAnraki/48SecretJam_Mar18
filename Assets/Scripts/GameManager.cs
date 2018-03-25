using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public int game_state;//estado atual
	public GameObject[] objs;//vetor de ordem de interação de objetos

	public GameObject Player;//referencia do player
	public PlayerController playerController;

	public InputControl inputControl;
	public GameObject LockedDoor;
	public GameObject book;
	public GameObject[] stairSecret;

	private int count;


	// Use this for initialization
	void Start () {
		game_state = 0;
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(game_state == 8){
			book.SetActive(true);
		}
		
	}

	public void Interact(GameObject go){
		if (go.tag == "Door" && !go.GetComponent<Interactable>().isLocked){

			Player.transform.position = go.GetComponent<Interactable>().target_position;

			if(objs[game_state] == go) {
		
				Debug.Log("Objeto certo");
				game_state++;

				playerController.isActive = false;
				inputControl.ShowDialog();

				if(game_state == 15){
					inputControl.forceTravel = 2;
				}

				
			}	

		} else if(game_state >= objs.Length){
			
			Debug.Log("Fim de jogo =D");
		
		} else if(objs[game_state] == go) {

			if(go.tag == "Trigger"){
			
				inputControl.beginWithoutInput = true;
				go.tag = "Untagged";
			
			} else if(go.tag == "Box"){
			
				if(count == 1) {
					inputControl.forceTravel = 1;
					count = -1;
				}
				count++;
			
			} else if(go.tag == "Bookcase" && game_state != 11 ){
			
				go.SetActive(false);
				stairSecret[count++].SetActive(true);
				if(count == 1)
					inputControl.forceTravel = 1;	
			
			} else if (go.tag == "Book"){
				go.SetActive(false);
			}
			
			Debug.Log("Objeto certo");
			game_state++;

			

			playerController.isActive = false;
			inputControl.ShowDialog();

			if(game_state == 16){
				inputControl.forceTravel = 3;
			}

			if(go.tag == "Key"){
				LockedDoor.GetComponent<Interactable>().isLocked = false;
			}
		
		} else {
		
			Debug.Log("Objeto errado");

			playerController.isActive = false;
			inputControl.ShowWrongDialog();
		
		}
	}

	public void disableText(){
		inputControl.beginWithoutInput = false;
		inputControl.forceTravel = 1;
		inputControl.timerOn = true;
		inputControl.isActive = false;
		game_state++;
		
	}


	public void End_game(){

	}
}
