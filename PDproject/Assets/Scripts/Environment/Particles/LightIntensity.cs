using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour {

    GameObject lightEmitter;
    ParticleSystem particleLight;
    FollowingLight followingLight;
    public Light lightPrefab;

    float timeLeft;


	// Use this for initialization
	void Start () {
        lightEmitter = GameObject.Find("Center");
        particleLight = lightEmitter.GetComponent<ParticleSystem>();
        followingLight = GetComponent<FollowingLight>();
        timeLeft = followingLight.timeRemaining;

        var lights = particleLight.lights;
        lights.light = lightPrefab;
    }
	
	// Update is called once per frame
	void Update () {

        timeLeft = followingLight.timeRemaining;
        lightPrefab.intensity = timeLeft;
        lightPrefab.range = timeLeft;
        var lights = particleLight.lights;
        lights.light = lightPrefab;


    }
}
