using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Move2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isGrounded = false;
    public string popUp;
    public GameObject interactIcon;
    public bool canInteract;
    public bool canInteract2;
    private Vector2 boxSize = new Vector2(0.1f,1f);
    public SlotGame reset;
    public Interactable interactPrompt;   
    public SpriteRenderer sprite;
    // public bool minigame1;
 
    void Start()
    {
        sprite = interactIcon.GetComponent<SpriteRenderer>();
        sprite.color = new Color(1, 1, 1, 1);
        interactIcon.SetActive(false);
        canInteract = false;
        canInteract2 = false;
        // minigame1 = false;
    }

    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        // if (Input.GetKeyDown(KeyCode.E) && canInteract == true)
		// 	{
        //         CheckInteraction();
		// 		PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
		// 		pop.PopUp(popUp);
        //         GetComponent<DisableMovement>().popUpInteract = true;
        //         reset.Reset();
		// 	}
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 15f), ForceMode2D.Impulse);
        }
    }

    public void OpenInteractableIcon()
		{
			interactIcon.SetActive(true);
            sprite.color = new Color(1, 0, 0, 1);
            canInteract = true;
            canInteract2 = true;
            // minigame1 = true;
		}

	public void CloseInteractableIcon()
		{
			// interactIcon.SetActive(false);
            canInteract = false;
            canInteract2 = false;
            // minigame1 = false;
            sprite.color = new Color(1, 1, 1, 1);
		}

	public void CheckInteraction()
	{
		RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position,boxSize, 0, Vector2.zero);

		if(hits.Length > 0)
		{
			foreach(RaycastHit2D rc in hits)
			{
				if (rc.transform.GetComponent<Interactable>())
				{
					canInteract = true;
                    // minigame1 = true;
                    rc.transform.GetComponent<Interactable>().Interact();
					return;
				}
	            // else 
                // canInteract = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.collider.tag == "Fixable")
            {
            canInteract = true;
            // minigame1 = true;
            }        
    }

        private void OnCollisionExit2D(Collision2D collision)
    {
            if (collision.collider.tag == "Fixable")
            {
            canInteract = false;
            // minigame1 = false;
            }        
    }
}