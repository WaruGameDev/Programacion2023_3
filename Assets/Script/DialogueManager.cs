using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[System.Serializable]
public class Dialogue
{
    public string nameCharacter;
    public string dialogueCharacter;
    public Sprite portrait;
}

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public TextMeshProUGUI nameCharacterText, dialogueCharacterText;
    public Image portraitImage;
    public List<Dialogue> dialogues;
    public int indexDialogue = 0;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        ShowDialogue(dialogues[indexDialogue]);
    }
    public void ShowDialogue(Dialogue dialogue)
    {
        nameCharacterText.text = dialogue.nameCharacter;
        dialogueCharacterText.text = dialogue.dialogueCharacter;
        portraitImage.sprite = dialogue.portrait;
    }
    public void NextDialogue()
    {
        indexDialogue++;
        if(indexDialogue >= dialogues.Count)
        {
            return;
        }
        else
        {
            ShowDialogue(dialogues[indexDialogue]);
        }
        
    }
}
