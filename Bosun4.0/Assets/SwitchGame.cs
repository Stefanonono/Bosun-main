using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGame : MonoBehaviour
{
    public DisableMovement disableMovement;
    public Main main;

    public bool IsCompleted() {
    bool allComplete = true;
    if (main.allGreen = true) {
            allComplete = false;
            }
        return allComplete;
    }

    // void Start()
    // {
    //     foreach (ItemSlot slot in slots)
    //     {
    //         slot.SetSlotGame(this);
    //     }
    // }

    public void CheckComplete()
    {
        if (IsCompleted())
        {
            gameObject.transform.Find("SwitchBG").gameObject.SetActive(false);
            disableMovement.popUpInteract = false;
        }
    }
}