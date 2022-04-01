using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Draggable : MonoBehaviour
{
    [SerializeField] EndTurn manager; //define lastturncards -> on moving cards

    //draggin object floatily
    private Rigidbody _rigidbody;
    private float startYpos;
    public GameObject Table;
    public DragTableProjection dragTableProjection;

    //card reference
    private CardScriptReference cardScriptReference;
    Transform cardTransform;

    //snappoints
    public GameObject[] snapPoints;
    private int closestSnap = 100;
    private float closestTemp = 1000;

    // swapping cards
    private SlotsTaken slotsTaken;
    private int movedSlot;
    public CardSwapping cardSwap;
    GameObject chosenCard;
    GameObject[] lastTurnCards;
    private Quaternion standardRot;


    private void Start()
    {
        dragTableProjection = Table.GetComponent<DragTableProjection>();
        _rigidbody = GetComponent<Rigidbody>();
        cardScriptReference = GetComponent<CardScriptReference>();
        slotsTaken = Table.GetComponent<SlotsTaken>();

        //to reset to inital rotation every mousedown
        standardRot = _rigidbody.rotation;

    }


    // the whole && cardScriptReference.slot != 6 is so that past future things don't activate
    void OnMouseDown()
    {

        if (cardScriptReference.isplayer == true && cardScriptReference.slot != 6)
        {
            movedSlot = cardScriptReference.slot;
            slotsTaken.snapPointTaken[movedSlot] = false;
        }
    }


    void OnMouseDrag()
    {
        //make moving feel/look better
        if (cardScriptReference.isplayer == true && cardScriptReference.slot != 6)
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
        if (cardScriptReference.isplayer == true && cardScriptReference.slot != 6)//just to make sure past future doesn't get interacted with

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
            //manager.cardeffects.get(); //reorganize the array
            //move other card to other slot
            moveCard(closestSnap);

            //move this card to position
            cardTransform.position = snapPoints[closestSnap].transform.position;

            //reset velocity and rotation to standard
            _rigidbody.velocity = new Vector3(0, 0, 0);
            _rigidbody.rotation = standardRot;

            //fix it's slot
            cardScriptReference.slot = closestSnap;

            doubleCheck();

            manager.cardeffects.get(); //reorganize the array


        }
    }


    private void moveCard(int slotMoving)
    {
        Debug.Log("movedcard");
        lastTurnCards = manager.lastTurnCards;
        //this changed from lasturncards.lenght to 3, do not care about the others cause they can't move
        for (int i = 0; i < 3; i++)
        {
            //see what card was in the position the new card is going to
            if (lastTurnCards[i].GetComponent<CardScriptReference>().slot == slotMoving)
            {
                chosenCard = lastTurnCards[i];
            }
        }
        cardSwap.moveCard(chosenCard);
    }



    //to fix draggable bug, and have duplicate cards just move to separate slots
    private void doubleCheck()
    {
        List<int> slotsUsed = new List<int>();
        int thisSlot;

        for (int i = 0; i < 3; i++)
        {
            thisSlot = lastTurnCards[i].GetComponent<CardScriptReference>().slot;
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
        int emptySlot;

        //fill up slotsUsed (there will be a duplicate for SURE)
        for (int i = 0; i < 3; i++)
        {
            slotsUsed.Add(lastTurnCards[i].GetComponent<CardScriptReference>().slot);
        }

        for (int i = 0; i < slotsUsed.Count; i++)
        {
            //remove the values, will end up with 1 value left in theory
            if (allSlots.Contains(slotsUsed[i]))
                allSlots.Remove(slotsUsed[i]);                
        }
        emptySlot = allSlots[0]; //the only value left in the list

        //here I run smth similar to CardSwapping
        lastTurnCards[cardWithSlotBroken].transform.position = cardSwap.snapPoints[emptySlot].transform.position;
        lastTurnCards[cardWithSlotBroken].GetComponent<CardScriptReference>().slot = emptySlot;

        Debug.Log("fixed");

        slotsUsed.Clear();
        allSlots.Clear();
    }
}
