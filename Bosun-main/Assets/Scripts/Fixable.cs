using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Fixable : Interactable
{
    public Sprite open;
    public Sprite closed;

    private SpriteRenderer sr;
    private bool isOpen;

    public override void Interact()
    {
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