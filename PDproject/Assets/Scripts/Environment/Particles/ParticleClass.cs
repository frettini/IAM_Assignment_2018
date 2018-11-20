using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleClass : MonoBehaviour {

    protected GameObject player;
    protected Vector3 desiredPosition;
    protected ParticleSystem particleEffect;

    public float radius = 5;
    protected float radiusSpeed = 3, timeLeft = 5, rotationSpeed = 80f, particleHeight = 1.5f;
    public bool  countdownOn = false, counterUp = true;
    public bool playerContact = false;



    protected virtual void Awake()
    {
        particleEffect = GameObject.Find("SmallPS").GetComponent<ParticleSystem>();
        player = GameObject.FindGameObjectWithTag("Player");
        rotationSpeed = Random.Range(60.0f, 100.0f);
    }

    protected virtual void Update()
    {
        RotateAroundPlayer(player, radius, radiusSpeed, playerContact);
        CountDown();
       
    }

   

    protected void RotateAroundPlayer(GameObject player, float radius, float radiusSpeed, bool playerContact)
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

    protected void CountDown()
    {
        //if countdown equals zero, then destroy game objct, the timeleft will also define the intensity of the particles
        if (countdownOn)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                player.GetComponent<ParticleCounter>().particleCounter--;
                Destroy(gameObject);             
            }           
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        //on trigger add a one to particle counter (should modify sound)
        OnTriggerAction(collision);
        if (collision.tag == "Player" && counterUp)
        {
            counterUp = false;
            player.GetComponent<ParticleCounter>().particleCounter++;
        }
        
    }

    protected virtual void OnTriggerAction(Collider collision)
    {
        if (collision.gameObject.layer == 8)
        {
            playerContact = true;
            countdownOn = true;
        }
    }
}
