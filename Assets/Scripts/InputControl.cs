using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour {

    public GameObject dialogManager;
    public GameObject dialogBox;
    public string dialog;

    private void Start()
    {
        dialog = "dialog1";
    }

    // Update is called once per frame
    void Update () {
        //Verifica se o player apertou Enter e avança uma fala caso esteja disponível
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (!dialogManager.gameObject.activeSelf || !dialogBox.gameObject.activeSelf)
            {
                dialogManager.gameObject.SetActive(true);
                dialogManager.transform.GetComponent<TextImporter>().changeFile(dialog,"Tempos");
            }
            dialogManager.transform.GetComponent<TextImporter>().textInput();
        }
    }
}
