using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public QuestData[] questDatas;
    public void StartToMainScene()
    {
        SoundManager.instance.uiSound.ClickAudio();
        SceneManager.LoadScene("MainScene");
        ResetQuest();
    }

     private void ResetQuest()
    {
        for (int i = 0; i < questDatas.Length; i++)
        {
            questDatas[i].onGoing = false;
            questDatas[i].isCompleted = false;
        }
    }
}
