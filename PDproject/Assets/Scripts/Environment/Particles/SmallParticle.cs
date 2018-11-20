using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallParticle : ParticleClass{

    [HideInInspector]
    public Light spotLight;

    protected override void Awake()
    {
        base.Awake();
        spotLight = GameObject.Find("Spot Light").GetComponent<Light>();
    }




}
