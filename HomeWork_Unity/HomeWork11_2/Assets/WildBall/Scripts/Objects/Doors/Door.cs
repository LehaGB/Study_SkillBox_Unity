using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public Animator doorAnim;
    public bool isOpen;


    private void Start()
    {
        if (isOpen)
        {
            doorAnim.SetBool("isOpen", true);
        }
    }

    public string Description()
    {
        if (isOpen)
        {
            return "Press [E] to <color=red>close</color> the door";
        }
        return "Press [E] to <color=green>open</color> the door";
    }

    public void Interact()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            doorAnim.SetBool("IsOpen", true );
        }
        else
        {
            doorAnim.SetBool("IsOpen", false);
        }
    }
}
