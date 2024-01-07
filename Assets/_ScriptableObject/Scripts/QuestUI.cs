using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    public QuestData quest;

    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI required;

    public void SetQuest()
    {
        title.text = quest.questTitle;
        description.text = quest.questDescription;


        string concatenatedText = "Required Resources:\n";

        foreach (RequiredResource resource in quest.requiredResource)
        {
            concatenatedText += $"{resource.resourceType}: {resource.requiredAmount}\n";
        }

        required.text = concatenatedText;
    }
}
