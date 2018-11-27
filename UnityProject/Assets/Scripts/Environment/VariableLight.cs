using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableLight : MonoBehaviour {

    public LibPdInstance pdPatch;

    Light pointLight;
    float emission, period;
    float counter = 0.1f; 
    //float proximityToObj;

    //set max and min light intensity and speed of increament and decrement
    public float increment = 0.1f;
    public float floor = 1f, ceiling = 3f, radius = 7.5f;

    public Transform objTransform;



    // Use this for initialization
    void Start () {

        pointLight = GetComponent<Light>();
        period = (ceiling - floor) * 2;

    }
	
	// Update is called once per frame
	void Update () {

        //Define distance to Obj, scale it to between 1 and 0 and invert it
        /*proximityToObj = Vector3.Distance(objTransform.position, Camera.main.transform.position);
        proximityToObj /= radius;
        proximityToObj = 1.0f - proximityToObj;
        if (proximityToObj < 0.0f)
            proximityToObj = 0.0f;*/

        counter = (counter + increment) % period;

        //make emission oscillate between the ceiling and floor value
        emission = floor + Mathf.PingPong(counter, ceiling - floor);
        pointLight.intensity = emission;

        

        //pass value of emission to the pd patch
        pdPatch.SendFloat("emission", emission);

        //proximity code is replaced by spatialization, the patch is defaulted to 1
        //pdPatch.SendFloat("proximityToObj", proximityToObj);
    }
}
