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
    

    private int closestSnap = 100;
    private float closestTemp = 1000;

    // see if card slot taken
    private SlotsTaken slotsTaken;

    private bool isFalling;

    private void Start()
    {

        dragTableProjection = Table.GetComponent<DragTableProjection>();
        _rigidbody = GetComponent<Rigidbody>();

        cardScriptReference = GetComponent<CardScriptReference>();

        slotsTaken = Table.GetComponent<SlotsTaken>();


    }

    void OnMouseDown()
    {
        if (cardScriptReference.isplayer == true)
        {
            int cardNumber = cardScriptReference.slot;
            slotsTaken.snapPointTaken[cardNumber] = false;
        }


    }
    void OnMouseDrag()
    {
        if (cardScriptReference.isplayer == true)
        {
            Vector3 newWorldPostion = new Vector3(dragTableProjection.currentMousePosition.x, startYpos + 1, dragTableProjection.currentMousePosition.z);

            var difference = newWorldPostion - transform.position;

            _rigidbody.velocity = 10 * difference;

            //floaty effect 
            _rigidbody.rotation = Quaternion.Euler(new Vector3(90 + _rigidbody.velocity.z, 0, 90 - _rigidbody.velocity.x));
        }
        
    }

    void OnMouseUp() //snappoints
    {
        if (cardScriptReference.isplayer == true)
        {
            cardTransform = GetComponent<Transform>();


            //find closest
            for (int i = 0; i < snapPoints.Length; i++)
            {
                float cardDistance;
                cardDistance = Vector3.Distance(snapPoints[i].transform.position, cardTransform.position);
                if (cardDistance < closestTemp)
                {
                    closestSnap = i;
                    closestTemp = cardDistance;
                }
               
            }

            cardTransform.position = snapPoints[closestSnap].transform.position;
            //cardScriptReference.slot = closestSnap;
            isFalling = true;
        }
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
                    
                    //to optimize run little
                    cardTransform = GetComponent<Transform>();

                    //move to position
                    cardTransform.position = snapPoints[i].transform.position;

                    // fix parameters
                    cardScriptReference.slot = i;
                    slotsTaken.snapPointTaken[i] = true;

                }
                else
                    if (isFalling == true)
                {
                    cardScriptReference.slot = closestSnap;
                    isFalling = false;
                }

            }

        }


    }
}

