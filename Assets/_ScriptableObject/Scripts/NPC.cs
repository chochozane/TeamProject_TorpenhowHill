using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float detectionRange = 5f;
    public GameObject player;
    public QuestData quest;

    public QuestUI questUI;

    public GameObject NPCUI;
    public GameObject UI;
    public GameObject Dialogue;
    public TextMeshProUGUI DialogueText;

    private bool playerInRange = false;

    private void Start()
    {
        NPCUI.SetActive(false);
        UI.SetActive(false);

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
                NPCUI.SetActive(true);
            }
        }
        else
        {
            if (playerInRange)
            {
                playerInRange = false;
                NPCUI.SetActive(false);
            }
        }
    }

    private void StartDialogue()
    {
        Dialogue.SetActive(true);
        DialogueText.text = ($"{quest.Dialouge[1]}");
        DialogueText.text = ($"{quest.Dialouge[2]}");
        DialogueText.text = ($"{quest.Dialouge[3]}");
        if (Input.GetKeyDown(KeyCode.E))
        {
            questUI.SetQuest();
            UI.SetActive(true);
        }
    }

    private void EndDialouge()
    {
        Dialogue.SetActive(false);
    }
}
