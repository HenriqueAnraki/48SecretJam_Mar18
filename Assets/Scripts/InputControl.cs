using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour {

    public GameObject dialogManager;
    public GameObject dialogBox;
    private string dialog;
    public int dialogNumber;

    public bool isActive;

    public PlayerController playerController;

    private void Start()
    {
        dialog = "dialog";
        dialogNumber = 1;
        isActive = false; //true
    }

    // Update is called once per frame
    void Update () {
        //Verifica se o player apertou Enter e avança uma fala caso esteja disponível
        if (isActive && Input.GetKeyUp(KeyCode.Space))
        {
            if (!dialogManager.gameObject.activeSelf || !dialogBox.gameObject.activeSelf)
            {
                //dialogNumber++;
                //if (dialogNumber > 6) dialogNumber = 1;

                dialogManager.gameObject.SetActive(true);
                dialogManager.transform.GetComponent<TextImporter>().changeFile(dialog+dialogNumber,"Tempos");
            }
            if(!dialogManager.transform.GetComponent<TextImporter>().textInput()){
                isActive = false;
                playerController.isActive = true;
            }
        }
    }

    public void ShowDialog(){

        isActive = true;

    }
}
