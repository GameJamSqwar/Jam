using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Started!");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            spawned = true;
        }
        if (GameObject.FindGameObjectsWithTag("Player").Length <= 0 && spawned)
        {

        }
    }

    public void EndGame()
    {
        Debug.Log("Game Over!");
    }
}
