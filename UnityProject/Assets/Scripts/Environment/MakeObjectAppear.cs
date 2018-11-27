using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeObjectAppear : MonoBehaviour {

	// Use this for initialization

    
	void Start () {
        for (int a = 0; a < transform.childCount; a++)
        {
            transform.GetChild(a).gameObject.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SphereBeg")
        {

            for (int a = 0; a < transform.childCount; a++)
            {
                if (transform.GetChild(a).gameObject.tag != "Platform")
                {
                    transform.GetChild(a).gameObject.SetActive(true);
                }
            }

        }
    }
}
