using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    public QuestData[] quests; // ����Ʈ ������ �迭

    // ����Ʈ�� �Ϸ�� ǥ���ϴ� �޼���
    public void CompleteQuest(QuestData quest)
    {
        quest.isCompleted = true; // ����Ʈ �Ϸ�� ǥ��
    }
}
