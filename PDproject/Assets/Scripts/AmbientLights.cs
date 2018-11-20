using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class AmbientLights : MonoBehaviour {

    public Color pickedUpColor;
    public bool isHolding = false;
    bool localCheck;

    [HideInInspector]
    public float red = 0f, green =0f, blue =0f;

    public OSCReceiver ReceiverBeating;
    public string addressBeating;
    float beatingValue;

    GameObject[] ambientObj;
    Light[] ambientLight;
    GameObject[] beatingObj;
    Light[] beatingLight;


    // Use this for initialization
    void Start () {
        pickedUpColor = new Color(1f, 1f, 1f);

        ambientObj = GameObject.FindGameObjectsWithTag("AmbientLights");
        ambientLight = new Light[ambientObj.Length];

        beatingObj = GameObject.FindGameObjectsWithTag("BeatingLights");
        beatingLight = new Light[beatingObj.Length];

        for (int i = 0; i < ambientObj.Length; i++)
        {
            
            ambientLight[i] = ambientObj[i].GetComponent<Light>();
        }

        for (int i = 0; i < beatingObj.Length; i++)
        {

            beatingLight[i] = beatingObj[i].GetComponent<Light>();
        }

        ReceiverBeating.Bind(addressBeating, PrintOSC);

        localCheck = isHolding;
	}
	
	// Update is called once per frame
	void Update () {

        if (localCheck != isHolding)
        {
            ChangeColors();
            localCheck = isHolding;
        }

        red = pickedUpColor.r;
        green = pickedUpColor.g;
        blue = pickedUpColor.b;
    }

    void ChangeColors()
    {
        foreach(Light light in ambientLight)
        {

            light.color = pickedUpColor;
            Debug.Log(pickedUpColor);
           

        }
        
        
    }

    public void PrintOSC(OSCMessage receiver)
    {
        float value;
        if (receiver.ToFloat(out value))
        {
            beatingValue = 500*value;

            foreach(Light light in beatingLight)
            {
                light.intensity = beatingValue;
                light.range = beatingValue+20;
            }
        }
    }
}

