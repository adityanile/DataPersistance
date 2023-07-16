using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    private GameManager gameManager;
    private GameObject basket;

    public ParticleSystem catcheffect;
    public AudioClip catchsound;
    private AudioSource playaudio;

    public int Count = 0;

    private void Start()
    {
        basket = GameObject.Find("Basket");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        playaudio = GetComponent<AudioSource>();

        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.isgameactive)
        {
            Instantiate(catcheffect, transform.position, catcheffect.transform.rotation);

            playaudio.PlayOneShot(catchsound, 0.5f);
            Destroy(other.gameObject);

            Count += 1;
            CounterText.text = "Count : " + Count;
        }
    }

   

}
