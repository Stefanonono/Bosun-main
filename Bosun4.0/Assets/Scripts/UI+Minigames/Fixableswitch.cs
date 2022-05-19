using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Fixableswitch : Interactable
{
    public Sprite open;
    public Sprite closed;

    private SpriteRenderer sr;
    private bool isOpen;
    public Move2D inRange;

    public override void Interact()
    {
        if (inRange.canInteract2 == true)
        // if (inRange.minigame1 == true)
        
        if(isOpen)
            sr.sprite = closed;
        else
            sr.sprite = open;

        isOpen = !isOpen; 
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closed;
    }
}