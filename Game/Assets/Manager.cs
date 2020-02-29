using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Started!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame()
    {
        Debug.Log("Game Over!");
    }
}
