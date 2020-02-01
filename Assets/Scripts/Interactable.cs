using System;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private void Start()
    {
        transform.tag = "Interaction";
    }

    public abstract void Interact();
    public string InteractionText = "Press E to interact";
    public KeyCode key;
}