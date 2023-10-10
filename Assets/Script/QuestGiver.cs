using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest questToGive;
    
    public void GiveQuest()
    {
        if(QuestManager.instance.GetQuestStatus(questToGive.nameQuest) 
            == QUEST_STATUS.UNASSIGNED)
        {
            QuestManager.instance.AddQuest(questToGive);
        }
        if(questToGive.statusQuest == QUEST_STATUS.COMPLETE)
        {
            QuestManager.instance.
                ChangeQuestStatus(questToGive.nameQuest, QUEST_STATUS.COMPLETE);
        }
        
    }
    public void GiveQuest(string newQuest)
    {
        if (QuestManager.instance.GetQuestStatus(questToGive.nameQuest)
            == QUEST_STATUS.UNASSIGNED)
        {
            QuestManager.instance.AddQuest(newQuest);
        }
        if (questToGive.statusQuest == QUEST_STATUS.COMPLETE)
        {
            QuestManager.instance.
                ChangeQuestStatus(questToGive.nameQuest, QUEST_STATUS.COMPLETE);
        }        
    }
}
