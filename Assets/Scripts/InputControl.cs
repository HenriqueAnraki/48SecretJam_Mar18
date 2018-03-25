using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour {

    public GameObject dialogManager;
    public GameObject dialogBox;
    private string dialog;
    public int dialogNumber;

    public bool isActive;
    public bool beginWithoutInput;
    public bool wrongMessage;
    public int forceTravel;
    public bool timerOn;
    public bool isLastText;

    private float nextTravel;
    private float travelFrame = 2.0f; 

    public PlayerController playerController;

    private void Start()
    {
        dialog = "dialog";
        dialogNumber = 0;
        isActive = true;
        beginWithoutInput = true;
        wrongMessage = false;
        forceTravel = 0;
        timerOn = false;
        isLastText = false;
    }

    // Update is called once per frame
    void Update () {
        //Verifica se o player apertou Enter e avança uma fala caso esteja disponível
        if (isActive && (Input.GetKeyUp(KeyCode.Space) || beginWithoutInput) )
        {
            if (!dialogManager.gameObject.activeSelf || !dialogBox.gameObject.activeSelf)
            {
                dialogManager.gameObject.SetActive(true);
                if(!wrongMessage){
                    dialogNumber++;
                    //if (dialogNumber > 6) dialogNumber = 1;
                    beginWithoutInput = false;
                    dialogManager.transform.GetComponent<TextImporter>().changeFile(dialog+dialogNumber,"Tempos");
                } else {
                    dialogManager.transform.GetComponent<TextImporter>().changeFile(dialog+"Wrong","Tempos");
                }
            }
            if(!dialogManager.transform.GetComponent<TextImporter>().textInput() ){
                setValues(forceTravel);
            }
        }

        if(timerOn){
            if(  nextTravel < Time.time ){
                timerOn = false;
                setValues(0);
            }
        }
    }

    private void setValues(int a){
        int b = a;
        isActive = false;
        playerController.isActive = true;
        wrongMessage = false;
        
        if(isLastText){
            playerController.End_game();
        }
        
        if(forceTravel > 0){
            forceTravel = 0;

             

            beginWithoutInput = true;
            isActive = true;
            playerController.isActive = false;

            if(a == 3) a = 0;
            playerController.set_sprite( a );
            playerController.Force_travel(b);

            nextTravel = Time.time + travelFrame;
        }

        
    }

    public void ShowDialog(){

        isActive = true;

    }

    public void ShowWrongDialog(){
        wrongMessage = true;
        isActive = true;
    }
}
