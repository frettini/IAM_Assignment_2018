using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour {

    public float shootTime = 5f;

    float counter = 0f;
    GameObject player, projectile;

    public GameObject projectilePrefab;

    void InstantiateProjectile()
    {
        counter = 0f;
        projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            InstantiateProjectile();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        { 
            counter += Time.deltaTime;

            if (counter >= shootTime)
            {
                InstantiateProjectile();

            }
        }
    }
}
