using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void StartToMainScene()
    {
        SoundManager.instance.uiSound.ClickAudio();
        SceneManager.LoadScene("MainScene");
    }
}
