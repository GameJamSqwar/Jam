using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Guard : MonoBehaviour
{
    Transform player;
    public int MoveSpeed;
    public int MaxDist;
    public int MinDist;

    private NavMeshAgent navmesh;

    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        foreach (var playerObject in GameObject.FindGameObjectsWithTag("Player"))
        {
            player = playerObject.transform;
        }

        transform.LookAt(player);

        if (Vector3.Distance(transform.position, player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }

        }
    }
}