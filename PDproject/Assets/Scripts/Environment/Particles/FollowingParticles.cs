using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingParticles : MonoBehaviour{

    GameObject player;
    Vector3 desiredPosition;
    
    float particleHeight = 1.5f;
    float rotationSpeed = 80f;


    public void RotateAroundPlayer(GameObject player, float radius, float radiusSpeed, bool playerContact)
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

    public float CountDown(float timeLeft, bool countdownOn)
    {
        //if countdown equals zero, then destroy game objct, the timeleft will also define the intensity of the particles
        if (countdownOn)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Destroy(gameObject);
                return 0;
            }

            return timeLeft;
        }
        return timeLeft;
    }



}
