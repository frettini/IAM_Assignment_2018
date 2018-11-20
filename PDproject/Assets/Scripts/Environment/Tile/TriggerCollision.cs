using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollision : MonoBehaviour {

    public bool triggerPlayerPS = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            triggerPlayerPS = true;
        }
    }
}
