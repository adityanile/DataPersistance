using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        MainManager.Instance.backgroundColor = gameObject.GetComponent<Renderer>().material.color; // Get color of the material Player clicked 
        // Set set colour of the material to pass into next Scene
        Debug.Log("Color Set" + MainManager.Instance.backgroundColor);
    }

}
