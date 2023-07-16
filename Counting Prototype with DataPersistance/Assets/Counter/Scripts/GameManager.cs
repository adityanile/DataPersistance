using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

using Random = UnityEngine.Random;           // Because system also have a reference to random so we have to clarify that we are using unity engine random

public class GameManager : MonoBehaviour
{
    public GameObject ballprefab;
    public bool isgameactive = false;
    private float spawninterval;

    public Text timer;

    public GameObject finaltitles;

    Text finalscore;

    public TextMeshProUGUI player;

   float time = 60; // 1 min timer to end the game

    private Counter counter;

    public Color newColor; // Get Access to ground color to change it with players choice

    public GameObject ground;
    public GameObject plane;

    // Start is called before the first frame update
    void Start()
    {
    
            ground.gameObject.GetComponent<Renderer>().material.color = new Color(newColor.r, newColor.g, newColor.b, newColor.a);
            plane.gameObject.GetComponent<Renderer>().material.color = new Color(newColor.r, newColor.g, newColor.b, newColor.a);
        
        player.text = "Player:- " + MainManager.Instance.playerName;   // Get player name form the input of the main menu
    }
    private void Awake()
    {
        newColor = MainManager.Instance.backgroundColor;   // Set Colour Here
        
        // There are 2 planes vertical and horizotal
        ground = GameObject.Find("Ground");
        plane = GameObject.Find("Plane");
    }

    // Update is called once per frame
    void Update()
    {
        SetTimer();
        GameOver();

    }

    void SetTimer()
    {
        if (isgameactive)
        {
            time = time - Time.deltaTime ;
            timer.text = "Timer:- " +  Convert.ToInt16( time );
        }
    }

    void GameOver()
    {
        if (time < 0)
        {
            isgameactive = false;
            finaltitles.SetActive(true);
            time = 0;
            finalscore.text = "Final Score is:- " + counter.Count;
        }
    }

    IEnumerator SpawnBalls()
    {
        while (isgameactive)
        {
            yield return new WaitForSeconds(spawninterval);

            float spawnXmin = -21.4f;
            float spawnXmax = 100.0f;

            Vector3 spawnpos = new Vector3( Random.Range(spawnXmin, spawnXmax), 97, 0);

            Instantiate(ballprefab, spawnpos , ballprefab.transform.rotation);

        }

    }

    public void StartGame(float difficulty)
    {
        counter = GameObject.Find("Basket").GetComponent<Counter>();
        finalscore = GameObject.Find("finalscore").GetComponent<Text>();

        spawninterval = difficulty;

        isgameactive = true;
        StartCoroutine(SpawnBalls());

        timer.text = "Timer:- " + time;
    }

    public void OnClickPlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
