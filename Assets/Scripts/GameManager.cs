using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private int game_state;//estado atual
	public int[] objs;//vetor de ordem de interação de objetos

	public GameObject Player;//referencia do player


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Interact(GameObject go){
		if (go.tag == "Door"){
			Player.transform.position = go.GetComponent<Interactable>().target_postion;
		}
	}
}
