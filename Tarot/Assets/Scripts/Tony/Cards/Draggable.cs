using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Draggable : MonoBehaviour
{
    [SerializeField] EndTurn manager; //define lastturncards -> on moving cards

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
    public bool isFalling;

    // move cards
    private int movedSlot;
    public CardSwapping cardSwap;
    GameObject chosenCard;
    GameObject[] lastTurnCards;

    private void Start()
    {

        dragTableProjection = Table.GetComponent<DragTableProjection>();
        _rigidbody = GetComponent<Rigidbody>();
        cardScriptReference = GetComponent<CardScriptReference>();
        slotsTaken = Table.GetComponent<SlotsTaken>();


    }
    // the whole && cardScriptReference.slot != 6 is so that past future things don't activate
    void OnMouseDown()
    {

        if (cardScriptReference.isplayer == true && cardScriptReference.slot != 6)
        {
            movedSlot = cardScriptReference.slot;
            slotsTaken.snapPointTaken[movedSlot] = false;
        }
        isFalling = true;
    }
    void OnMouseDrag()
    {//make moving feel/look better
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
        if (cardScriptReference.isplayer == true && cardScriptReference.slot != 6)
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

            moveCard(closestSnap);

            cardTransform.position = snapPoints[closestSnap].transform.position;
            _rigidbody.velocity = new Vector3 (0,0,0);
            cardScriptReference.slot = closestSnap;

        }
    }


    private void moveCard(int slotMoving)
    {
       lastTurnCards = manager.lastTurnCards;


        for (int i = 0; i < lastTurnCards.Length; i++)
        {
            if (lastTurnCards[i].GetComponent<CardScriptReference>().slot == slotMoving)
            {
                chosenCard = lastTurnCards[i];                
            }
        }

        cardSwap.moveCard(chosenCard);
    }

    //public void thisCardMoves(GameObject)
    //{
    //    Debug.Log(this.GetComponent<CardScriptReference>().Cardname);
        //this.transform.position = snapPoints[movedSlot].transform.position;
        //this.GetComponent<CardScriptReference>().slot = movedSlot;
    //}
    ////move card if another card placed on top 
    //private void OnCollisionEnter(Collision collision)
    //{

    //    // if this is the card getting fallen on
    //    if (collision.collider.tag == "Card" && isFalling == false)
    //    {
    //        int otherID = collision.gameObject.GetComponent<CardScriptReference>().id;
    //        for (int i = 0; i < snapPoints.Length; i++)
    //        {
    //            //compare free slot to this slot, double check that this is the card getting fallen on
    //            if (slotsTaken.snapPointTaken[i] == false /*&& i != cardScriptReference.slot*/)
    //            {

    //                //to optimize run little
    //                cardTransform = GetComponent<Transform>();

    //                //move to position
    //                cardTransform.position = snapPoints[i].transform.position;

    //                // fix parameters
    //                cardScriptReference.slot = i;
    //                slotsTaken.snapPointTaken[i] = true;

    //            }
    //        }
    //    }

    //    if (collision.collider.tag == "Card" && isFalling == true)
    //    {
    //        //cardTransform.position = snapPoints[closestSnap].transform.position;
    //        //cardScriptReference.slot = closestSnap;
    //        isFalling = false;
    //    }
    //}

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.collider.tag == "Card")
    //    {
    //        int otherID = collision.collider.GetComponent<CardScriptReference>().id;


    //        if (isFalling == false && otherID < cardScriptReference.id)
    //        {
    //            cardTransform = GetComponent<Transform>();
    //            for (int i = 0; i < 4; i++)
    //            {
    //                if (slotsTaken.snapPointTaken[i] == false)
    //                {
    //                    cardTransform.position = snapPoints[i].transform.position;
    //                    cardScriptReference.slot = i;
    //                }
    //            }
    //        }
    //    }
    //}

    void SelectionSort(GameObject[] unsortedList)
    {
        int min;
        GameObject temp; //temporary swapping place

        for (int i = 0; i < unsortedList.Length; i++)
        {
            min = i;

            for (int j = i + 1; j < unsortedList.Length; j++)
            {
                if (unsortedList[j].gameObject.GetComponent<CardScriptReference>().slot < unsortedList[min].gameObject.GetComponent<CardScriptReference>().slot)
                {
                    min = j;
                }
            }
            if (min != i)
            {
                temp = unsortedList[i];
                unsortedList[i] = unsortedList[min];
                unsortedList[min] = temp;
            }
        }
    }
}
