using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawnPoint : MonoBehaviour
{
    Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        transform.position = spawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
