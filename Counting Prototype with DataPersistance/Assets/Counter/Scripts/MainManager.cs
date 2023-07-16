using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public string playerName;
    public Color backgroundColor;
    public int highscore;

    void Awake()
    {
        // Now to get mainmanger only one time we check the value of instance if null or not
        // There has to be only one MainManager , Because we are changing varaible in MainManager.Instance.varaible_name
        // this changes varaible is used in other scene in similar way


        if(Instance != null)
        {
            Destroy(Instance);
            return;   // This return will stop the script and go to the start of the function
        }

        Instance = this;    // Now is instance is set as this script for all the instances of main manager
        DontDestroyOnLoad(gameObject);
        backgroundColor = new Color(1,202, 0, 255); // default color

        // Get Stored data by the user during last usage

        string path = Application.persistentDataPath + "/savefile.json";  // Get data from this json file if present

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);  // Converting json data to string

            GetData setData = JsonUtility.FromJson<GetData>(json); // string to unity script format

            // Setdata from the json file

            playerName = setData.playerName;
            backgroundColor = setData.color;
            highscore = setData.highscore;

            Debug.Log("Data Read Successfull");

        }

    }

}

public class GetData
{
   public string playerName;
   public Color color;
   public int highscore;
} 
