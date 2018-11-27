using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTile : MonoBehaviour {

    Light pointLight;
    Transform tileRenderer;
    AudioSource synthTile;

    bool triggerPlayer = false;
    float maximum = 2f, minimum = 1.3f;
    float i;

	// Use this for initialization
	void Awake () {
        pointLight = GetComponentInChildren<Light>();
        synthTile = GetComponentInChildren<AudioSource>();
        //gameObject.transform.GetChild(0).gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        lightModifier();
	}

    private void OnTriggerEnter(Collider other)
    {

        /*if (other.tag == "Sphere")
        {

            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("Sphere collided");
        
        }*/

        if (other.tag == "Player")
        {
            triggerPlayer = true;
            synthTile.pitch = Random.Range(0.6f, 1.2f);
            synthTile.Play();

           
        }
    }

    void lightModifier()
    {
        if (triggerPlayer && pointLight.intensity >= minimum)
        {
            pointLight.intensity = Mathf.PingPong(Time.time, maximum) + minimum;

        }else if(triggerPlayer && pointLight.intensity <= minimum)
        {
            pointLight.intensity += 0.1f;
        }
    }
}
