using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Guard : MonoBehaviour
{

    public Transform Player;

    int MoveSpeed = 20;
    int MaxDist = 10;
    int MinDist = 2;

    private NavMeshAgent navmesh;

    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }

        }
    }
}