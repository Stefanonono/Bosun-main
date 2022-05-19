using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotGame : MonoBehaviour
{
    public ItemSlot[] slots;
    public DisableMovement disableMovement;
    public DragDrop[] items;
    public float xRange;
    public float yRange;
    Vector2 randomPosition;

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
            gameObject.transform.Find("Canvas").gameObject.SetActive(false);
            disableMovement.popUpInteract = false;
        }
    }

    private bool SlotOverlapsAny(List<float> usedX, List<float> usedY, float tryX, float tryY)
    {
        for (int i=0; i<usedX.Count; i++)
        {
            if (tryX > usedX[i] - 100 && tryX < usedX[i] + 100 && tryY > usedY[i] - 100 && tryY < usedY[i] + 100)
            {
                return true;
            } 
        }
        return false;
    }
    public void Reset()
    {
        List<float> usedX = new List<float>();
        List<float> usedY = new List<float>();
        float xPosition = 0f;
        float yPosition = 0f;
        foreach (ItemSlot slot in slots)
        {
            bool foundSpace = false;
            while (!foundSpace)
            {
                xPosition = Random.Range(0 - xRange, 0 + xRange);
                yPosition = Random.Range(0 - yRange, 0 + yRange);

                if (!SlotOverlapsAny(usedX, usedY, xPosition, yPosition))
                {
                    foundSpace = true;
                }
                
            }

            usedX.Add(xPosition);
            usedY.Add(yPosition);
            slot.gameObject.transform.localPosition = new Vector2(xPosition, yPosition);
            slot.ItemInSlot = false;
        }
        foreach (DragDrop item in items)
        {
            item.SetWorking();
            xPosition = Random.Range(0 - xRange, 0 + xRange);
            yPosition = Random.Range(0 - yRange, 0 + yRange);
            item.gameObject.transform.localPosition = new Vector2(xPosition, yPosition);
        }
    }
}