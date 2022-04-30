using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//tutorial script
//interfaces with draggable to allow the cards to move more naturally
public class DragTableProjection : MonoBehaviour
{
    public Vector3 currentMousePosition;
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

   
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);

        foreach (var hit in hits)
        {
            if (hit.collider.gameObject.layer != LayerMask.NameToLayer("Table")) continue;
            currentMousePosition = hit.point;
            break;
        }
    }
}
