using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour {

    public int progressCounter;
    int progressLocalCheck;

    [HideInInspector]
    public float red, green, blue;
    

    public GameObject rotateArroundMap;
    public GameObject cube, beginningSphere, endCollider;
    public Light endlight;
    GameObject rotateAround, sphere;
    GameObject[] environment;
    Rigidbody rb;

    Animation anim;
    Animator animator;
    AmbientLights al;
    PickUpObject po;


	// Use this for initialization
	void Start () {
        al = GetComponent<AmbientLights>();
        po = cube.GetComponent<PickUpObject>();

        environment = GameObject.FindGameObjectsWithTag("Environment");
        foreach(GameObject obj in environment)
        {
            rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = false;
                rb.isKinematic = true;
            }
        }

        

    }
	
	// Update is called once per frame
	void Update () {


        if (progressLocalCheck != progressCounter)
        {
            progressLocalCheck = progressCounter;

            rotateAround = Instantiate(rotateArroundMap, new Vector3(78f, 22f, -77.5f), Quaternion.identity);
            animator = rotateAround.GetComponent<Animator>();
            animator.speed = Random.Range(1.0f, 10.0f);

            Debug.Log(progressCounter);

            if(progressCounter == 4)
            {
                Debug.Log("hello");
                sphere = Instantiate(beginningSphere, new Vector3(0f, 0f, 0f), Quaternion.identity);
                endlight.intensity = 30f;
                endlight.range = 40f;
                endCollider.GetComponent<Transform>().position = new Vector3(0f, -30f, 0f);
            }

            
        }

       

    }

 
}
