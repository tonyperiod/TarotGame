using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DraggableShop : MonoBehaviour
{
    [SerializeField] Shop manager; //define buyable -> on moving cards

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
    private ShopSlotsTaken slotsTaken;
    private int movedSlot;
    public ShopCardSwapping cardSwap;
    GameObject chosenCard;
    GameObject[] buyable;
    private Quaternion standardRot;

    private void Start()
    {
        dragTableProjection = Table.GetComponent<DragTableProjection>();
        _rigidbody = GetComponent<Rigidbody>();
        cardScriptReference = GetComponent<ShopCardScriptReference>();
        slotsTaken = Table.GetComponent<ShopSlotsTaken>();

        //to reset to inital rotation every mousedown
        standardRot = _rigidbody.rotation;

        //going to put slots on shop instead
        snapPoints = manager.pos;


        //DO IN ANOTHER FUNCTION FFS!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


        //////define buyable
        //GameObject[] helper = GameObject.FindGameObjectsWithTag("Card");
        //buyable = helper;
        //manager.buyableCards = buyable; //to set in the manager
        ////Debug.Log(buyable.Length + " buyable");
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
        //move card that was there
        moveCard(closestSnap);

        //move this card to position
        cardTransform.position = snapPoints[closestSnap].transform.position;

        //reset velocity and rotation to standard
        _rigidbody.velocity = new Vector3(0, 0, 0);
        _rigidbody.rotation = standardRot;

        //fix it's slot
        cardScriptReference.slot = closestSnap;

        doubleCheck();
    }


    private void moveCard(int slotMoving)
    {
        buyable = manager.buyableCards;

        for (int i = 0; i < buyable.Length; i++)
        {
            //see what card was in the position the new card is going to
            if (buyable[i].GetComponent<ShopCardScriptReference>().slot == slotMoving)
            {
                chosenCard = buyable[i];
                break;
            }
        }
        //seeing that it's null often here
        if (chosenCard != null)
            cardSwap.moveCard(chosenCard);

        //remove past chosenCard to fix rando swapping
        chosenCard = null;
    }


    private void doubleCheck()
    {
        List<int> slotsUsed = new List<int>();
        int thisSlot;

        for (int i = 0; i < 5; i++)
        {
            thisSlot = buyable[i].GetComponent<ShopCardScriptReference>().slot;
            if (slotsUsed.Contains(thisSlot))
            {
                dragBroke(i);
                break;
            }

            else
            {
                slotsUsed.Add(thisSlot);
            }
        }
        slotsUsed.Clear();
    }


    //this runs if the draggable script is broken
    private void dragBroke(int cardWithSlotBroken)
    {
        List<int> slotsUsed = new List<int>();  //this is used differently from doubleCheck;
        List<int> allSlots = new List<int>();
        allSlots.Add(0);
        allSlots.Add(1);
        allSlots.Add(2);
        allSlots.Add(3);
        allSlots.Add(4);
        allSlots.Add(5); //shop one counted in cause it won't run for that
        int emptySlot;

        //fill up slotsUsed (there will be a duplicate for SURE)
        for (int i = 0; i < 5; i++)
        {
            slotsUsed.Add(buyable[i].GetComponent<ShopCardScriptReference>().slot);
        }

        for (int i = 0; i < slotsUsed.Count; i++)
        {
            //remove the values, will end up with 1 value left in theory
            if (allSlots.Contains(slotsUsed[i]))
                allSlots.Remove(slotsUsed[i]);
        }
        emptySlot = allSlots[0]; //just top define for the next spot

        //to check that it doesn't always snap up to shop
        for (int i = 0; i < 2; i++)
        {
            if (allSlots[i] != 5)
                emptySlot = allSlots[i];
        }

        //here I run smth similar to CardSwapping
        buyable[cardWithSlotBroken].transform.position = cardSwap.snapPoints[emptySlot].transform.position;
        buyable[cardWithSlotBroken].GetComponent<ShopCardScriptReference>().slot = emptySlot;

        Debug.Log("fixed");

        slotsUsed.Clear();
        allSlots.Clear();
    }
}