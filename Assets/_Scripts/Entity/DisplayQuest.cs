using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayQuest : MonoBehaviour
{
    public QuestData[] questDatas;

    public TextMeshProUGUI OngoingQuest;

    public RequiredResource requiredResource;

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        string text = "진행중인 퀘스트 :\n";
        string ongoingQuests = "";
        string requireQuest = "";
        for (int i = 0; i < questDatas.Length; i++)
        {
            if (questDatas[i] != null)
            {
                if (questDatas[i].onGoing == true && questDatas[i].isCompleted == false)
                {
                    ongoingQuests = questDatas[i].questTitle;
                    foreach (RequiredResource resource in questDatas[i].requiredResource)
                    {
                        requireQuest += ($"{resource.resourceType}: {resource.requiredAmount}\n");
                    }

                }
                else if (questDatas[i].isCompleted == true)
                {
                    ongoingQuests = "";
                    requireQuest = "";
                }
            }


            
        }
        //foreach (QuestData questData in questDatas)
        //{
        //    if (questData.onGoing)
        //    {
                
        //    }
        //}

        OngoingQuest.text = text + ongoingQuests+ "\n" + requireQuest;
    }
}
