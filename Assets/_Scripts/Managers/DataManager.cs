using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData
{
    public int level;
    public int hp;
    public int xp;
    public GameObject[] inventoryItems;
    //public int itemCount;
    //NPC
    //Quest
}

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    PlayerData nowPlayer = new PlayerData();

    string path;
    string filname = "Save";
    private void Awake()
    {
        #region 싱글톤
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance.gameObject);
        }
        DontDestroyOnLoad(Instance);
        #endregion
        path = Application.persistentDataPath + "/";
    }


    void Start()
    {
        //nowPlayer.level = 100;
        string data = JsonUtility.ToJson(nowPlayer);

        File.WriteAllText(path + filname, data);
        //사용자/(사용자 이름)/AppData/LocalLow/DefaultCompany/TorpenhowHill(프로젝트 이름)/Save(filname)
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path + filname, data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + filname);
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }
}
