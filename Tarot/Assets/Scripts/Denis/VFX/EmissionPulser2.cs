using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionPulser2 : MonoBehaviour
{
    public float duration;
    Material myMat;
    Color color;
    //public float intensity;
    // Start is called before the first frame update
    void Start()
    {
        myMat = GetComponent<Renderer>().material;
        color = myMat.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        
        float phi = Time.time / duration * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 0f + 0.5f;
        float R = amplitude;
        float G = amplitude;
        float B = amplitude;

        myMat.EnableKeyword("_EMISSION");
        myMat.SetColor("_EmissionColor", new Color(R, G, B));
       
    }
}
