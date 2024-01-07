using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class NPC : MonoBehaviour
{
    public float detectionRange = 2f;
    public GameObject player;
    public QuestData quest;

    public GameObject UI;
    public GameObject Dialogue;
    public TextMeshProUGUI DialogueText;

    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI required;

    private int currentDialogueIndex = 0;
    private int currentOnGoingIndex = 0;
    private int currentCompleteIndex = 0;
    private int currentCompletedIndex = 0;

    private bool IsDialouge;

    private Inventory inventory;

    private bool playerInRange = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogError("플레이어를 찾을 수 없습니다.");
        }
        inventory = FindObjectOfType<Inventory>();
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
        NPCDialogue();
    }

    #region dialogue
    private void StartDialogue()
    {
        ShowCurrentDialogue();
    }

    private void EndDialogue()
    {
        DialougeSetFlase();
    }

    private void NPCDialogue()
    {
        if (playerInRange)
        {
            if (IsDialouge)
            {
                if (!quest.onGoing)
                {
                    if (currentDialogueIndex < quest.Dialouge.Length)
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            currentDialogueIndex++;
                            ShowCurrentDialogue();

                            if (currentDialogueIndex >= quest.Dialouge.Length)
                            {
                                currentDialogueIndex = 0;
                                EndDialogue();
                                SetQuest();
                                QuestOngoing();
                                UI.SetActive(true);
                            }
                        }
                    }
                }
                else if (!quest.isCompleted)
                {
                    if (!HasRequiredItems())
                    {
                        if (currentOnGoingIndex < quest.OnGoing.Length)
                        {
                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                currentOnGoingIndex++;
                                ShowCurrentDialogue();

                                if (currentOnGoingIndex >= quest.OnGoing.Length)
                                {
                                    currentOnGoingIndex = 0;
                                    EndDialogue();
                                }
                            }
                        }
                    }
                    else if (HasRequiredItems())
                    {
                        if (currentCompleteIndex < quest.Complete.Length)
                        {
                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                currentCompleteIndex++;
                                ShowCurrentDialogue();

                                if (currentCompleteIndex >= quest.Complete.Length)
                                {
                                    currentCompleteIndex = 0;
                                    EndDialogue();
                                    QuestComplete();
                                }
                            }
                        }
                    }
                }
                else if (quest.isCompleted)
                {
                    if (currentCompletedIndex < quest.Completed.Length)
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            currentCompletedIndex++;
                            ShowCurrentDialogue();

                            if (currentCompletedIndex >= quest.Completed.Length)
                            {
                                currentCompletedIndex = 0;
                                EndDialogue();
                            }
                        }
                    }
                }
            }
        }
    }


    private void ShowCurrentDialogue()
    {
        DialogueSetTrue();
        if (!quest.onGoing)
        {
            if (currentDialogueIndex < quest.Dialouge.Length)
            {
                DialogueText.text = quest.Dialouge[currentDialogueIndex];
            }
        }
        else if (!quest.isCompleted)
        {
            if (!HasRequiredItems())
            {
                if (currentOnGoingIndex < quest.OnGoing.Length)
                {
                    DialogueText.text = quest.OnGoing[currentOnGoingIndex];
                }
            }
            else if (HasRequiredItems())
            {
                if (currentCompleteIndex < quest.Complete.Length)
                {
                    DialogueText.text = quest.Complete[currentCompleteIndex];
                }
            }

        }

        else if (quest.isCompleted)
        {
            if (currentCompletedIndex < quest.Completed.Length)
            {
                DialogueText.text = quest.Completed[currentCompletedIndex];
            }
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("상호작용");
                StartDialogue();
            }
        }
    }

    private void QuestOngoing()
    {
        quest.onGoing = true;
    }

    private void QuestComplete()
    {
        foreach (RequiredResource requiredResource in quest.requiredResource)
        {
            ItemData item = requiredResource.item;
            ResourceType resourceType = requiredResource.resourceType;
            int requiredAmount = requiredResource.requiredAmount;

            inventory.RemoveItem(item, requiredAmount);

            switch (resourceType)
            {
                case ResourceType.Wood:
                    break;
                case ResourceType.Stone:
                    break;
                case ResourceType.Grass:
                    break;
            }
        }
        quest.isCompleted = true;
    }

    #region Dialogue
    private void DialogueSetTrue()
    {
        IsDialouge = true;
        Dialogue.SetActive(true);
    }

    private void DialougeSetFlase()
    {
        IsDialouge = false;
        Dialogue.SetActive(false);
    }
    #endregion

    private bool HasRequiredItems()
    {
        foreach (RequiredResource requiredResource in quest.requiredResource)
        {
            ItemData item = requiredResource.item;
            int requiredAmount = requiredResource.requiredAmount;
            ResourceType resourceType = requiredResource.resourceType;

            bool hasItem = inventory.CheckQuestCompletion(item, requiredAmount);
            if (!hasItem)
            {
                return false;
            }

            switch (resourceType)
            {
                case ResourceType.Wood:
                    break;
                case ResourceType.Stone:
                    break;
                case ResourceType.Grass:
                    break;
            }
        }


        return true;

    }
}
