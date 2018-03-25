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


	// Use this for initialization
	void Start () {
		game_state = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Interact(GameObject go){
		if (go.tag == "Door" && !go.GetComponent<Interactable>().isLocked){

			Player.transform.position = go.GetComponent<Interactable>().target_postion;

			if(objs[game_state] == go) {
		
				Debug.Log("Objeto certo");
				game_state++;

				playerController.isActive = false;
				inputControl.ShowDialog();
			
			}	

		} else if(game_state >= objs.Length){
			
			Debug.Log("Fim de jogo =D");
		
		} else if(objs[game_state] == go) {
			if(go.tag == "Trigger"){
				inputControl.beginWithoutInput = true;
				go.tag = "Untagged";
			}
		
			Debug.Log("Objeto certo");
			game_state++;

			playerController.isActive = false;
			inputControl.ShowDialog();

			if(go.tag == "Key"){
				LockedDoor.GetComponent<Interactable>().isLocked = false;
			}
		
		} else {
		
			Debug.Log("Objeto errado");

			playerController.isActive = false;
			inputControl.ShowWrongDialog();
		
		}
	}
}
