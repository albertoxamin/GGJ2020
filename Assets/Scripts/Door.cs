using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    private bool opened;
    [SerializeField]private Animator doorAnimator;
    public override void Interact()
    {
        opened = !opened;
        doorAnimator.SetBool("open", opened);
    }
}
