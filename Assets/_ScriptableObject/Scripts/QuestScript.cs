using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    public QuestData[] quests; // 퀘스트 데이터 배열

    // 퀘스트를 완료로 표시하는 메서드
    public void CompleteQuest(QuestData quest)
    {
        quest.isCompleted = true; // 퀘스트 완료로 표시
    }
}
