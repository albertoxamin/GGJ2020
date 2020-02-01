using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Interactable
{
    private bool opened;
    [SerializeField]private Animator doorAnimator;
    public void Interact()
    {
        opened = !opened;
        doorAnimator.SetBool("open", opened);
    }
}
