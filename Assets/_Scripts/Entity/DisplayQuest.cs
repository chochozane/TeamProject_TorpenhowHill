using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayQuest : MonoBehaviour
{
    public QuestData[] questDatas;

    public TextMeshProUGUI OngoingQuest;

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        string ongoingQuests = "진행중인 퀘스트 :\n";

        foreach (QuestData questData in questDatas)
        {
            if (questData.onGoing)
            {
                ongoingQuests += "- " + questData.questTitle + "\n";
            }
        }

        OngoingQuest.text = ongoingQuests;
    }
}
