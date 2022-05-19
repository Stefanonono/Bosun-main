using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
 
public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {
 
    [SerializeField] private Canvas canvas;
    // public ItemSlot[] item;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    // public bool allItemsInSlot = false;
    // public int itemsInSlot = 0;
 
    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        // itemsInSlot = GetComponent<ItemSlot>().itemsInSlot;
    }
 
    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }
 
    public void OnDrag(PointerEventData eventData) {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
 
    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
 
    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }

    public void SetWorking()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}