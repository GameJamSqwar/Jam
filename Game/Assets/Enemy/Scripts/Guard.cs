using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Guard : MonoBehaviour
{
    Transform player = null;
    public int MoveSpeed;
    public int MaxDist;
    public int MinDist;
    private GameObject targetPlayer;

    private NavMeshAgent navmesh;

    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();

        //Select player to target.
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        //quicksort the list by 
        int playerQuantity = players.Length;
        if (playerQuantity > 2)
        {
            //More than two players
            //quicksort the list of players by their number of enemies tracking them.
            //Then set the AI to target the player with the least AI tracking.
            //If there are multiple players who are tied for lowest, go for the closest player in that list. 
            //Try to path to chosen player. If you cannot path to chosen player either go for a random player or choose next player with least tracking.
        }
        else if (playerQuantity == 2)
        {
            //Two players
            //NOTE: Attempt at getting each players current number of targeted people. 
            //These should be compared and the player with less enemies tracking should be targeted. 
            Component player1 = players[0].GetComponent("Player");
            Component player2 = players[1].GetComponent("Player");
        }
        else
        {
            //Only one player

        }
    }

    void Update()
    {
        GameObject closestPlayer = FindClosestPlayer();

        player = closestPlayer.transform;

        if (Vector3.Distance(transform.position, player.position) >= MinDist)
        {
            if (Vector3.Distance(transform.position, player.position) >= MaxDist)
            {
                //Find closest spawner and set it as destination if nearest player outside of max distance
                GameObject closestSpawn = null;
                float closestSpawnDistance = 0;
                foreach (var spawnObject in GameObject.FindGameObjectsWithTag("Spawner"))
                {
                    float spawnDistance = Vector3.Distance(transform.position, spawnObject.transform.position);
                    if (closestSpawn == null)
                    {
                        closestSpawn = spawnObject;
                        closestSpawnDistance = spawnDistance;
                    }
                    else
                    {
                        if (spawnDistance < closestSpawnDistance)
                        {
                            closestSpawn = spawnObject;
                            closestSpawnDistance = spawnDistance;
                        }
                    }
                }
            }
            else //If position is greater than minimum distance but less than max distance
            {
                navmesh.SetDestination(closestPlayer.transform.position);
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
        /*
        if (collision.collider.CompareTag("Player"))
        {
            GameObject playerCollided = collision.collider.gameObject;
            //using the game object do damage to that player.
        }
        */
    }
}
