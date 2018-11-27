using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFollowPlayer : MonoBehaviour {

    GameObject player;
    float timeElapsed;

    public float moveSpeed = 5f;



	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");

        transform.LookAt(player.transform);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, 1f, transform.position.z);

        timeElapsed += Time.deltaTime;
        
        if(timeElapsed >= 50f)
        {
            Destroy(gameObject);
        }
    }
}
