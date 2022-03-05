using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnClick : MonoBehaviour
{
    [SerializeField] EndTurn manager;

    private void OnMouseDown()
    {
        manager.OnClick();
    }
}
