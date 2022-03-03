using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnClick : MonoBehaviour
{
    //refer to parent manager script
    [SerializeField] EndTurnManager manager;

    private void OnMouseDown()
    {
        manager.turnClick();   
    }

}
