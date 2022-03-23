using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DraggableShop : MonoBehaviour
{
    [SerializeField] Shop shop; //define lastturncards -> on moving cards

    //draggin object floatily
    private Rigidbody _rigidbody;
    private float startYpos;
    public GameObject Table;
    public DragTableProjection dragTableProjection;

    //card reference
    private ShopCardScriptReference cardScriptReference;
    Transform cardTransform;

    //snappoints
    private GameObject[] snapPoints;
    private int closestSnap = 100;
    private float closestTemp = 1000;

    // swapping cards
    private SlotsTaken slotsTaken;
    private int movedSlot;
    public CardSwapping cardSwap;
    GameObject chosenCard;
    GameObject[] buyable;
    private Quaternion standardRot;

    private void Start()
    {
        dragTableProjection = Table.GetComponent<DragTableProjection>();
        _rigidbody = GetComponent<Rigidbody>();
        cardScriptReference = GetComponent<ShopCardScriptReference>();
        slotsTaken = Table.GetComponent<SlotsTaken>();

        //to reset to inital rotation every mousedown
        standardRot = _rigidbody.rotation;

        //going to put slots on shop instead
        snapPoints = shop.pos;
    }

    void OnMouseDown()
    {
        movedSlot = cardScriptReference.slot;
        slotsTaken.snapPointTaken[movedSlot] = false;
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
        closestSnap = 100;
        closestTemp = 1000;

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

        //HERE NEED TO DO ACTUAL IF SLOT = AND GOT CASH THEN BUY THING
        if (closestSnap == 5) //if you want to buy
        {
            if (InterScene.goldPlayer > cardScriptReference.goldVal)
            {
                //do the shop stuff
            }
            else
            {
                closestSnap = cardScriptReference.slot; //move back
            }
        }
        else // if you want to shift shit around
            //move other card to other slot
            moveCard(closestSnap);

        //move this card to position
        cardTransform.position = snapPoints[closestSnap].transform.position;

        //reset velocity and rotation to standard
        _rigidbody.velocity = new Vector3(0, 0, 0);
        _rigidbody.rotation = standardRot;

        //fix it's slot
        cardScriptReference.slot = closestSnap;
    }


    private void moveCard(int slotMoving)
    {
        //buyable = shop.buyable;

        for (int i = 0; i < buyable.Length; i++)
        {

            //see what card was in the position the new card is going to
            if (buyable[i].GetComponent<CardScriptReference>().slot == slotMoving)
            {
                chosenCard = buyable[i];
            }
        }
        cardSwap.moveCard(chosenCard);
    }
}