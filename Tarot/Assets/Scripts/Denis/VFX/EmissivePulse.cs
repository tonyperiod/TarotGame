using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissivePulse : MonoBehaviour
{
    [SerializeField] private Material emissiveMaterial;
    [SerializeField] private Renderer objectToChange;
    private Color color;
    public float duration;
    private void Start()
    {
        emissiveMaterial = objectToChange.GetComponent<Renderer>().material;
        color = emissiveMaterial.GetColor("_EmissionColor");
    }

  public void EmissionIntensity(float value)
    {
        emissiveMaterial.SetColor("_EmissionColor", color * value);
    }

    private void Update()
    {
        float phi = (Time.time / duration) * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 0.5f + 5f;
        emissiveMaterial.SetColor("_EmissionColor", color * amplitude * 10);
    }

   
}
