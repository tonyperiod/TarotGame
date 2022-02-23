using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Draggable : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float startYpos;
    public GameObject Table;
    public DragTableProjection dragTableProjection;


    private CardScriptReference cardScriptReference;
    Transform cardTransform;

    //snappoints
    public GameObject[] snapPoints;
    private float snapSensitivity = 5;

    // see if card slot taken
    private SlotsTaken slotsTaken;


    private void Start()
    {

        dragTableProjection = Table.GetComponent<DragTableProjection>();
        _rigidbody = GetComponent<Rigidbody>();

        cardScriptReference = GetComponent<CardScriptReference>();

        slotsTaken = Table.GetComponent<SlotsTaken>();


    }

    void OnMouseDown()
    {
        //set the snappoint to false

        //cardTransform = GetComponent<Transform>();
        //{

        //    for (int i = 0; i < snapPoints.Length; i++)
        //    {
        //        if (Vector3.Distance(snapPoints[i].transform.position, cardTransform.position) < snapSensitivity)
        //        {
        //            slotsTaken.snapPointTaken[i] = false;

        //        }
        //    }
        //}
        int cardNumber = cardScriptReference.slot;
        slotsTaken.snapPointTaken[cardNumber] = false;


    }
    void OnMouseDrag()
    {

        Vector3 newWorldPostion = new Vector3(dragTableProjection.currentMousePosition.x, startYpos + 1, dragTableProjection.currentMousePosition.z);

        var difference = newWorldPostion - transform.position;

        _rigidbody.velocity = 10 * difference;

        //floaty effect 
        _rigidbody.rotation = Quaternion.Euler(new Vector3(90 + _rigidbody.velocity.z, 0, 90 - _rigidbody.velocity.x));


    }

    void OnMouseUp() //snappoints
    {
        cardTransform = GetComponent<Transform>();
        int closestSnap = 100;
        float closestTemp = 1000;

        //find closest
        for (int i = 0; i < snapPoints.Length; i++)
        {

            //if (Vector3.Distance(snapPoints[i].transform.position, cardTransform.position) < snapSensitivity)
            //{
            //// move card to position
            //cardTransform.position = snapPoints[i].transform.position;

            //// set slot value
            //cardScriptReference.slot = i; //on card   
            //}

            float cardDistance;
            cardDistance = Vector3.Distance(snapPoints[i].transform.position, cardTransform.position);
            if (cardDistance < closestTemp)
            {
                closestSnap = i;
                closestTemp = cardDistance;
            }
            Debug.Log(closestSnap);
        }

        cardTransform.position = snapPoints[closestSnap].transform.position;
        cardScriptReference.slot = closestSnap;
    }


    //move card if another card placed on top 
    private void OnCollisionEnter(Collision collision)
    {
        // if this is the card getting fallen on
        if (collision.collider.tag == "Card")
        {

            for (int i = 0; i < snapPoints.Length; i++)
            {
                //compare free slot to this slot, double check that this is the card getting fallen on
                if (slotsTaken.snapPointTaken[i] == false && i != cardScriptReference.slot)
                {
                    Debug.Log("dropped");
                    //to optimize run little
                    cardTransform = GetComponent<Transform>();

                    //move to position
                    cardTransform.position = snapPoints[i].transform.position;

                    // fix parameters
                    cardScriptReference.slot = i;
                    slotsTaken.snapPointTaken[i] = true;
                }
            }

        }


    }
}

