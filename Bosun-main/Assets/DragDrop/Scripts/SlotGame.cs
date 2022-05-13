using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotGame : MonoBehaviour
{
    public ItemSlot[] slots;
//     public bool allComplete = true;
//     public bool IsCompleted(){
//     foreach (ItemSlot slot in slots) 
//     {
//         if (slot.ItemInSlot == false) 
//         {
//             allComplete = false;
//         }
//     }
// }
    public bool IsCompleted() {
    bool allComplete = true;
    foreach (ItemSlot slot in slots) {
        if (slot.ItemInSlot == false) {
            allComplete = false;
            }
        }
        return allComplete;
    }
}