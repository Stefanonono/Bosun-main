using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMovement : MonoBehaviour
{
    public bool popUpInteract = false;
    public void TogglepopUpInteract()
    {
    popUpInteract = !popUpInteract;
    }
    void Update()
    {
        if (popUpInteract)
        {
            GetComponent<Move2D>().enabled = false;
            return;
        }
        else
            GetComponent<Move2D>().enabled = true;
    }   
}