using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateSoundscape : MonoBehaviour {

    float planeCoordinateX, planeCoordinateZ;

    GameObject player;
    Light direcLight;
    Transform playerLocation;
    

	// Use this for initialization
	void Start () {
        playerLocation = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        direcLight = GameObject.Find("Directional Light").GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {

        //change colour depending on location of player
        planeCoordinateX = playerLocation.position.x;
        planeCoordinateZ = playerLocation.position.z;
        direcLight.color = new Color(Mathf.Lerp(0.1f, 0.3f, planeCoordinateZ / 100), 0.0f ,Mathf.Lerp(0.1f, 0.6f, planeCoordinateZ/100));


    }
}
