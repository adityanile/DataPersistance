using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Menu : MonoBehaviour
{
    public TMP_InputField name;
    public TextMeshProUGUI highscore;

    // Start is called before the first frame update
    void Start()
    {
                  name.text = MainManager.Instance.playerName;
                  highscore.text = "High Score:- " + Convert.ToString( MainManager.Instance.highscore );
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void OnClickStart()
    {
        MainManager.Instance.playerName = name.text; // name according to player input 
        Debug.Log("Player Name set to:- " + name.text);
        SceneManager.LoadScene(1);  // Load Scene one when clicked start
    }

}
