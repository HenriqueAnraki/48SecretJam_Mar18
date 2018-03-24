using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextImporter : MonoBehaviour
{
    public TextAsset dialogFile;//Representa o arquivo de diálogo a ser carregado
    public Sprite[] portraits;  //Representa cada portrait que é carregado em um único arquivo
    public Image dialogBox;     //A caixa de diálogo que será usada para a impressão do texto
    public Text boxText;        //O lugar em que será imprimido a fala
    public Text charName;       //O lugar em que será imprimido o nome do personagem
    public Image charImage;     //O lugar em que será mostrado o retrato do personagem

    private string[] lines;         //Representa a subdivisão do arquivo em linhas
    private string[] charCommand;   //usado como auxílio ao separar comandos por ; no diálogo
    private string[] colorParts;    //usado como auxílo para obter os valores rgb da cor do texto
    private int lineNumber;         //usado para identificar a última linha processada
    private Sprite usedPortrait;    //usado para recuperar o sprite de índice correto dentro do array portraits

    //Inicialização
    void Start()
    {

    }

    //Mostra o texto que está na linha do arquivo de número lineNumber
    //Faz também verificações de comandos para o diálogo no arquivo de texto
    void showText()
    {
        //Fazer mecânica de trocar linhas?
        //else if (lines[lineNumber].Contains("LINE"))

        //Fazer mecânica de trocar arquivo?
        //else if (lines[lineNumber].Contains("FILE"))

        //Fazer mecânica de emoticons?
        //else if (lines[lineNumber].Contains("EMOT"))

        if (lineNumber > lines.Length)//Teste de fim de arquivo
            dialogBox.gameObject.SetActive(false);

        //Mecânicas que gastam linhas aqui

        if (lineNumber < lines.Length-1)//Caso o arquivo não tenha acabado mesmo dps de pular algumas linhas
        {
            //Fim do diálogo
            if (lines[lineNumber].Contains("END"))
            {
                dialogBox.gameObject.SetActive(false);
            }
            //Mostrar o texto
            else
            {
                charCommand = (lines[lineNumber].Split(';'));//Divide a linha com ;
                charName.text = charCommand[0];

                if (charCommand.GetLength(0) > 1)//Se houver 1 comando de texto na linha
                {
                    if (charCommand.GetLength(0) > 2)//Se houver 2 comandos de texto na linha
                    {
                        //Recupera o portrait indicado para o personagem
                        usedPortrait = portraits[System.Convert.ToInt32(charCommand[2])];
                        charImage.gameObject.SetActive(true);
                        charImage.transform.GetComponent<Image>().sprite = usedPortrait;
                    }
                    else
                    {
                        charImage.gameObject.SetActive(false);
                    }

                    //Recupera a cor indicada para o texto
                    colorParts = (charCommand[1].Split(' '));
                    Color textColor = new Color(float.Parse(colorParts[0]), float.Parse(colorParts[1]), float.Parse(colorParts[2]));
                    boxText.color = textColor;
                    charName.color = textColor;
                }
                boxText.text = lines[lineNumber + 1];
                lineNumber += 2;
            }
        }
    }

    //*******************************MÉTODOS PUBLICOS**********************************************
    //Carrega um novo arquivo para diálogo de nome escrito em newFile
    public void changeFile(string newFile, string filePortraits)
    {
        dialogFile = (TextAsset)Resources.Load("Texts/" + newFile, typeof(TextAsset));
        portraits = Resources.LoadAll<Sprite>("Portraits/" + filePortraits);
        lines = (dialogFile.text.Split('\n'));
        lineNumber = 0;
    }

    //É chamado ao receber um input que envolve diálogo
    public void textInput()
    {
        if (!dialogBox.isActiveAndEnabled)
        {
            dialogBox.gameObject.SetActive(true);
            lineNumber = 0;
        }
        showText();
    }
}
