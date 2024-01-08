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
        string ongoingQuests= "";

        foreach (QuestData questData in questDatas)
        {
            if (questData.onGoing)
            {
                ongoingQuests = "진행중인 퀘스트 :\n" + "- " + questData.questTitle;
            }
        }

        OngoingQuest.text = ongoingQuests;
    }
}
