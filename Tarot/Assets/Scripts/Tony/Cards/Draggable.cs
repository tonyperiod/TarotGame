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

            manager.cardeffects.get(); //reorganize the array


        }
    }


    private void moveCard(int slotMoving)
    {
        Debug.Log("movedcard");
        lastTurnCards = manager.lastTurnCards;

        for (int i = 0; i < lastTurnCards.Length; i++)
        {

            //see what card was in the position the new card is going to
            if (lastTurnCards[i].GetComponent<CardScriptReference>().slot == slotMoving)
            {
                chosenCard = lastTurnCards[i];
            }
        }
        cardSwap.moveCard(chosenCard);
    }
}
