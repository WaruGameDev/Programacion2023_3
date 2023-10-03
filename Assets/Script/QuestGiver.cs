using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest questToGive;
    
    public void GiveQuest()
    {
        QuestManager.instance.AddQuest(questToGive);
    }
    public void GiveQuest(string newQuest)
    {
        QuestManager.instance.AddQuest(newQuest);
    }
}
