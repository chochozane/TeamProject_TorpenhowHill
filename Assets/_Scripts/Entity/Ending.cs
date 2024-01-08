using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public QuestData[] questDatas;
    public bool IsClear;

    public bool _continue = false;

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
        if (!_continue)
        {
            if (IsClear)
            {
                GameManager.Instance.Victory();

                foreach (QuestData questData in questDatas)
                {
                    questData.isCompleted = false;
                }
            }
        }
        
    }
}

