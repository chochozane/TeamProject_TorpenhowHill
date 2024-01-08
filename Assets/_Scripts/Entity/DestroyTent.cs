using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTent : MonoBehaviour
{
    public QuestData quest;

    private void Update()
    {
        Destroy();
    }

    private void Destroy()
    {
        if (quest.isCompleted)
        {
            gameObject.SetActive(false);
        }
    }
}