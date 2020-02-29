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
        //var distance = Vector3.Distance(transform.position, target.position);

        GameObject closestPlayer = FindClosestPlayer();

        player = closestPlayer.transform;

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

    private GameObject FindClosestPlayer()
    {
        GameObject closestPlayer = null;
        float closestDistance = 0;

        foreach (var playerObject in GameObject.FindGameObjectsWithTag("Player"))
        {
            float distance = Vector3.Distance(transform.position, playerObject.transform.position);
            if (closestPlayer == null)
            {
                closestPlayer = playerObject;
                closestDistance = distance;
            }
            else
            {
                if (distance < closestDistance)
                {
                    closestPlayer = playerObject;
                    closestDistance = distance;
                }
            }
        }

        return closestPlayer;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Sword"))
        {
            Destroy(gameObject);
        }
    }
}
