using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCube : MonoBehaviour {

    Transform obstacle;

    public float minDist, maxDist, initialPosition, speed = 1;
    float distance;

    void Start()
    {
        
        distance = maxDist - minDist;
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3((Mathf.PingPong(Time.time * speed, distance) + initialPosition), transform.position.y, transform.position.z);
	}
}
