using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    float timer = 0;
    bool timerReached = false;
    public string popUp;
    public SlotGame reset;
    public Move2D interactable;

void Update()
{
    if (!timerReached)
        timer += Time.deltaTime;

    if (!timerReached && timer > 3)
    {
        Debug.Log("Done waiting");
        interactable.canInteract = true;
        Interact();

        //Set to false so that We don't run this again
        timerReached = true;
    }
}
    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactable.canInteract == true)
			{
                GetComponent<Move2D>().CheckInteraction();
				PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
				pop.PopUp(popUp);
                GetComponent<DisableMovement>().popUpInteract = true;
                reset.Reset();
			}
    }
}