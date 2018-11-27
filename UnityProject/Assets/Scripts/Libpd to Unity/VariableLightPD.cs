using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableLightPD : MonoBehaviour {

    LibPdInstance pdPatch;
    Light pointLight;
    StringFloatEvent f;

    //public UnityEditor.DefaultAsset pdToUnityPatch;

    float emission, value;
    string name;



    private void Awake()
    {
        pdPatch = gameObject.GetComponent<LibPdInstance>();
       // pdPatch.patch = pdToUnityPatch;
        pointLight = GetComponent<Light>();
        
       // pdPatch.pureDataEvents.Float.AddListener(FloatReceive);

        

        //f.AddListener(FloatReceive);
        //pdPatch.pureDataEvents.Float = f.Invoke(name);


    }

    private void Start()
    {
       // pdPatch.Bind("oscillatingFloat");
    }



    public void FloatReceive(string name, float value)
    {
        emission = value;
        pointLight.intensity = emission;
        Debug.Log(emission);

    }

    //public void BangReceive(string name)
    //{
    //    Debug.Log(name);
    //}



}
