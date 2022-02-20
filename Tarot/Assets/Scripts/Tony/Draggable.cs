using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Draggable : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float startYpos;
    public GameObject Table;
    public DragTableProjection dragTableProjection;


    private void Start()
    {
        
        dragTableProjection = Table.GetComponent<DragTableProjection>();
        _rigidbody = GetComponent<Rigidbody>();

        //startYpos = 0;
    }

    public void OnBeginDrag ()
    {
        Debug.Log("begin drag");
    }

   

    void OnMouseDrag()
    {
        Debug.Log(dragTableProjection.currentMousePosition);
        Vector3 newWorldPostion = new Vector3(dragTableProjection.currentMousePosition.x, startYpos + 1, dragTableProjection.currentMousePosition.z);

        var difference= newWorldPostion - transform.position;

        _rigidbody.velocity = 10 * difference;

        //floaty effect 
        //_rigidbody.rotation = Quaternion.Euler(new Vector3(_rigidbody.velocity.z, 0, -_rigidbody.velocity.x));

        _rigidbody.rotation = Quaternion.Euler(new Vector3(-_rigidbody.velocity.z, 0, _rigidbody.velocity.x));
    }

    public void OnEndDrag()
    {
        Debug.Log("ondrag");

    }
}
