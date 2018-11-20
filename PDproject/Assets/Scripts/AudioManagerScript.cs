using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using extOSC;
using UnityEngine.SceneManagement;

public class AudioManagerScript : MonoBehaviour {

    GameObject player, ennemy;
    public OSCReceiver Receiver;
    public float playerToEnnemy, loseDistance = 1f;

    public float OSCTest;
    public string address;

    public float mixerVolume =0f;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        ennemy = GameObject.Find("Ennemy");

        Receiver.Bind(address, PrintOSC);
        StartGame();
    }
	
	// Update is called once per frame
	void Update () {
        playerToEnnemy = Vector3.Distance(player.transform.position, ennemy.transform.position);
        if(playerToEnnemy <= loseDistance)
        {
            mixerVolume = 0f;
            Debug.Log("you lost");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
   
	}

    public void PrintOSC(OSCMessage receiver)
    {
        Debug.Log(receiver);
        int value;
        if (receiver.ToInt(out value))
        {
            var intvalue = (int)value;
            OSCTest = intvalue;

            Debug.Log(OSCTest);
        }
    }

    public void StartGame()
    {
        mixerVolume = 0.9f;
    }
}
