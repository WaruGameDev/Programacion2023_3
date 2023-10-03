using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestStatusDetector : MonoBehaviour
{
    public UnityEvent onDetectQuest;
    public string questName;
    public void Detect()
    {
        if(QuestManager.instance.GetQuestStatus(questName)== QUEST_STATUS.ASSIGNED)
        {
            onDetectQuest?.Invoke();
        }
    }
    private void Update()
    {
        Detect();
    }
}
