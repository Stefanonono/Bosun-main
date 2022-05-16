using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotGame : MonoBehaviour
{
    public ItemSlot[] slots;
    public DisableMovement disableMovement;

    public bool IsCompleted() {
    bool allComplete = true;
    foreach (ItemSlot slot in slots) {
        if (slot.ItemInSlot == false) {
            allComplete = false;
            }
        }
        return allComplete;
    }

    void Start()
    {
        foreach (ItemSlot slot in slots)
        {
            slot.SetSlotGame(this);
        }
    }

    public void CheckComplete()
    {
        if (IsCompleted())
        {
            gameObject.transform.FindChild("Canvas").gameObject.SetActive(false);
            disableMovement.popUpInteract = false;
        }
    }
}