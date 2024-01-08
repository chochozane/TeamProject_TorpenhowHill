using System.Collections;
using System.Collections.Generic;
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
        Debug.Log(IsClear);
    }
}

