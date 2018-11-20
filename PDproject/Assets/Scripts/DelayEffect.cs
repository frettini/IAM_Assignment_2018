using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using extOSC;

public class DelayEffect : MonoBehaviour {

    public Material materialDrunk;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
            Graphics.Blit(source, destination, materialDrunk);
        
    }

}
