using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingLight : MonoBehaviour {


    GameObject player;
    Vector3 desiredPosition;

    bool playerContact = false, countdownOn = false;

    public float radius = 10.0f, radiusSpeed = 0.5f, rotationSpeed = 80.0f, timeLeft = 10.0f, timeRemaining, particleHeight = 1.5f;


    void Start()
    {
        //find player and its transform to which the particle will revolve arround
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
       //if player gets close enough, call function revolve and countdown
 
   
        RotateAroundPlayer(playerContact);
        timeRemaining = CountDown(countdownOn);
       
    }

    private void OnTriggerEnter(Collider collision)
    {
        //if collision with player, then start revolving and countdown
        if (collision.gameObject.layer == 8)
        {
            playerContact = true;
            countdownOn = true;

        }
    }

    void RotateAroundPlayer(bool playerContact)
    {
        if (playerContact)
        {
            //set position to rotate around, the desired position and position
            transform.RotateAround(player.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
            desiredPosition = (transform.position - player.transform.position).normalized * radius + player.transform.position;
            desiredPosition.y = particleHeight;
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
        }
    }

    public float CountDown(bool countdownOn)
    {
        //if countdown equals zero, then destroy game objct, the timeleft will also define the intensity of the particles
        if (countdownOn)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0)
            {
                Destroy(gameObject);
                return 0;
            }

            return timeLeft;
        }
        return timeLeft;
    }


}
