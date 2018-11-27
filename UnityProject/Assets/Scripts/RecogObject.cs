using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogObject : MonoBehaviour {

    public int arrLength = 4;

    int randomIndex;

    Color initColor;
    GameObject triggerObject;

    public GameObject ColorCube;

    GameObject[] colorCube, spawnPoint;

    [HideInInspector]
    public Color[] randColors;

    Renderer objectRend, tileRend;
    ProgressManager pm;


    

    void InstColorCube()
    {
        for (int i = 0; i < colorCube.Length; i++)
        {
            //instantiate the colorcube with a position
            colorCube[i] = Instantiate(ColorCube, spawnPoint[i].transform.position, Quaternion.identity);

            if (colorCube[i] == null)
            {
                Debug.Log("no object found");
            }

            //give random colors to each of the RGBAs
            randColors[i].r = Random.Range(0f, 1f);
            randColors[i].g = Random.Range(0f, 1f);
            randColors[i].b = Random.Range(0f, 1f);
            randColors[i].a = 1f;                                 

            //Assign those colors to each cube contained in the array
            Renderer tempRend = colorCube[i].GetComponent<Renderer>();
            tempRend.material.color = randColors[i];

        }
    }

    // Use this for initialization
    void Start() {

        colorCube = new GameObject[arrLength];
        randColors = new Color[arrLength];

        spawnPoint = GameObject.FindGameObjectsWithTag("SpawnPoint");

        //instantiate the color cube and give the random colors
        InstColorCube();

        randomIndex = (int)Random.Range(0f, 4f);
        initColor = randColors[randomIndex];

        //give the same color to the tile
        tileRend = gameObject.GetComponent<Renderer>();
        tileRend.material.color = initColor;

        //find RecogObejct 
        pm = GameObject.Find("GameManager").GetComponent<ProgressManager>();
        pm.progressCounter = 0;
    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube")
        {

            //compare color of recognition Object tile and bloc that entered the collider
            if(initColor == other.GetComponent<Renderer>().material.color) {

                pm.progressCounter++;
                randomIndex = (randomIndex +1) % (arrLength);

                initColor = randColors[randomIndex];
                tileRend.material.color = initColor;
                Destroy(other.gameObject);
            }

        }
    }
}
