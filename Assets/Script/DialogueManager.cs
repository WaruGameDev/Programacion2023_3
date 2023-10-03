using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
[System.Serializable]
public class Dialogue
{
    public string nameCharacter;
    public string dialogueCharacter;
    public Sprite portrait;
    public UnityEvent onShowDialogue;
}

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public TextMeshProUGUI nameCharacterText, dialogueCharacterText;
    public Image portraitImage;
    public List<Dialogue> dialogues;
    public int indexDialogue = 0;
    public CanvasGroup cg;
    public bool isTalking;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        cg.alpha = 0;
        cg.blocksRaycasts = false;
        cg.interactable = false;
        
    }
    public void ShowDialogue(Dialogue dialogue)
    {
        cg.alpha = 1;
        cg.blocksRaycasts = true;
        cg.interactable = true;
        nameCharacterText.text = dialogue.nameCharacter;
        dialogueCharacterText.text = dialogue.dialogueCharacter;
        portraitImage.sprite = dialogue.portrait;
        dialogue.onShowDialogue?.Invoke();       
    }
    public void NextDialogue()
    {
        indexDialogue++;
        if(indexDialogue >= dialogues.Count)
        {
            cg.alpha = 0;
            cg.blocksRaycasts = false;
            cg.interactable = false;
            isTalking = false;
            indexDialogue = 0;
        }
        else
        {
            ShowDialogue(dialogues[indexDialogue]);
        }
        
    }
    public void AddDialogues(List<Dialogue> dialoguesToAdd)
    {
        dialogues.Clear();
        dialogues.AddRange(dialoguesToAdd);
    }
}
