using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedSpawner : MonoBehaviour
{

    public GameObject spawnedEnemy;
    public bool       stopSpawning = false;
    public float      spawnTime;
    public float      spawnDelay;
    public int        spawnMax;
           int        count;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        if (count >= spawnMax)
        {
            CancelInvoke("SpawnObject");
        }
        else
        {
            Instantiate(spawnedEnemy, transform.position, transform.rotation);
        }
        count++;
    }
}
