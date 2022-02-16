using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterDatabase : MonoBehaviour
{
    public void FixedUpdate()
    {
        Printing(PlayerDatabase.GetRandomCard());

    }

    private void Printing(ScriptableCard s)
    {
        Debug.Log(s.name);
    }
}
