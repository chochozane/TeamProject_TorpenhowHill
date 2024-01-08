using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNPC : MonoBehaviour
{
    public QuestData[] quest;
    public GameObject[] NPC;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (quest[0].isCompleted)
        {
            NPC[0].transform.position = new Vector3(0.61f, -2.52f, 0);
        }
        if (quest[1].isCompleted)
        {
            NPC[1].transform.position = new Vector3(-0.91f, 5.03f, 0);
        }
        if (quest[2].isCompleted)
        {
            NPC[2].transform.position = new Vector3(10.7f, 3.56f, 0);
        }
    }
}
