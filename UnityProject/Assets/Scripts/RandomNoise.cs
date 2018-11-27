using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class RandomNoise : MonoBehaviour {

    /*Random Noise takes in the amplitude of the random noises form the pd patch (ambiance background)
     and assign it to a special ambient light. It will radnomly be assigned a new location
     around the map and flash a light with the color of the last cube*/

    public OSCReceiver receiverRN;
    public string address;

    public float amplitudeMultiplier = 10f, yPos = 20f;
    float noiseAmplitude;
    bool hasChangePos = false;

    Transform lightTrans;
    Light randomLight;

	// Use this for initialization
	void Start () {

        lightTrans = GetComponent<Transform>();
        receiverRN.Bind(address, PrintOSC);
        randomLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        //always decrease the intensity and range of light when at rest
        randomLight.range -= 0.1f;
        randomLight.intensity -= 0.1f;
        if(randomLight.range <= 0)
        {
            //randomly change position of light when range hits 0
            if (!hasChangePos)
            {
                hasChangePos = true;
                lightTrans.position = new Vector3(Random.Range(-64f, 64f), yPos, Random.Range(-64f, 64f));
            }

            
            randomLight.range = 0f;
            randomLight.intensity = 0f;
        }
    }

    public void PrintOSC(OSCMessage receiver)
    {
        //receive OSC message from pd patch and assign it to both range and intensity
        float value;
        if (receiver.ToFloat(out value))
        {
            noiseAmplitude = value * amplitudeMultiplier;

            randomLight.range = noiseAmplitude;
            randomLight.intensity = noiseAmplitude;
            hasChangePos = false;
        }
    }
}
