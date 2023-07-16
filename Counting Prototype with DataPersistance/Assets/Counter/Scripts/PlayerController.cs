using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalinput;
    [SerializeField] private float speed = 20;

    private GameManager gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalinput = Input.GetAxis("Horizontal");

        if (gameManager.isgameactive)
        {
            // Bounding the player
            if (transform.position.x < -25)
            {
                transform.position = new Vector3(-25, transform.position.y, transform.position.z);
            }
            if (transform.position.x > 105)
            {
                transform.position = new Vector3(105, transform.position.y, transform.position.z);
            }
        
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalinput);

        }
    }
}
