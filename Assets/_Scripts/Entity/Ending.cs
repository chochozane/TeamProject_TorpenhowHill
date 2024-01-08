using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public QuestData[] questDatas;
    public bool IsClear;

    private void CheckClear()
    {
        IsClear = true;

        foreach (QuestData questData in questDatas)
        {
            if (!questData.isCompleted)
            {
                IsClear = false;
                break;
            }
        }
    }

    private void Update()
    {
        CheckClear();
        if (IsClear)
        {
            GameManager.Instance.Victory();
        }
        
    }
}

