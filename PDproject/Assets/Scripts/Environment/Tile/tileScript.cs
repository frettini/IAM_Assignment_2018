using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileScript : MonoBehaviour {

    bool isOnTile = false;
    public bool isSphereCreated = false;
    float i = 0.0f, t = 0f;

    AudioSource toneSound;

    public float intensityFromTile = 0f;
    public float intensitySpeed = 0.5f, minimum = 0f, maximum = 10f;
    public Transform increasingSphere;


    private void Start()
    {
        toneSound = GetComponent<AudioSource>();    
    }


    private void Update()
    {

        //intensity from tile will go up or down wether player is on the tile or not
        if (isOnTile)
        {
            intensityFromTile = Mathf.Lerp(minimum, maximum, i);
            i += intensitySpeed * Time.deltaTime;
            if(intensityFromTile >= maximum)
            {
                intensityFromTile = maximum;
                CreateSphere();

            }
        }
        else if(!isOnTile && intensityFromTile != 0)
        {
            intensityFromTile = Mathf.Lerp(minimum, maximum, i);
            i += (intensitySpeed - 0.2f) * Time.deltaTime;
            if (i > 1)
            {
                intensityFromTile = 0;
            }
        }

        if (isSphereCreated)
        {
            toneSound.volume = Mathf.Lerp(1, 0, t);
            t += 0.1f * Time.deltaTime;
        }

    }

    /// We send a bang when the player steps on the button (enters the collision
    /// volume).
    void OnTriggerEnter(Collider other)
    {
        //sends a bang to inlet VolumeUp of patch
        isOnTile = true;
        maximum = 20f;
        minimum = intensityFromTile;
        i = 0f;
    }

    /// We send a different bang when the player steps off the button
    void OnTriggerExit(Collider other)
    {
        isOnTile = false;
        maximum = minimum;
        minimum = intensityFromTile;
        i = 0f;
    }

    void CreateSphere()
    {
        if (!isSphereCreated)
        {
            Instantiate(increasingSphere, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
            isSphereCreated = true;
            
        }
        
    }

}

