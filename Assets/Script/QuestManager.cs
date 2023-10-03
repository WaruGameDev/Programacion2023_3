using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QUEST_STATUS
{
    UNASSIGNED, ASSIGNED, COMPLETE
}
[System.Serializable]
public class Quest
{
    public string nameQuest;
    public QUEST_STATUS statusQuest;
}


public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public List<Quest> quests;
    private void Awake()
    {
        instance = this;        
    }    
    public void ChangeQuestStatus(string questToChange, QUEST_STATUS newQuestStatus)
    {
        foreach(Quest q in quests)
        {
            if(q.nameQuest == questToChange)
            {
                q.statusQuest = newQuestStatus;
            }
        }
    }
    public QUEST_STATUS GetQuestStatus(string questToGetStatus)
    {
        foreach(Quest q in quests)
        {
            if(q.nameQuest == questToGetStatus)
            {
                return q.statusQuest;
            }
        }
        return QUEST_STATUS.UNASSIGNED;
    }
    public void AddQuest(Quest newQuest)
    {
        quests.Add(newQuest);
    }
    public void AddQuest(string newQuest)
    {
        Quest q = new Quest();
        q.nameQuest = newQuest;
        q.statusQuest = QUEST_STATUS.ASSIGNED;
        quests.Add(q);
    }
}
