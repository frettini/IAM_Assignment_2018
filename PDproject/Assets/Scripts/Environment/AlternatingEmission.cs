using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatingEmission : MonoBehaviour {
    public float floor = 0.3f, ceiling = 1.0f;
    Material m_Material;

    private void Start()
    {
        //Fetch the Material from the Renderer
        m_Material = GetComponent<Renderer>().material;
        print("Materials " + Resources.FindObjectsOfTypeAll(typeof(Material)).Length);
    }

    // Update is called once per frame
    void Update () {
        Renderer renderer = GetComponent<Renderer>();
        Material mat = renderer.material;

        float emission = floor + Mathf.PingPong(Time.time, ceiling - floor);
        Color baseColor = Color.yellow; //Replace this with whatever you want for your base color at emission level '1'

        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

        mat.SetColor("_EmissionColor", finalColor);
    }
}
