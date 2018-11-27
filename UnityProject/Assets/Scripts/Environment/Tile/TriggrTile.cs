using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggrTile : Tile {

    TriggerCollision tg;
    GameObject trigPS;
    Transform[] Platforms;
    Vector3 platTrans;
    
    float distanceTilePS, temporaryYPos;
    bool platAssigned = false, playOnce = false;
    public float maxInt = 10f;

    private void Start()
    {
        trigPS = GameObject.Find("TriggerParticle");
        rendMat.material.color = Color.white;
        pointLight.color = Color.white;

        tg = GetComponentInChildren<TriggerCollision>();

    }

    //Tile lights up when colliding with the PS
    protected override void lightModifier()
    {
        if (!triggerPlayer)
        {
            if (tg.triggerPlayerPS && pointLight.intensity >= minimum)
            {
                pointLight.intensity = Mathf.PingPong(Time.time, maximum) + minimum;

            }
            else if (tg.triggerPlayerPS && pointLight.intensity <= minimum)
            {
                pointLight.intensity += 0.1f;
            }
        }
    }


    //upon trigger, make bridge appear by setting active each platform block
    protected override void TriggerAction()
    {
        if (triggerPlayer)
        {
            for (int a = 0; a < transform.childCount; a++)
            {
                if (transform.GetChild(a).gameObject.tag == "Platform")
                {
                    transform.GetChild(a).gameObject.SetActive(true);
                }
            }
            pointLight.intensity += 1f;
            
            //increase point light to max int and when reached destroy small particle
            if(pointLight.intensity >= maxInt)
            {
                pointLight.intensity = maxInt;
                Object.Destroy(trigPS);
                
            }
            PlaySoundOnTrigger();
        }
    }

    protected override void PlaySoundOnTrigger()
    {
        if (!playOnce)
        {
            audioTile.Play();
            playOnce = true;
        }
    }

}
