using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Move2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isGrounded = false;
    public string popUp;
    public GameObject interactIcon;
    public bool canInteract = false;
    private Vector2 boxSize = new Vector2(0.1f,1f);

    void Start()
    {
        interactIcon.SetActive(false);
        canInteract = false;
    }
    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        if (Input.GetKeyDown(KeyCode.E) && canInteract == true)
			{
				CheckInteraction();
				PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
				pop.PopUp(popUp);
                GetComponent<DisableMovement>().popUpInteract = true;
			}
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
        }
    }

    public void OpenInteractableIcon()
		{
			interactIcon.SetActive(true);
            canInteract = true;
		}

	public void CloseInteractableIcon()
		{
			interactIcon.SetActive(false);
		}

	private void CheckInteraction()
	{
		RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position,boxSize, 0, Vector2.zero);

		if(hits.Length > 0)
		{
			foreach(RaycastHit2D rc in hits)
			{
				if (rc.transform.GetComponent<Interactable>())
				{
					// canInteract = true;
                    rc.transform.GetComponent<Interactable>().Interact();
					return;
				}
	            else 
                canInteract = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.collider.tag == "Fixable")
            {
            canInteract = true;
            }        
    }

        private void OnCollisionExit2D(Collision2D collision)
    {
            if (collision.collider.tag == "Fixable")
            {
            canInteract = false;
            }        
    }
}