using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
 
public class ItemSlot : MonoBehaviour, IDropHandler {
    public bool ItemInSlot = false;
    private SlotGame slotGame;
 
    public void OnDrop(PointerEventData eventData) {
    Debug.Log("OnDrop");
    if (eventData.pointerDrag != null) {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            transform.position = Input.mousePosition;
            ItemInSlot = true;
            slotGame.CheckComplete();
        }
    }

    public void SetSlotGame(SlotGame game)
    {
        slotGame = game;
    }
}