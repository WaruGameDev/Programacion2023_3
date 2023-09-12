using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public List<Dialogue> npcDialogues;
    public bool isPlayerInZone;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            DialogueManager.instance.AddDialogues(npcDialogues);
            isPlayerInZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;
        }
    }
    private void Update()
    {
        if(isPlayerInZone && Input.GetKeyDown(KeyCode.E))
        {
            if(!DialogueManager.instance.isTalking)
            {
                DialogueManager.instance.ShowDialogue(DialogueManager.instance.dialogues[0]);
                DialogueManager.instance.isTalking = true;
            }
            else
            {
                DialogueManager.instance.NextDialogue();
            }
            
        }
    }

}
