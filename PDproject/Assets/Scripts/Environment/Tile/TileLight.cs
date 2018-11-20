using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLight : MonoBehaviour {

    GameObject squareParticle;
    ParticleSystem particleLight;
    tileScript ts;

    public LibPdInstance pdPatch;
    StringEvent r;
    //public UnityEditor.DefaultAsset pdToUnityPatch;

    public Light lightPrefab;

    float intensityFromTile;

    private void Awake()
    {
        //pdPatch = gameObject.GetComponent<LibPdInstance>();
        //pdPatch.patch = pdToUnityPatch;

        //pdPatch.pureDataEvents.Bang.AddListener(BangReceive);

        //pdPatch.Bind("lampBang");

        


    }

    // Use this for initialization
    void Start () {
        squareParticle = GameObject.Find("SquareParticle");
        particleLight = squareParticle.GetComponent<ParticleSystem>();
        ts = GetComponent<tileScript>();
        intensityFromTile = ts.intensityFromTile;

        var lights = particleLight.lights;
        lights.light = lightPrefab;

    }
	
	// Update is called once per frame
	void Update () {

        if (!ts.isSphereCreated)
        {
            intensityFromTile = ts.intensityFromTile;
            lightPrefab.intensity = 1f + intensityFromTile * 0.5f;
            lightPrefab.range = 3 + (intensityFromTile - 1f) * 0.5f;
            var lights = particleLight.lights;
            lights.light = lightPrefab;
        }
        else
        {
            intensityFromTile = ts.intensityFromTile;
            lightPrefab.intensity -= 0.05f;
            lightPrefab.range -= 0.05f;
            if(lightPrefab.intensity < 0f)
            {
                lightPrefab.intensity = 0.05f;
                lightPrefab.range = 0.05f;
            }
            var lights = particleLight.lights;
            lights.light = lightPrefab;
            
        }

     pdPatch.SendFloat("f", intensityFromTile);
        

       

    }

    void BangReceive(string name)
    {
        Debug.Log(name);
    }
}
