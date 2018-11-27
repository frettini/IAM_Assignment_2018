using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    protected Light pointLight;
    protected Renderer rendMat;
    private Transform tileRenderer;
    protected AudioSource audioTile;

    protected bool triggerPlayer = false;
    protected float maximum = 2f, minimum = 1.3f;


    // Use this for initialization
    protected virtual void Awake () {
        pointLight = GetComponentInChildren<Light>();
        rendMat = GetComponentInChildren<Renderer>();
        audioTile = GetComponentInChildren<AudioSource>();

    }

    // Update is called once per frame
    void Update () {
        pointLight = GetComponentInChildren<Light>();
        lightModifier();
        TriggerAction();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerPlayer = true;
            OnTrigger(other);
        }
    }


    //oscillates the light intensity when it is touched
    protected virtual void lightModifier()
    {
        if (triggerPlayer && pointLight.intensity >= minimum)
        {
            pointLight.intensity = Mathf.PingPong(Time.time, maximum) + minimum;

        }
        else if (triggerPlayer && pointLight.intensity <= minimum)
        {
            pointLight.intensity += 0.1f;
        }
    }

    protected virtual void TriggerAction()
    {

    }

    protected virtual void OnTrigger(Collider other)
    {

    }

    protected virtual void PlaySoundOnTrigger()
    {

    }
}

