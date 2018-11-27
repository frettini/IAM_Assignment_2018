using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;


public class SendColor : MonoBehaviour {

    public OSCTransmitter Transmitter;
    public AmbientLights al;

    float red, green, blue;

    private const string redAddress = "/unity/pickup/red";
    private const string greenAddress = "/unity/pickup/green";
    private const string blueAddress = "/unity/pickup/blue";

    private void Start()
    {
        red = al.red;
        green = al.green;
        blue = al.blue;
    }

    public void SendRed(float value)
    {
        value = red;
        Transmitter.Send(redAddress, OSCValue.Float(value));
        Debug.Log("redredred");

    }

    public void SendGreen(float value)
    {
        value = green;
        Transmitter.Send(greenAddress, OSCValue.Float(value));

    }

    public void SendBlue(float value)
    {
        value = blue;
        Transmitter.Send(blueAddress, OSCValue.Float(value));

    }

}
