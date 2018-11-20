using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour {


    float throwForce = 600;


    public bool canHold = true;

    GameObject player;
    AmbientLights al;
    Transform guide;
    Color objColor;

    public bool isHolding = false;
    float distance;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        al = GameObject.Find("GameManager").GetComponent<AmbientLights>();
        objColor = GetComponent<Renderer>().material.color;


        guide = player.transform.Find("Main Camera").Find("guide");

    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(transform.position, guide.transform.position);

        if (isHolding == true)
        {

            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().detectCollisions = true;
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = guide;
            transform.position = guide.transform.position;
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Trying to throw");
                GetComponent<Rigidbody>().AddForce(guide.transform.forward * throwForce);
                isHolding = false;
            }
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = null;
        }
    }

    void OnMouseDown()

    {
        if (!isHolding)
        {
            if (distance <= 1.5f)
            {
                isHolding = true;
                //guide.transform.position = item.transform.position;
                al.pickedUpColor = objColor;
               
                al.isHolding = true;
            }
        }
        else
        {
            isHolding = false;
            al.isHolding = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isHolding = false;
        al.isHolding = false;
    }

    

}