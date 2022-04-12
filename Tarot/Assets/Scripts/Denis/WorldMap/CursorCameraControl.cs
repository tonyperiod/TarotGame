using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCameraControl : MonoBehaviour
{
    public float SensitivityRot;
    public float SensitivityPos;

    public float lookDownMin = 10;
    public float lookUpMax = 10;
    public float lookRightMax = 10;
    public float lookLeftMin = 10;

    public float moveUpMax = 80;
    public float moveDownMin = 20;
    public float moveRightMax = 20;
    public float moveLeftMin = -20;
    private Quaternion camRotation;
    private Vector3 camPosition;
    // Start is called before the first frame update
    void Start()
    {
        camRotation = transform.localRotation;
        camPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        camRotation.x += Input.GetAxis("Mouse Y") * (-SensitivityRot);
        camRotation.y += Input.GetAxis("Mouse X") * SensitivityRot;

        camRotation.x = Mathf.Clamp(camRotation.x, lookDownMin, lookUpMax);
        camRotation.y = Mathf.Clamp(camRotation.y, lookLeftMin, lookRightMax);


        camPosition.x += Input.GetAxis("Mouse X") * SensitivityPos;
        camPosition.y += Input.GetAxis("Mouse Y") * SensitivityPos;

        camPosition.x = Mathf.Clamp(camPosition.x, moveLeftMin, moveRightMax);
        camPosition.y = Mathf.Clamp(camPosition.y, moveDownMin, moveUpMax);


        transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);
        transform.localPosition = new Vector3(camPosition.x, camPosition.y, camPosition.z);
    }
}
