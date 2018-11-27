using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTile : Tile {

    float randRed, randGreen, randBlue;


    GameObject smallParticle, centerGO;
    MeshRenderer spRend;
    SmallParticle sp;
    Light spotLight;
    ParticleCounter pc;
    GameObject player;

    public Animator fadeAway;

    [HideInInspector]
    public bool tileActivated;

    protected override void Awake()
    {
        base.Awake();
        randRed = Random.Range(0.4f, 1.0f);
        randGreen = Random.Range(0.4f, 1.0f);
        randBlue = Random.Range(0.4f, 1.0f);

        //give a random color to the tile and its point light
        rendMat.material.color = new Color(randRed, randGreen, randBlue);
        pointLight.color = new Color(randRed, randGreen, randBlue);
        
        //get prefab small particle, instantiate at a random place around the tile, retrieves playercontact bool and centrePS
        smallParticle = GameObject.Find("SmallParticle");
        smallParticle = Instantiate(smallParticle, new Vector3(transform.position.x + Random.Range(-10f, 10f), transform.position.y + 1, transform.position.z + +Random.Range(-10f, 10f)), Quaternion.identity);
        smallParticle.transform.parent = transform;

        


    }

    void Start()
    {
        fadeAway = GetComponent<Animator>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<ParticleCounter>();


        spRend = smallParticle.GetComponentInChildren<MeshRenderer>();
        spRend.material.color = new Color(randRed, randGreen, randBlue);
        sp = smallParticle.GetComponentInChildren<SmallParticle>();
        //give the particle the same color as the random
    }

    protected override void TriggerAction()
    {
        if(triggerPlayer && sp.playerContact)
        {
            pc.tileCounter++;
            Debug.Log("Success!");
            //fadeAway.Play("RandTileFadeOut");
            Destroy(gameObject);
        }
    }

    

}
