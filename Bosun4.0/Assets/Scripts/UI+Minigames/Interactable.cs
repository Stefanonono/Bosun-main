using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour
{
    public bool showIcon = false;

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }   
    public abstract void Interact();
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && showIcon)
        collision.gameObject.GetComponent<Move2D>().OpenInteractableIcon();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        collision.gameObject.GetComponent<Move2D>().CloseInteractableIcon();
    }
}