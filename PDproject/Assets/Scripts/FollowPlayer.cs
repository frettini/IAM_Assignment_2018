using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour{
 
    //assign player, speed and distances
    GameObject player;
    Transform playerTransf;

    public int moveSpeed = 4;
    public int maxDist = 10;
    public int minDist = 5;

    NavMeshAgent agent;




    void Start()
    {
        //Initialize player
        player = GameObject.Find("Player");
        playerTransf = player.GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 2f;
    }

    void Update()
    {   
        //every Update, look in the direction of the player
        transform.LookAt(playerTransf);

        //check distances and update position of the ennemy
        if (Vector3.Distance(transform.position, playerTransf.position) >= minDist)
        {

            //transform.position += transform.forward * moveSpeed * Time.deltaTime;

            agent.SetDestination(player.transform.position);


            //if ennemy at minDist, endGame
            if (Vector3.Distance(transform.position, playerTransf.position) <= minDist)
            {
                Debug.Log("u dead");

            }

        }
        
    }
}