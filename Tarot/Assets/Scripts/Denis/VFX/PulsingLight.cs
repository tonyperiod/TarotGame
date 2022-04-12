using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]


public class PulsingLight : MonoBehaviour
{
    public float duration;
    public Light lt;
    public float amplitude;
    public bool isBuffed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBuffed)
        {
            Pulse();
        }
        else if (!isBuffed)
        {
            StopPulse();
        }
    }

    public void Pulse()
    {
        
        float phi = (Time.time / duration) * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 0.5f + 1f;
        lt.intensity = amplitude * 5;
    }

    public void StopPulse()
    {
        lt.intensity = 0;
    }


}
