using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestData quest;


    private void QuestOngoing()
    {
        quest.onGoing = true;
    }

    private void QuestComplete()
    {
        quest.isCompleted = true;
    }

}

