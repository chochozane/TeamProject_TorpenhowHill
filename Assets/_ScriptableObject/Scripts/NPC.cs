using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float detectionRange = 2f;
    public GameObject player;
    public QuestData quest;

    public GameObject NPCUI;
    public GameObject UI;
    public GameObject Dialogue;
    public TextMeshProUGUI DialogueText;

    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI required;

    private int currentDialogueIndex = 0;


    private bool playerInRange = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogError("플레이어를 찾을 수 없습니다.");
        }
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= detectionRange)
        {
            if (!playerInRange)
            {
                playerInRange = true;
            }
        }
        else
        {
            if (playerInRange)
            {
                playerInRange = false;
            }
        }

        InteractNPC();
        OutRange();

        if (currentDialogueIndex < quest.Dialouge.Length)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentDialogueIndex++;
                ShowCurrentDialogue();

                if (currentDialogueIndex >= quest.Dialouge.Length)
                {
                    EndDialogue();
                }
            }
        }
    }

    #region dialogue
    private void StartDialogue()
    {
        ShowCurrentDialogue();
    }

    private void EndDialogue()
    {
        Dialogue.SetActive(false);
        SetQuest();
        UI.SetActive(true);
    }

    private void ShowCurrentDialogue()
    {
        Dialogue.SetActive(true);
        if (currentDialogueIndex < quest.Dialouge.Length)
        {
            DialogueText.text = quest.Dialouge[currentDialogueIndex];
        }
    }

    #endregion

    #region quest
    public void SetQuest()
    {
        title.text = quest.questTitle;
        description.text = quest.questDescription;


        string concatenatedText = "";

        foreach (RequiredResource resource in quest.requiredResource)
        {
            concatenatedText += $"{resource.resourceType}: {resource.requiredAmount}\n";
        }

        required.text = concatenatedText;
    }
    #endregion

    private void InteractNPC()
    {
        if (playerInRange)
        {
            NPCUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("상호작용");
                StartDialogue();
            }
        }
    }

    private void OutRange()
    {
        if (!playerInRange)
        {
            UI.SetActive(false);
            NPCUI.SetActive(false);
            Dialogue.SetActive(false);
        }
    }
}
