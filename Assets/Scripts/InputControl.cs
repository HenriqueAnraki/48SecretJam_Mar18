using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour {

    public GameObject dialogManager;
    public GameObject dialogBox;
    private string dialog;
    public int dialogNumber;

    private void Start()
    {
        dialog = "dialog";
        dialogNumber = 0;
    }

    // Update is called once per frame
    void Update () {
        //Verifica se o player apertou Enter e avança uma fala caso esteja disponível
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (!dialogManager.gameObject.activeSelf || !dialogBox.gameObject.activeSelf)
            {
                dialogNumber++;
                if (dialogNumber > 6) dialogNumber = 1;

                dialogManager.gameObject.SetActive(true);
                dialogManager.transform.GetComponent<TextImporter>().changeFile(dialog+dialogNumber,"Tempos");
            }
            dialogManager.transform.GetComponent<TextImporter>().textInput();
        }
    }
}
