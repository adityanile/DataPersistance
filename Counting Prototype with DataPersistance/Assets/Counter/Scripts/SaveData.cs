using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{
    public Color color;
    public int score;
    private Counter counter;

    [SerializeField] PlayerData saveplayerdata = new PlayerData();

    private void Awake()
    {
        color = MainManager.Instance.backgroundColor;
        counter = GameObject.Find("Basket").GetComponent<Counter>();

    }

    public void OnClickedSave()
    {
        // Save this things for next session
        saveplayerdata.playerName = MainManager.Instance.playerName;
        saveplayerdata.color = MainManager.Instance.backgroundColor;
        saveplayerdata.highscore = counter.Count;

        string json = JsonUtility.ToJson(saveplayerdata);   // Save player data for next session in JSON file

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json); // Write data to json file

        Debug.Log("Data Written Successfully");

    }

}

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public Color color;
    public int highscore;
}


