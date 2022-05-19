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
    public SlotGame iscomplete;
    public Interactable interactPrompt;
    public GameObject interactIcon;

    void Update()
    {
            if (!timerReached)
            {
                if (timer > 3) {
                    Debug.Log("Done waiting");
                    interactable.canInteract = true;
                    interactPrompt.showIcon = true;
                    interactIcon.SetActive(true);

                    //Set to false so that We don't run this again
                    timerReached = true;
                }
                else {
                    if (GameObject.FindWithTag("Player").GetComponent<DisableMovement>().popUpInteract == false)
                    {
                    timer += Time.deltaTime;
                    Debug.Log(timer);
                    interactPrompt.showIcon = false;
                    interactIcon.SetActive(false);
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E) && interactable.canInteract == true)
                {
                    Debug.Log("Actually interacting");
                    GameObject.FindWithTag("Player").GetComponent<Move2D>().CheckInteraction();
                    PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
                    pop.PopUp(popUp);
                    GameObject.FindWithTag("Player").GetComponent<DisableMovement>().popUpInteract = true;
                    reset.Reset();
                    timer = Random.Range(-7, 0);
                    timerReached = false;
                    interactPrompt.showIcon = false;
                }
            }
    }
}