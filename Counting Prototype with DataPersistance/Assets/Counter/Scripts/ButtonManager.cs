using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    public float difficulty;
    private Button button;
    private GameManager gameManager;

    public GameObject starttiles;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>(); 
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        button.onClick.AddListener(OnClickButton);  // Added Event listener to the Button 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClickButton()
    {
        gameManager.StartGame(difficulty);   // Start the game with the diferent difficulty of each button set using unity inspector
        starttiles.SetActive(false);
    }

}
