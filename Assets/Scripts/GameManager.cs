using System.IO;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public string p_Name;

    public string p_bestName;
    public int p_bestScore;


    private void Awake()
    {
        if(!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }


    [System.Serializable]
    public class PlayerData
    {
        public string bestName;
        public int bestScore;
    }
    
    public void Save_PlayerData(string name, int score)
    {
        PlayerData playerData = new PlayerData();

        playerData.bestName = name;
        playerData.bestScore = score;

        string json = JsonUtility.ToJson(playerData);

        File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", json);
    }

    public void Load_PlayerData()
    {
        string path = Application.persistentDataPath + "/PlayerData.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            p_bestName = data.bestName;
            p_bestScore = data.bestScore;
        }
    }
}
