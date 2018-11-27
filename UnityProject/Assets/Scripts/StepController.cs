using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepController : MonoBehaviour {

    Transform[] Steps;

    // Use this for initialization
    void Start () {
        for (int a = 0; a < transform.childCount; a++)
        {
            if (transform.GetChild(a).gameObject.tag == "Steps")
            {
                Steps[a] = transform.GetChild(a);
            }
        }
        foreach (Transform step in Steps)
        {
            Debug.Log(step.name);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
