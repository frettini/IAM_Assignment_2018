using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasingSphere : MonoBehaviour {

    //LibPdInstance pdPatch;
   // public UnityEditor.DefaultAsset tileSamplePatch;

    SphereCollider spCollider;
    Vector3 newScale;
    Rigidbody rb;

    bool isSphereDestroyed = false;

    public float velocity = 1.1f;

    

    // Use this for initialization
    void Start () {
        newScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        //pdPatch.Bind("thresholdBang");
    }
	
	// Update is called once per frame
	void Update () {

        newScale = newScale * velocity;
        transform.localScale = newScale;
        DestroySphere();

	}


    void DestroySphere()
    {
        if(newScale.x > 10000 && !isSphereDestroyed)
        {
            Destroy(gameObject);
            isSphereDestroyed = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Environment")
        {
            rb = other.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }
}
