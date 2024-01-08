using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestData[] quest;

    private void ClearCheck()
    {
        quest[0].isCompleted = true;
    }



}

