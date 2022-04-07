using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillRotator : MonoBehaviour
{
    [SerializeField] private Vector3 millRotation;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(millRotation * Time.deltaTime);
    }
}
