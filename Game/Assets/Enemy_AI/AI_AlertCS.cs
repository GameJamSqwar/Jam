﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_AlertCS : MonoBehaviour
{

    public GameObject NPC_Enemy;

    private float reset = 5;

    private bool movingDown;



    // Start is called before the first frame update
    /*
    void Start()
    {
    }
    */
    

    // Update is called once per frame
    void Update()
    {
        if (movingDown == false)
            transform.position -= new Vector3(0, 0, 0.1f);
        else
            transform.position += new Vector3(0, 0, 0.1f);
        if (transform.position.z > 10)
            movingDown = false;
        else if (transform.position.z < -10)
            movingDown = true;
        reset -= Time.deltaTime;
        if (reset < 0)
        {
            NPC_Enemy.GetComponent<AI_EnemyCS>().enabled = false;
            GetComponent<SphereCollider>().enabled = true;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            NPC_Enemy.GetComponent<AI_EnemyCS>().enabled = true;
            reset = 5;
            GetComponent<SphereCollider>().enabled = false; 
        }
    }
}
