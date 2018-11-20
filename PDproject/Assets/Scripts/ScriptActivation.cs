using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class ScriptActivation : MonoBehaviour {

    public OSCReceiver receiver;
    public string address;
     DelayEffect de;

    public float delayVolume;

	// Use this for initialization
	void Start () {
        receiver.Bind(address, PrintOSC);
        de = GetComponent<DelayEffect>();
        de.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(delayVolume);
        if(delayVolume > 0.5f)
        {
            de.enabled = true;
        }
	}

    public void PrintOSC(OSCMessage valueReceived)
    {
        float value;
        if (valueReceived.ToFloat(out value))
        {
            delayVolume = value;

            Debug.Log(delayVolume);
        }
    }
}
